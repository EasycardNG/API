﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCardNG.TransactionsApiClient;
using MerchantProfileApi.Models.Billing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shared.Helpers;
using Shared.Integration.Models;
using TestWebStore.Models;
using Transactions.Api.Models.PaymentRequests;

namespace TestWebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly WebHookStorage webHookStorage;
        private readonly TransactionsApiClient transactionsApiClient;
        private readonly ApplicationSettings appSettings;

        public HomeController(ILogger<HomeController> logger, IOptions<ApplicationSettings> appSettings, WebHookStorage webHookStorage, TransactionsApiClient transactionsApiClient)
        {
            this.logger = logger;
            this.webHookStorage = webHookStorage;
            this.transactionsApiClient = transactionsApiClient;
            this.appSettings = appSettings.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("PaymentResult")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> PaymentResult(PaymentResultViewModel model)
        {
            var transactionEntity = await transactionsApiClient.GetTransaction(model.TransactionID);

            model.Payload = JsonConvert.SerializeObject(transactionEntity, Formatting.Indented);

            return View(model);
        }

        [HttpPost]
        public IActionResult PayWithEasyCardLegacyFlow(BasketViewModel model)
        {
            var redirectUrl = BuildRedirectUrlForLegacyFlow(model);

            return Redirect(redirectUrl);
        }

        [HttpPost]
        public async Task<IActionResult> PayWithEasyCard(BasketViewModel model)
        {
            if (model.ConsumerID == null && !string.IsNullOrWhiteSpace(model.ConsumerExternalReference))
            {
                // Create new customer in ECNG system or get existin

                var exisingConsumers = await transactionsApiClient.GetConsumers(new ConsumersFilter 
                {
                    ExternalReference = model.ConsumerExternalReference,
                    //WoocommerceID = model.WoocommerceID, // TODO: use appropriate filters
                    //NationalID = model.NationalID
                });

                if (exisingConsumers.NumberOfRecords == 1)
                {
                    model.ConsumerID = exisingConsumers.Data.First().ConsumerID;
                }
                else if (exisingConsumers.NumberOfRecords > 1)
                {
                    throw new ApplicationException("There are several consumers with same ExternalReference in ECNG");
                }

                if (model.ConsumerID == null)
                {
                    var consumerRequest = new ConsumerRequest
                    {
                        ConsumerEmail = model.Email,
                        ConsumerName = model.Name,
                        ConsumerNationalID = model.NationalID,
                        ConsumerPhone = model.Phone,
                        ExternalReference = model.ConsumerExternalReference,
                    };

                    //if (address != null)
                    //{
                    //    consumerRequest.ConsumerAddress = new Address
                    //    {
                    //        CountryCode = address.CountryCode,
                    //        City = address.City,
                    //        Zip = address.ZipCode,
                    //        Street = address.Street,
                    //        House = address.HouseNumber,
                    //        Apartment = address.AppartmentNumber
                    //    };
                    //}

                    var consumerResponse = await transactionsApiClient.CreateConsumer(consumerRequest);

                    model.ConsumerID = consumerResponse.EntityUID;
                }
            }

            var webStoreUrl = appSettings.RedirectUrlBase;

            PaymentRequestCreate easyCardQuery = new PaymentRequestCreate();

            easyCardQuery.Currency = CurrencyEnum.ILS;
            easyCardQuery.RedirectUrl = UrlHelper.BuildUrl(webStoreUrl, "PaymentResult", new { model.InternalOrderID });

            easyCardQuery.AllowPinPad = model.AllowPinPad;
            easyCardQuery.IssueInvoice = model.IssueInvoice;

            easyCardQuery.DealDetails = new DealDetails
            {
                ConsumerName = model.Name,
                ConsumerNationalID = model.NationalID,
                ConsumerEmail = model.Email,
                ConsumerID = model.ConsumerID,
                DealDescription = $"Goods and services from Test Wen Store: {model.ProductName}",
            };

            var sum = (model.Price * model.Quantity).GetValueOrDefault();

            var userAmount = model.UserAmount;

            // Only add credit card
            if (!userAmount && sum == 0)
            {
                easyCardQuery.DealDetails.DealDescription = "Please Add Credit Card";
                easyCardQuery.AllowPinPad = false;
            }

            easyCardQuery.IsRefund = model.Refund;

            if (sum > 0)
            {
                easyCardQuery.UserAmount = userAmount;
                easyCardQuery.PaymentRequestAmount = Math.Round(sum, 2, MidpointRounding.AwayFromZero);
                easyCardQuery.NetTotal = Math.Round(sum / 1.17m, 2, MidpointRounding.AwayFromZero); // TODO VAT Rate
                easyCardQuery.VATRate = 0.17m;
                easyCardQuery.VATTotal = easyCardQuery.PaymentRequestAmount.GetValueOrDefault() - easyCardQuery.NetTotal;
            }
            else
            {
                easyCardQuery.UserAmount = userAmount;
                easyCardQuery.PaymentRequestAmount = 0;
                easyCardQuery.VATRate = 0.17m;
                easyCardQuery.VATTotal = 0;
                easyCardQuery.NetTotal = 0;
            }

            var paymentIntentRes = await transactionsApiClient.CreatePaymentIntent(easyCardQuery);

            if (paymentIntentRes.Status != Shared.Api.Models.Enums.StatusEnum.Success)
            {
                ViewBag.Error = paymentIntentRes.Message;
                return View("Index", model);
            }

            return Redirect(paymentIntentRes.AdditionalData["url"].ToString());
        }

        private string BuildRedirectUrlForLegacyFlow(BasketViewModel model)
        {
            var ecUrl = transactionsApiClient.GetCheckoutUrl();
            var webStoreUrl = appSettings.RedirectUrlBase;

            var redirectUrl = UrlHelper.BuildUrl(webStoreUrl, "PaymentResult", new { model.InternalOrderID });

            var request = new CardRequest
            {
                Amount = (model.Price * model.Quantity).GetValueOrDefault(),
                ApiKey = appSettings.EasyCardSharedApiKey,
                ConsumerID = model.ConsumerID,
                Currency = "ILS",
                Email = model.Email,
                Name = model.Name,
                NationalID = model.NationalID,
                Phone = model.Phone,
                RedirectUrl = redirectUrl,
                Description = $"Goods and services from Test Wen Store: {model.ProductName}",
                IssueInvoice = model.IssueInvoice,
                AllowPinPad = model.AllowPinPad
            };

            var res = UrlHelper.BuildUrl(ecUrl, null, request);

            return res;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Webhook endpoint
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Webhook()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    var res = await reader.ReadToEndAsync();

                    var wh = JsonConvert.DeserializeObject<WebHookData>(res);

                    if (wh == null)
                    {
                        logger.LogError($"Webhook data is empty: {res}");
                        return Ok();
                    }

                    // if it is TransactionCreated event, get transaction entity using API 
                    if (wh.EventName == WebHookData.TransactionCreated && !string.IsNullOrWhiteSpace(wh.EntityReference))
                    {
                        var transactionEntity = await transactionsApiClient.GetTransaction(wh.EntityReference);

                        wh.Payload = JsonConvert.SerializeObject(transactionEntity);
                    }

                    await webHookStorage.StoreData(wh);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Webhook error: {ex.Message}");
            }

            return Ok();
        }

        /// <summary>
        /// Display collected webhooks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Webhooks()
        {
            var res = await webHookStorage.GetData();

            return View(res);
        }
    }
}
