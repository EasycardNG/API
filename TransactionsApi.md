<!-- Generator: Widdershins v4.0.1 -->

<h1 id="easycard-transactions-api">EasyCard Transactions API v1</h1>

-----------------------------------------------------------------
> Please refer to Full API description if you need most recent development version

Development version: [https://ecng-transactions.azurewebsites.net/api-docs/index.html](https://ecng-transactions.azurewebsites.net/api-docs/index.html)

Live version: [https://api.e-c.co.il/api-docs/index.html](https://api.e-c.co.il/api-docs/index.html)


- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

> Scroll down for example requests and responses.

- [Authentication](Readme.md#authentication)
- [Environments](Readme.md#environments)
- [Examples](Readme.md#examples)
- [Billing](#billing)
  - [Get billing deals list using filter](#get-billing-deals-list-using-filter)
  - [Create billing deal](#create-billing-deal)
  - [Get billing deal details](#get-billing-deal-details)
  - [Update billing deal](#update-billing-deal)
  - [Update credit card token for billing deal](#update-credit-card-token-for-billing-deal)
- [CardToken](#cardtoken)
  - [Get tokens by filters](#get-tokens-by-filters)
  - [Delete credit card token](#delete-credit-card-token)
- [PaymentIntent](#paymentintent)
  - [Get payment intent details](#get-payment-intent-details)
  - [Delete payment intent](#delete-payment-intent)
  - [Create payment link to Checkout Page](#create-payment-link-to-checkout-page)
- [PaymentRequests](#paymentrequests)
  - [Get payment requests by filters](#get-payment-requests-by-filters)
  - [Create payment request](#create-payment-request)
  - [Get payment request details by ID](#get-payment-request-details-by-id)
  - [Cancel payment request](#cancel-payment-request)
- [TransactionsApi](#transactionsapi)
  - [Get payment transaction details](#get-payment-transaction-details)
  - [Get payment transactions list using filter](#get-payment-transactions-list-using-filter)
  - [Create the charge based on credit card or previously stored credit card token (J4 deal)](#create-the-charge-based-on-credit-card-or-previously-stored-credit-card-token-j4-deal)
  - [Blocking funds on credit card (J5 deal)](#blocking-funds-on-credit-card-j5-deal)
  - [Implement J5 deal](#implement-j5-deal)
  - [Check if credit card is valid](#check-if-credit-card-is-valid)
  - [Refund request](#refund-request)
  - [Refund or chargeback of and existing transaction](#refund-or-chargeback-of-and-existing-transaction)
- [Webhooks](#webhooks)
  - [Get executed webhooks history](#get-executed-webhooks-history)
- [Schemas](#schemas)

# Billing

## Get billing deals list using filter

`GET /api/billing`

<h3 id="get-billing-deals-list-using-filter-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|QuickStatus|query|[BillingsQuickStatusFilterEnum](#schemabillingsquickstatusfilterenum)|false|none|
|TerminalID|query|string(uuid)|false|none|
|MerchantID|query|string(uuid)|false|none|
|BillingDealID|query|string(uuid)|false|none|
|Currency|query|[CurrencyEnum](#schemacurrencyenum)|false|none|
|QuickDateFilter|query|[QuickDateFilterTypeEnum](#schemaquickdatefiltertypeenum)|false|none|
|FilterDateByNextScheduledTransaction|query|boolean|false|none|
|DateFrom|query|string(date)|false|none|
|DateTo|query|string(date)|false|none|
|ConsumerID|query|string(uuid)|false|none|
|CreditCardTokenID|query|string(uuid)|false|none|
|CardNumber|query|string|false|none|
|CardOwnerNationalID|query|string|false|none|
|ConsumerName|query|string|false|Performs search by both consumer name and card owner name|
|ConsumerEmail|query|string|false|End-customer Email|
|CreditCardVendor|query|string|false|none|
|Actual|query|boolean|false|Billing deals that can be manually triggered|
|Finished|query|boolean|false|none|
|Paused|query|boolean|false|none|
|HasError|query|boolean|false|none|
|PaymentType|query|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|
|DealReference|query|string|false|Merchant deal reference|
|InvoiceOnly|query|boolean|false|none|
|Origin|query|string|false|none|
|OnlyActive|query|boolean|false|none|
|InProgress|query|boolean|false|none|
|CreditCardExpired|query|boolean|false|none|
|ConsumerExternalReference|query|string|false|none|
|BillingDealType|query|[BillingDealTypeEnum](#schemabillingdealtypeenum)|false|none|
|Take|query|integer(int32)|false|none|
|Skip|query|integer(int32)|false|none|
|SortBy|query|string|false|none|
|SortDesc|query|boolean|false|none|
|ShowDeleted|query|[ShowDeletedEnum](#schemashowdeletedenum)|false|none|

> Example responses

> 200 Response

```json
{
  "totalAmountILS": 0,
  "totalAmountUSD": 0,
  "totalAmountEUR": 0,
  "numberOfRecords": 0,
  "data": [
    {
      "billingDealID": "4cd118ba-cace-48f5-9541-35d080140955",
      "terminalName": "string",
      "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
      "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
      "transactionAmount": 0,
      "currency": "ILS",
      "billingDealTimestamp": "2019-08-24T14:15:22Z",
      "nextScheduledTransaction": "2019-08-24T14:15:22Z",
      "currentTransactionTimestamp": "2019-08-24T14:15:22Z",
      "consumerName": "string",
      "billingSchedule": {
        "repeatPeriodType": "oneTime",
        "startAtType": "today",
        "startAt": "2019-08-24T14:15:22Z",
        "endAtType": "never",
        "endAt": "2019-08-24T14:15:22Z",
        "endAtNumberOfPayments": 0
      },
      "cardNumber": "string",
      "cardExpired": true,
      "active": true,
      "currentDeal": 0,
      "pausedFrom": "2019-08-24T14:15:22Z",
      "pausedTo": "2019-08-24T14:15:22Z",
      "paused": true,
      "paymentType": "card",
      "dealDetails": {
        "dealReference": "string",
        "dealDescription": "string",
        "consumerEmail": "user@example.com",
        "consumerName": "string",
        "consumerNationalID": "string",
        "consumerPhone": "string",
        "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
        "items": [
          {
            "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
            "externalReference": "string",
            "itemName": "string",
            "sku": "string",
            "price": 0,
            "netPrice": 0,
            "quantity": 0.01,
            "amount": 0,
            "vatRate": 1,
            "vat": 0,
            "netAmount": 0,
            "discount": 0,
            "netDiscount": 0,
            "extension": null,
            "woocommerceID": "string",
            "ecwidID": "string"
          }
        ],
        "consumerAddress": {
          "countryCode": "string",
          "city": "string",
          "zip": "string",
          "street": "string",
          "house": "string",
          "apartment": "string"
        },
        "consumerExternalReference": "string",
        "consumerWoocommerceID": "string",
        "consumerEcwidID": "string",
        "responsiblePerson": "string",
        "externalUserID": "string",
        "branch": "string",
        "department": "string"
      },
      "invoiceOnly": true,
      "creditCardToken": "8000dee3-fd2b-4f6f-9c2f-678fb99e8ae4",
      "consumerExternalReference": "string"
    }
  ]
}
```

<h3 id="get-billing-deals-list-using-filter-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[SummariesAmountResponse_BillingDealSummary](#schemasummariesamountresponse_billingdealsummary)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_manager_or_admin )
</aside>

## Create billing deal

`POST /api/billing`

> Body parameter

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "currency": "ILS",
  "creditCardToken": "8000dee3-fd2b-4f6f-9c2f-678fb99e8ae4",
  "transactionAmount": 0.01,
  "vatRate": 1,
  "vatTotal": 0,
  "netTotal": 0.01,
  "billingSchedule": {
    "repeatPeriodType": "oneTime",
    "startAtType": "today",
    "startAt": "2019-08-24T14:15:22Z",
    "endAtType": "never",
    "endAt": "2019-08-24T14:15:22Z",
    "endAtNumberOfPayments": 0
  },
  "issueInvoice": true,
  "invoiceDetails": {
    "invoiceType": "invoice",
    "invoiceSubject": "string",
    "sendCCTo": [
      "string"
    ],
    "donation": true,
    "invoiceLanguage": "string"
  },
  "paymentType": "card",
  "bankDetails": {
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "origin": "string",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  }
}
```

<h3 id="create-billing-deal-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[BillingDealRequest](#schemabillingdealrequest)|false|none|

> Example responses

> 201 Response

```json
{
  "message": "Billing Deal Created",
  "status": "success",
  "entityUID": "253d8de2-b5ed-4f9a-9a23-63b0aa1c30c6"
}
```

> 400 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "0607b859-87d0-4fc8-bf4d-cc364c2f5d15",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

> 404 Response

```json
{
  "message": "Entity Not Found",
  "status": "error",
  "correlationId": "29639763-b16a-4547-bff0-05e6b2f199b2",
  "entityType": "Consumer"
}
```

<h3 id="create-billing-deal-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Created|[OperationResponse](#schemaoperationresponse)|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[OperationResponse](#schemaoperationresponse)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_manager_or_admin )
</aside>

## Get billing deal details

`GET /api/billing/{BillingDealID}`

<h3 id="get-billing-deal-details-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|billingDealID|path|string(uuid)|true|none|

> Example responses

> 200 Response

```json
{
  "billingDealID": "00000000-0000-0000-0000-000000000000",
  "billingDealTimestamp": null,
  "initialTransactionID": null,
  "terminalID": null,
  "terminalName": null,
  "merchantID": null,
  "currency": "USD",
  "transactionAmount": 1200,
  "amount": 0,
  "totalAmount": 0,
  "currentDeal": null,
  "currentTransactionTimestamp": null,
  "currentTransactionID": null,
  "nextScheduledTransaction": null,
  "creditCardDetails": null,
  "bankDetails": null,
  "creditCardToken": "14fbfce9-fb88-4c03-8ecf-d9366c9984f6",
  "dealDetails": {
    "dealReference": "123456",
    "dealDescription": "some product pack: 3kg.",
    "consumerEmail": "email@example.com",
    "consumerPhone": "555-765",
    "consumerID": "e68bdf0c-a6b3-40fa-a63c-42c0d6eddc0f"
  },
  "billingSchedule": {
    "repeatPeriodType": "monthly",
    "startAtType": "specifiedDate",
    "startAt": "2022-10-07T18:08:18.6121795+03:00",
    "endAtType": "afterNumberOfPayments",
    "endAt": null,
    "endAtNumberOfPayments": 10
  },
  "updatedDate": null,
  "updateTimestamp": null,
  "operationDoneBy": null,
  "operationDoneByID": null,
  "correlationId": null,
  "sourceIP": null,
  "active": false,
  "cardExpired": null,
  "tokenNotAvailable": null,
  "invoiceDetails": null,
  "issueInvoice": false,
  "invoiceOnly": false,
  "vatRate": 0,
  "vatTotal": 0,
  "netTotal": 0,
  "pausedFrom": null,
  "pausedTo": null,
  "paused": false,
  "paymentType": "card",
  "lastError": null,
  "lastErrorCorrelationID": null,
  "paymentDetails": null,
  "failedAttemptsCount": null,
  "expirationEmailSent": null,
  "tokenUpdated": null,
  "tokenCreated": null
}
```

<h3 id="get-billing-deal-details-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[BillingDealResponse](#schemabillingdealresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_manager_or_admin )
</aside>

## Update billing deal

`PUT /api/billing/{BillingDealID}`

> Body parameter

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "currency": "ILS",
  "creditCardToken": "8000dee3-fd2b-4f6f-9c2f-678fb99e8ae4",
  "transactionAmount": 0.01,
  "vatRate": 1,
  "vatTotal": 0,
  "netTotal": 0.01,
  "billingSchedule": {
    "repeatPeriodType": "oneTime",
    "startAtType": "today",
    "startAt": "2019-08-24T14:15:22Z",
    "endAtType": "never",
    "endAt": "2019-08-24T14:15:22Z",
    "endAtNumberOfPayments": 0
  },
  "issueInvoice": true,
  "invoiceDetails": {
    "invoiceType": "invoice",
    "invoiceSubject": "string",
    "sendCCTo": [
      "string"
    ],
    "donation": true,
    "invoiceLanguage": "string"
  },
  "paymentType": "card",
  "bankDetails": {
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  }
}
```

<h3 id="update-billing-deal-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|billingDealID|path|string(uuid)|true|none|
|body|body|[BillingDealUpdateRequest](#schemabillingdealupdaterequest)|false|none|

> Example responses

> 200 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "b4e0bd21-4e21-498c-ae95-9932ed12aec4",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

<h3 id="update-billing-deal-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_manager_or_admin )
</aside>

## Update credit card token for billing deal

`PATCH /api/billing/{BillingDealID}/change-token/{tokenID}`

<h3 id="update-credit-card-token-for-billing-deal-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|billingDealID|path|string(uuid)|true|none|
|tokenID|path|string(uuid)|true|none|

> Example responses

> 200 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "bd23b59b-3bb2-40dd-afbe-b157a300db64",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

<h3 id="update-credit-card-token-for-billing-deal-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_manager_or_admin )
</aside>

# CardToken

## Get tokens by filters

`GET /api/cardtokens`

<h3 id="get-tokens-by-filters-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|CreditCardTokenID|query|string(uuid)|false|none|
|CardNumber|query|string|false|none|
|CardOwnerNationalID|query|string|false|none|
|CardOwnerName|query|string|false|none|
|TerminalID|query|string(uuid)|false|none|
|MerchantID|query|string(uuid)|false|none|
|ConsumerID|query|string(uuid)|false|none|
|ConsumerEmail|query|string|false|End-customer Email|
|Take|query|integer(int32)|false|none|
|Skip|query|integer(int32)|false|none|
|SortBy|query|string|false|none|
|SortDesc|query|boolean|false|none|
|ShowDeleted|query|[ShowDeletedEnum](#schemashowdeletedenum)|false|none|

> Example responses

> 200 Response

```json
{
  "numberOfRecords": 0,
  "data": [
    {
      "creditCardTokenID": "f6aae4d3-a111-4061-86e5-728917783b8c",
      "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
      "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
      "cardNumber": "string",
      "cardExpiration": {
        "year": 20,
        "month": 1,
        "expired": true
      },
      "cardVendor": "string",
      "created": "2019-08-24T14:15:22Z",
      "cardOwnerName": "string",
      "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
      "consumerEmail": "string",
      "expired": true
    }
  ]
}
```

<h3 id="get-tokens-by-filters-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[SummariesResponse_CreditCardTokenSummary](#schemasummariesresponse_creditcardtokensummary)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

## Delete credit card token

`DELETE /api/cardtokens/{key}`

<h3 id="delete-credit-card-token-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|key|path|string|true|none|

> Example responses

> 200 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "1898bf3a-70b3-4a9b-b7b2-432af48a53de",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

<h3 id="delete-credit-card-token-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

# PaymentIntent

## Get payment intent details

`GET /api/paymentIntent/{paymentIntentID}`

<h3 id="get-payment-intent-details-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|paymentIntentID|path|string(uuid)|true|none|

> Example responses

> 200 Response

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "terminalName": "string",
  "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
  "paymentTransactionID": "19fb5b03-41a8-4687-a896-97851484218b",
  "paymentRequestUrl": "string",
  "history": [
    {
      "paymentRequestHistoryID": "a27f677d-9bac-4614-b73b-38acec040a90",
      "operationDate": "2019-08-24T14:15:22Z",
      "operationDoneBy": "string",
      "operationCode": "PaymentRequestCreated",
      "operationMessage": "string"
    }
  ],
  "userPaidDetails": {
    "vatRate": 0,
    "vatTotal": 0,
    "netTotal": 0,
    "transactionAmount": 0
  },
  "amount": 0,
  "origin": "string",
  "paymentRequestID": "e1c25505-9cc4-4f14-8180-c89257d3d43a",
  "paymentRequestTimestamp": "2019-08-24T14:15:22Z",
  "dueDate": "2019-08-24T14:15:22Z",
  "currency": "ILS",
  "status": "initial",
  "quickStatus": "pending",
  "cardOwnerName": "string",
  "cardOwnerNationalID": "string",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  },
  "vatRate": 0,
  "vatTotal": 0,
  "netTotal": 0,
  "numberOfPayments": 0,
  "initialPaymentAmount": 0,
  "totalAmount": 0,
  "installmentPaymentAmount": 0,
  "paymentRequestAmount": 0,
  "isRefund": true,
  "userAmount": true,
  "redirectUrl": "string",
  "onlyAddCard": true,
  "showAuthCode": true,
  "transactionType": "regularDeal"
}
```

<h3 id="get-payment-intent-details-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[PaymentRequestResponse](#schemapaymentrequestresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

## Delete payment intent

`DELETE /api/paymentIntent/{paymentIntentID}`

<h3 id="delete-payment-intent-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|paymentIntentID|path|string(uuid)|true|none|

> Example responses

> 200 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "542411b2-831f-42a3-b32d-3e135d6b8591",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

<h3 id="delete-payment-intent-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

## Create payment link to Checkout Page

`POST /api/paymentIntent`

> Body parameter

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  },
  "currency": "ILS",
  "paymentRequestAmount": 0,
  "dueDate": "2019-08-24T14:15:22Z",
  "transactionType": "regularDeal",
  "installmentDetails": {
    "numberOfPayments": 1,
    "initialPaymentAmount": 0.01,
    "totalAmount": 0.01,
    "installmentPaymentAmount": 0.01
  },
  "invoiceDetails": {
    "invoiceType": "invoice",
    "invoiceSubject": "string",
    "sendCCTo": [
      "string"
    ],
    "donation": true,
    "invoiceLanguage": "string"
  },
  "pinPadDetails": {
    "terminalID": "string"
  },
  "issueInvoice": true,
  "allowPinPad": true,
  "vatRate": 1,
  "vatTotal": 0,
  "netDiscountTotal": 0,
  "discountTotal": 0,
  "netTotal": 0,
  "requestSubject": "string",
  "fromAddress": "string",
  "isRefund": true,
  "redirectUrl": "string",
  "userAmount": true,
  "cardOwnerNationalID": "string",
  "extension": null,
  "language": "string",
  "origin": "string",
  "allowInstallments": true,
  "allowCredit": true,
  "allowImmediate": true,
  "hidePhone": true,
  "hideEmail": true,
  "hideNationalID": true,
  "showAuthCode": true
}
```

<h3 id="create-payment-link-to-checkout-page-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[PaymentRequestCreate](#schemapaymentrequestcreate)|false|Payment parameters|

> Example responses

> 201 Response

```json
{
  "message": "Payment Request Created",
  "status": "success",
  "entityUID": "f298ae2f-32e1-4e2b-8913-fdfcc269f83a",
  "additionalData": {
    "url": "https://checkout.e-c.co.il/i?r=4xgxjJrpKhOgdJa01YhT9fMy7AHdUi1XmWralF9lbbnB0nTGB1vw%3d%3d"
  }
}
```

> 400 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "78a81b48-8be6-4258-8251-ffbe552f80ba",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

> 404 Response

```json
{
  "message": "Entity Not Found",
  "status": "error",
  "correlationId": "5a088983-c333-40f8-bf31-3f39ad2f30ed",
  "entityType": "Consumer"
}
```

<h3 id="create-payment-link-to-checkout-page-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Created|[OperationResponse](#schemaoperationresponse)|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[OperationResponse](#schemaoperationresponse)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

# PaymentRequests

## Get payment requests by filters

`GET /api/paymentRequests`

<h3 id="get-payment-requests-by-filters-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|TerminalID|query|string(uuid)|false|none|
|PaymentRequestID|query|string(uuid)|false|none|
|Currency|query|[CurrencyEnum](#schemacurrencyenum)|false|none|
|QuickDateFilter|query|[QuickDateFilterTypeEnum](#schemaquickdatefiltertypeenum)|false|none|
|DateFrom|query|string(date)|false|none|
|DateTo|query|string(date)|false|none|
|Status|query|[PaymentRequestStatusEnum](#schemapaymentrequeststatusenum)|false|none|
|QuickStatus|query|[PayReqQuickStatusFilterTypeEnum](#schemapayreqquickstatusfiltertypeenum)|false|none|
|PaymentRequestAmount|query|number(double)|false|none|
|ConsumerID|query|string(uuid)|false|none|
|ConsumerExternalReference|query|string|false|none|
|Take|query|integer(int32)|false|none|
|Skip|query|integer(int32)|false|none|
|SortBy|query|string|false|none|
|SortDesc|query|boolean|false|none|
|ShowDeleted|query|[ShowDeletedEnum](#schemashowdeletedenum)|false|none|

> Example responses

> 200 Response

```json
{
  "totalAmountILS": 0,
  "totalAmountUSD": 0,
  "totalAmountEUR": 0,
  "numberOfRecords": 0,
  "data": [
    {
      "paymentRequestID": "e1c25505-9cc4-4f14-8180-c89257d3d43a",
      "paymentRequestTimestamp": "2019-08-24T14:15:22Z",
      "dueDate": "2019-08-24T14:15:22Z",
      "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
      "status": "initial",
      "quickStatus": "pending",
      "currency": "ILS",
      "paymentRequestAmount": 0,
      "cardOwnerName": "string",
      "consumerEmail": "string",
      "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
      "paymentTransactionID": "19fb5b03-41a8-4687-a896-97851484218b",
      "isRefund": true
    }
  ]
}
```

<h3 id="get-payment-requests-by-filters-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[SummariesAmountResponse_PaymentRequestSummary](#schemasummariesamountresponse_paymentrequestsummary)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

## Create payment request

`POST /api/paymentRequests`

> Body parameter

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  },
  "currency": "ILS",
  "paymentRequestAmount": 0,
  "dueDate": "2019-08-24T14:15:22Z",
  "transactionType": "regularDeal",
  "installmentDetails": {
    "numberOfPayments": 1,
    "initialPaymentAmount": 0.01,
    "totalAmount": 0.01,
    "installmentPaymentAmount": 0.01
  },
  "invoiceDetails": {
    "invoiceType": "invoice",
    "invoiceSubject": "string",
    "sendCCTo": [
      "string"
    ],
    "donation": true,
    "invoiceLanguage": "string"
  },
  "pinPadDetails": {
    "terminalID": "string"
  },
  "issueInvoice": true,
  "allowPinPad": true,
  "vatRate": 1,
  "vatTotal": 0,
  "netDiscountTotal": 0,
  "discountTotal": 0,
  "netTotal": 0,
  "requestSubject": "string",
  "fromAddress": "string",
  "isRefund": true,
  "redirectUrl": "string",
  "userAmount": true,
  "cardOwnerNationalID": "string",
  "extension": null,
  "language": "string",
  "origin": "string",
  "allowInstallments": true,
  "allowCredit": true,
  "allowImmediate": true,
  "hidePhone": true,
  "hideEmail": true,
  "hideNationalID": true,
  "showAuthCode": true
}
```

<h3 id="create-payment-request-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[PaymentRequestCreate](#schemapaymentrequestcreate)|false|none|

> Example responses

> 201 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "c4442a45-38d7-4578-8f87-249becbe26b4",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

<h3 id="create-payment-request-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Created|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

## Get payment request details by ID

`GET /api/paymentRequests/{paymentRequestID}`

<h3 id="get-payment-request-details-by-id-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|paymentRequestID|path|string(uuid)|true|none|

> Example responses

> 200 Response

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "terminalName": "string",
  "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
  "paymentTransactionID": "19fb5b03-41a8-4687-a896-97851484218b",
  "paymentRequestUrl": "string",
  "history": [
    {
      "paymentRequestHistoryID": "a27f677d-9bac-4614-b73b-38acec040a90",
      "operationDate": "2019-08-24T14:15:22Z",
      "operationDoneBy": "string",
      "operationCode": "PaymentRequestCreated",
      "operationMessage": "string"
    }
  ],
  "userPaidDetails": {
    "vatRate": 0,
    "vatTotal": 0,
    "netTotal": 0,
    "transactionAmount": 0
  },
  "amount": 0,
  "origin": "string",
  "paymentRequestID": "e1c25505-9cc4-4f14-8180-c89257d3d43a",
  "paymentRequestTimestamp": "2019-08-24T14:15:22Z",
  "dueDate": "2019-08-24T14:15:22Z",
  "currency": "ILS",
  "status": "initial",
  "quickStatus": "pending",
  "cardOwnerName": "string",
  "cardOwnerNationalID": "string",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  },
  "vatRate": 0,
  "vatTotal": 0,
  "netTotal": 0,
  "numberOfPayments": 0,
  "initialPaymentAmount": 0,
  "totalAmount": 0,
  "installmentPaymentAmount": 0,
  "paymentRequestAmount": 0,
  "isRefund": true,
  "userAmount": true,
  "redirectUrl": "string",
  "onlyAddCard": true,
  "showAuthCode": true,
  "transactionType": "regularDeal"
}
```

<h3 id="get-payment-request-details-by-id-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[PaymentRequestResponse](#schemapaymentrequestresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

## Cancel payment request

`DELETE /api/paymentRequests/{paymentRequestID}`

<h3 id="cancel-payment-request-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|paymentRequestID|path|string(uuid)|true|none|

> Example responses

> 200 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "42cf05c3-c2d8-4029-8b30-2ada6e339403",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

<h3 id="cancel-payment-request-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

# TransactionsApi

## Get payment transaction details

`GET /api/transactions/{transactionID}`

<h3 id="get-payment-transaction-details-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|transactionID|path|string(uuid)|true|Payment transaction UUId|

> Example responses

> 200 Response

```json
{
  "paymentTransactionID": "bf54f8bc-b997-4345-b37b-8eb3328651d0",
  "transactionDate": "2022-10-07T00:00:00",
  "transactionTimestamp": "2022-10-07T15:08:18.7523005Z",
  "status": "awaitingForTransmission",
  "paymentTypeEnum": "card",
  "quickStatus": 0,
  "transactionType": "installments",
  "specialTransactionType": "regularDeal",
  "jDealType": "J4",
  "currency": "USD",
  "cardPresence": "cardNotPresent",
  "numberOfPayments": 6,
  "transactionAmount": 1200,
  "amount": 0,
  "initialPaymentAmount": 200,
  "totalAmount": 1200,
  "installmentPaymentAmount": 200,
  "creditCardDetails": {
    "cardNumber": "123456****1234",
    "cardExpiration": "12/22",
    "cardBrand": "VISA",
    "cardOwnerName": "John Smith",
    "cardOwnerNationalID": "1234567"
  },
  "dealDetails": {
    "dealReference": "123456",
    "dealDescription": "some product pack: 3kg.",
    "consumerEmail": "email@example.com",
    "consumerPhone": "555-765",
    "consumerID": "fc5056e5-6b9b-429c-988d-74072e12189d"
  },
  "shvaTransactionDetails": {
    "shvaShovarNumber": "123456",
    "shvaDealID": "12345678901234567890"
  },
  "vatRate": 0.17,
  "vatTotal": 174.36,
  "netTotal": 1025.64,
  "correlationId": "5347f8d2-4357-4623-a92d-11fb848832c4",
  "invoiceID": "7508f660-1341-45a8-92aa-e836c36f722b",
  "issueInvoice": true,
  "documentOrigin": "checkout",
  "paymentRequestID": "98f7eba5-9ab0-4023-81f1-cbecb45a3d4f",
  "extension": {
    "customPropertyInMySystem": "MyCustomValue"
  },
  "allowTransmission": false,
  "allowTransmissionCancellation": true,
  "allowRefund": false,
  "allowInvoiceCreation": false
}
```

<h3 id="get-payment-transaction-details-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[TransactionResponse](#schematransactionresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

## Get payment transactions list using filter

`GET /api/transactions`

<h3 id="get-payment-transactions-list-using-filter-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|TerminalID|query|string(uuid)|false|none|
|MerchantID|query|string(uuid)|false|none|
|PaymentTransactionID|query|string(uuid)|false|none|
|PaymentTransactionRequestID|query|string(uuid)|false|none|
|PaymentTransactionIntentID|query|string(uuid)|false|none|
|AmountFrom|query|number(double)|false|none|
|AmountTo|query|number(double)|false|none|
|Currency|query|[CurrencyEnum](#schemacurrencyenum)|false|none|
|QuickDateFilter|query|[QuickDateFilterTypeEnum](#schemaquickdatefiltertypeenum)|false|none|
|TransmissionQuickDateFilter|query|[QuickDateFilterTypeEnum](#schemaquickdatefiltertypeenum)|false|none|
|QuickStatusFilter|query|[QuickStatusFilterTypeEnum](#schemaquickstatusfiltertypeenum)|false|none|
|Statuses|query|array[string]|false|none|
|TransactionType|query|[TransactionTypeEnum](#schematransactiontypeenum)|false|none|
|JDealType|query|[JDealTypeEnum](#schemajdealtypeenum)|false|none|
|CardPresence|query|[CardPresenceEnum](#schemacardpresenceenum)|false|none|
|ShvaShovarNumber|query|string|false|none|
|ShvaTransactionID|query|string|false|none|
|ClearingHouseTransactionID|query|integer(int64)|false|none|
|DateFrom|query|string(date)|false|none|
|DateTo|query|string(date)|false|none|
|ConsumerID|query|string(uuid)|false|none|
|CreditCardTokenID|query|string(uuid)|false|none|
|CardNumber|query|string|false|none|
|CardOwnerNationalID|query|string|false|none|
|CardOwnerName|query|string|false|none|
|ConsumerEmail|query|string|false|End-customer Email|
|DealReference|query|string|false|Merchant deal reference|
|DealDescription|query|string|false|none|
|Solek|query|[SolekEnum](#schemasolekenum)|false|none|
|CreditCardVendor|query|string|false|none|
|BillingDealID|query|string(uuid)|false|none|
|SpecialTransactionType|query|[SpecialTransactionTypeEnum](#schemaspecialtransactiontypeenum)|false|none|
|NotTransmitted|query|boolean|false|none|
|TerminalTemplateID|query|integer(int64)|false|none|
|FinalizationStatus|query|[TransactionFinalizationStatusEnum](#schematransactionfinalizationstatusenum)|false|none|
|DocumentOrigin|query|[DocumentOriginEnum](#schemadocumentoriginenum)|false|none|
|HasInvoice|query|[PropertyPresenceEnum](#schemapropertypresenceenum)|false|none|
|IsPaymentRequest|query|boolean|false|none|
|PaymentType|query|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|
|ShvaDealIDLastDigits|query|string|false|none|
|PaymentTransactionIDShort|query|string|false|none|
|HasMasavFile|query|boolean|false|none|
|ConsumerExternalReference|query|string|false|none|
|InitialTransactionID|query|string(uuid)|false|Reference to initial transaction|
|Take|query|integer(int32)|false|none|
|Skip|query|integer(int32)|false|none|
|SortBy|query|string|false|none|
|SortDesc|query|boolean|false|none|
|ShowDeleted|query|[ShowDeletedEnum](#schemashowdeletedenum)|false|none|

> Example responses

> 200 Response

```json
{
  "totalAmountILS": 0,
  "totalAmountUSD": 0,
  "totalAmountEUR": 0,
  "numberOfRecords": 0,
  "data": [
    {
      "paymentTransactionID": "19fb5b03-41a8-4687-a896-97851484218b",
      "terminalName": "string",
      "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
      "documentOrigin": "UI",
      "cardNumber": "string",
      "rejectionMessage": "string",
      "processorResultCode": 0,
      "transactionAmount": 0,
      "initialPaymentAmount": 0,
      "installmentPaymentAmount": 0,
      "transactionType": "regularDeal",
      "currency": "ILS",
      "transactionTimestamp": "2019-08-24T14:15:22Z",
      "status": "initial",
      "paymentTypeEnum": "card",
      "quickStatus": "Pending",
      "specialTransactionType": "regularDeal",
      "jDealType": "J4",
      "rejectionReason": "unknown",
      "cardPresence": "cardNotPresent",
      "cardOwnerName": "string",
      "consumerExternalReference": "string",
      "shvaDealID": "string",
      "invoiceID": "4f03a727-9c4b-43a5-b699-271a3e6fdc9c",
      "dealDescription": "string"
    }
  ]
}
```

<h3 id="get-payment-transactions-list-using-filter-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[SummariesAmountResponse_TransactionSummary](#schemasummariesamountresponse_transactionsummary)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

## Create the charge based on credit card or previously stored credit card token (J4 deal)

`POST /api/transactions/create`

> Body parameter

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "transactionType": "regularDeal",
  "currency": "ILS",
  "paymentTypeEnum": "card",
  "cardPresence": "cardNotPresent",
  "creditCardSecureDetails": {
    "cvv": "stri",
    "authNum": "string",
    "cardNumber": "stringstr",
    "cardExpiration": {
      "year": 20,
      "month": 1,
      "expired": true
    },
    "cardVendor": "string",
    "cardBrand": "string",
    "solek": "string",
    "cardOwnerName": "string",
    "cardOwnerNationalID": "string",
    "cardReaderInput": "string"
  },
  "bankTransferDetails": {
    "dueDate": "2019-08-24T14:15:22Z",
    "reference": "string",
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "creditCardToken": "8000dee3-fd2b-4f6f-9c2f-678fb99e8ae4",
  "transactionAmount": 0.01,
  "vatRate": 1,
  "vatTotal": 0,
  "netTotal": 0.01,
  "netDiscountTotal": 0,
  "discountTotal": 0,
  "installmentDetails": {
    "numberOfPayments": 1,
    "initialPaymentAmount": 0.01,
    "totalAmount": 0.01,
    "installmentPaymentAmount": 0.01
  },
  "consumerIP": "string",
  "saveCreditCard": true,
  "initialJ5TransactionID": "b1db8f7a-f604-476b-8778-c5d18039cba8",
  "issueInvoice": true,
  "invoiceDetails": {
    "invoiceType": "invoice",
    "invoiceSubject": "string",
    "sendCCTo": [
      "string"
    ],
    "donation": true,
    "invoiceLanguage": "string"
  },
  "pinPad": true,
  "pinPadDeviceID": "string",
  "paymentRequestID": "e1c25505-9cc4-4f14-8180-c89257d3d43a",
  "paymentIntentID": "8962affd-b035-46fc-a6ea-e3666300c228",
  "okNumber": "string",
  "cardOwnerNationalID": "string",
  "cardOwnerName": "string",
  "connectionID": "string",
  "extension": null,
  "threeDSServerTransID": "string",
  "origin": "string",
  "userAmount": true,
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  }
}
```

<h3 id="create-the-charge-based-on-credit-card-or-previously-stored-credit-card-token-(j4-deal)-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[CreateTransactionRequest](#schemacreatetransactionrequest)|false|none|

> Example responses

> 201 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "d9f18253-22c5-4edf-a753-fd1b35ea40c0",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

<h3 id="create-the-charge-based-on-credit-card-or-previously-stored-credit-card-token-(j4-deal)-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Created|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

## Blocking funds on credit card (J5 deal)

`POST /api/transactions/blocking`

> Body parameter

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "currency": "ILS",
  "cardPresence": "cardNotPresent",
  "creditCardSecureDetails": {
    "cvv": "stri",
    "authNum": "string",
    "cardNumber": "stringstr",
    "cardExpiration": {
      "year": 20,
      "month": 1,
      "expired": true
    },
    "cardVendor": "string",
    "cardBrand": "string",
    "solek": "string",
    "cardOwnerName": "string",
    "cardOwnerNationalID": "string",
    "cardReaderInput": "string"
  },
  "creditCardToken": "string",
  "transactionAmount": 0.01,
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  }
}
```

<h3 id="blocking-funds-on-credit-card-(j5-deal)-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[BlockCreditCardRequest](#schemablockcreditcardrequest)|false|none|

> Example responses

> 201 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "ff74f559-b73a-4178-a40d-28b1591c0e07",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

<h3 id="blocking-funds-on-credit-card-(j5-deal)-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Created|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

## Implement J5 deal

`POST /api/transactions/selectJ5/{transactionID}`

<h3 id="implement-j5-deal-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|transactionID|path|string(uuid)|true|none|

> Example responses

> 201 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "64908061-eac8-4ed0-aed6-cd6af268ae47",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

<h3 id="implement-j5-deal-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Created|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

## Check if credit card is valid

`POST /api/transactions/checking`

> Body parameter

```json
{
  "currency": "ILS",
  "cardPresence": "cardNotPresent",
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "creditCardSecureDetails": {
    "cvv": "stri",
    "authNum": "string",
    "cardNumber": "stringstr",
    "cardExpiration": {
      "year": 20,
      "month": 1,
      "expired": true
    },
    "cardVendor": "string",
    "cardBrand": "string",
    "solek": "string",
    "cardOwnerName": "string",
    "cardOwnerNationalID": "string",
    "cardReaderInput": "string"
  },
  "creditCardToken": "string",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  }
}
```

<h3 id="check-if-credit-card-is-valid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[CheckCreditCardRequest](#schemacheckcreditcardrequest)|false|none|

> Example responses

> 201 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "40c18f46-4727-42c4-a18c-50639fa2ca8e",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

<h3 id="check-if-credit-card-is-valid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Created|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

## Refund request

`POST /api/transactions/refund`

> Body parameter

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "currency": "ILS",
  "cardPresence": "cardNotPresent",
  "creditCardSecureDetails": {
    "cvv": "stri",
    "authNum": "string",
    "cardNumber": "stringstr",
    "cardExpiration": {
      "year": 20,
      "month": 1,
      "expired": true
    },
    "cardVendor": "string",
    "cardBrand": "string",
    "solek": "string",
    "cardOwnerName": "string",
    "cardOwnerNationalID": "string",
    "cardReaderInput": "string"
  },
  "creditCardToken": "string",
  "transactionAmount": 0.01,
  "vatRate": 1,
  "vatTotal": 0,
  "netTotal": 0.01,
  "issueInvoice": true,
  "pinPad": true,
  "pinPadDeviceID": "string",
  "invoiceDetails": {
    "invoiceType": "invoice",
    "invoiceSubject": "string",
    "sendCCTo": [
      "string"
    ],
    "donation": true,
    "invoiceLanguage": "string"
  },
  "installmentDetails": {
    "numberOfPayments": 1,
    "initialPaymentAmount": 0.01,
    "totalAmount": 0.01,
    "installmentPaymentAmount": 0.01
  },
  "transactionType": "regularDeal",
  "cardOwnerNationalID": "string",
  "connectionID": "string",
  "okNumber": "string",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  }
}
```

<h3 id="refund-request-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[RefundRequest](#schemarefundrequest)|false|none|

> Example responses

> 201 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "3bf5b990-bccc-4654-bc74-32f185c597c4",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

<h3 id="refund-request-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Created|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_manager_or_admin terminal_or_merchant_frontend_or_admin )
</aside>

## Refund or chargeback of and existing transaction

`POST /api/transactions/chargeback`

> Body parameter

```json
{
  "existingPaymentTransactionID": "2762f298-e9d0-42fb-959a-4f9d92b7ad24",
  "refundAmount": 0.01
}
```

<h3 id="refund-or-chargeback-of-and-existing-transaction-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[ChargebackRequest](#schemachargebackrequest)|false|none|

> Example responses

> 201 Response

```json
{
  "message": "Validation Errors",
  "status": "error",
  "correlationId": "30d75be8-3073-4942-bd2d-587f6ca45aa0",
  "errors": [
    {
      "code": "paymentRequestAmount",
      "description": "Could not convert string to decimal: 1200$. Path 'paymentRequestAmount', line 10, position 33."
    }
  ]
}
```

<h3 id="refund-or-chargeback-of-and-existing-transaction-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Created|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_manager_or_admin terminal_or_merchant_frontend_or_admin )
</aside>

# Webhooks

## Get executed webhooks history

`GET /api/webhooks`

<h3 id="get-executed-webhooks-history-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|TerminalID|query|string(uuid)|false|none|
|Take|query|integer(int32)|false|none|
|Skip|query|integer(int32)|false|none|
|SortBy|query|string|false|none|
|SortDesc|query|boolean|false|none|
|ShowDeleted|query|[ShowDeletedEnum](#schemashowdeletedenum)|false|none|

> Example responses

> 200 Response

```json
{
  "numberOfRecords": 0,
  "data": [
    {
      "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
      "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
      "url": "string",
      "payload": null,
      "correlationId": "string",
      "eventID": "d66eb199-edae-4511-96e7-d2277ccf1d87"
    }
  ]
}
```

<h3 id="get-executed-webhooks-history-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[SummariesResponse_ExecutedWebhookSummary](#schemasummariesresponse_executedwebhooksummary)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend_or_admin )
</aside>

# Schemas

<h2 id="tocS_Address">Address</h2>
<!-- backwards compatibility -->
<a id="schemaaddress"></a>
<a id="schema_Address"></a>
<a id="tocSaddress"></a>
<a id="tocsaddress"></a>

```json
{
  "countryCode": "string",
  "city": "string",
  "zip": "string",
  "street": "string",
  "house": "string",
  "apartment": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|countryCode|string¦null|false|none|none|
|city|string¦null|false|none|none|
|zip|string¦null|false|none|none|
|street|string¦null|false|none|none|
|house|string¦null|false|none|none|
|apartment|string¦null|false|none|none|

<h2 id="tocS_BankDetails">BankDetails</h2>
<!-- backwards compatibility -->
<a id="schemabankdetails"></a>
<a id="schema_BankDetails"></a>
<a id="tocSbankdetails"></a>
<a id="tocsbankdetails"></a>

```json
{
  "bank": 0,
  "bankBranch": 0,
  "bankAccount": "string",
  "paymentType": "card",
  "amount": 0
}

```

For billing deal only. For invoice and payment transaction use <see cref="T:Shared.Integration.Models.PaymentDetails.BankTransferDetails"></see>

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|bank|integer(int32)|true|none|none|
|bankBranch|integer(int32)|true|none|none|
|bankAccount|string|true|none|none|
|paymentType|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|card<br><br>cheque<br><br>cash<br><br>bank|
|amount|number(double)|false|none|none|

<h2 id="tocS_BankTransferDetails">BankTransferDetails</h2>
<!-- backwards compatibility -->
<a id="schemabanktransferdetails"></a>
<a id="schema_BankTransferDetails"></a>
<a id="tocSbanktransferdetails"></a>
<a id="tocsbanktransferdetails"></a>

```json
{
  "dueDate": "2019-08-24T14:15:22Z",
  "reference": "string",
  "bank": 0,
  "bankBranch": 0,
  "bankAccount": "string",
  "paymentType": "card",
  "amount": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|dueDate|string(date-time)¦null|false|none|none|
|reference|string¦null|false|none|none|
|bank|integer(int32)|true|none|none|
|bankBranch|integer(int32)|true|none|none|
|bankAccount|string|true|none|none|
|paymentType|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|card<br><br>cheque<br><br>cash<br><br>bank|
|amount|number(double)|false|none|none|

<h2 id="tocS_BillingDealRequest">BillingDealRequest</h2>
<!-- backwards compatibility -->
<a id="schemabillingdealrequest"></a>
<a id="schema_BillingDealRequest"></a>
<a id="tocSbillingdealrequest"></a>
<a id="tocsbillingdealrequest"></a>

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "currency": "ILS",
  "creditCardToken": "8000dee3-fd2b-4f6f-9c2f-678fb99e8ae4",
  "transactionAmount": 0.01,
  "vatRate": 1,
  "vatTotal": 0,
  "netTotal": 0.01,
  "billingSchedule": {
    "repeatPeriodType": "oneTime",
    "startAtType": "today",
    "startAt": "2019-08-24T14:15:22Z",
    "endAtType": "never",
    "endAt": "2019-08-24T14:15:22Z",
    "endAtNumberOfPayments": 0
  },
  "issueInvoice": true,
  "invoiceDetails": {
    "invoiceType": "invoice",
    "invoiceSubject": "string",
    "sendCCTo": [
      "string"
    ],
    "donation": true,
    "invoiceLanguage": "string"
  },
  "paymentType": "card",
  "bankDetails": {
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "origin": "string",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|terminalID|string(uuid)¦null|false|none|EasyCard terminal reference|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|creditCardToken|string(uuid)¦null|false|none|Stored credit card details token (should be omitted in case if full credit card details used)|
|transactionAmount|number(currency)|false|none|Transaction amount|
|vatRate|number(currency)¦null|false|none|none|
|vatTotal|number(currency)¦null|false|none|none|
|netTotal|number(currency)¦null|false|none|none|
|billingSchedule|[BillingSchedule](#schemabillingschedule)|true|none|none|
|issueInvoice|boolean¦null|false|none|Create document|
|invoiceDetails|[InvoiceDetails](#schemainvoicedetails)|false|none|none|
|paymentType|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|card<br><br>cheque<br><br>cash<br><br>bank|
|bankDetails|[BankDetails](#schemabankdetails)|false|none|For billing deal only. For invoice and payment transaction use <see cref="T:Shared.Integration.Models.PaymentDetails.BankTransferDetails"></see>|
|origin|string¦null|false|none|none|
|dealDetails|[DealDetails](#schemadealdetails)|false|none|Additional deal information. All these data are not required and used only for merchant's business purposes.|

<h2 id="tocS_BillingDealResponse">BillingDealResponse</h2>
<!-- backwards compatibility -->
<a id="schemabillingdealresponse"></a>
<a id="schema_BillingDealResponse"></a>
<a id="tocSbillingdealresponse"></a>
<a id="tocsbillingdealresponse"></a>

```json
{
  "billingDealID": "4cd118ba-cace-48f5-9541-35d080140955",
  "billingDealTimestamp": "2019-08-24T14:15:22Z",
  "initialTransactionID": "7423475c-5ccd-47b4-826d-813710b50fda",
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "terminalName": "string",
  "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
  "currency": "ILS",
  "transactionAmount": 0,
  "amount": 0,
  "totalAmount": 0,
  "currentDeal": 0,
  "currentTransactionTimestamp": "2019-08-24T14:15:22Z",
  "currentTransactionID": "f7afeaec-5e83-460b-a638-9ade74e9b86b",
  "nextScheduledTransaction": "2019-08-24T14:15:22Z",
  "creditCardDetails": {
    "cardNumber": "stringstr",
    "cardExpiration": {
      "year": 20,
      "month": 1,
      "expired": true
    },
    "cardVendor": "string",
    "cardBrand": "string",
    "solek": "string",
    "cardOwnerName": "string",
    "cardOwnerNationalID": "string",
    "cardReaderInput": "string"
  },
  "bankDetails": {
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "creditCardToken": "8000dee3-fd2b-4f6f-9c2f-678fb99e8ae4",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  },
  "billingSchedule": {
    "repeatPeriodType": "oneTime",
    "startAtType": "today",
    "startAt": "2019-08-24T14:15:22Z",
    "endAtType": "never",
    "endAt": "2019-08-24T14:15:22Z",
    "endAtNumberOfPayments": 0
  },
  "updatedDate": "2019-08-24T14:15:22Z",
  "updateTimestamp": "string",
  "operationDoneBy": "string",
  "operationDoneByID": "b010a171-b6bb-4a84-8fe6-c777ac1f46ec",
  "correlationId": "string",
  "sourceIP": "string",
  "active": true,
  "cardExpired": true,
  "tokenNotAvailable": true,
  "invoiceDetails": {
    "invoiceType": "invoice",
    "invoiceSubject": "string",
    "sendCCTo": [
      "string"
    ],
    "donation": true,
    "invoiceLanguage": "string"
  },
  "issueInvoice": true,
  "invoiceOnly": true,
  "vatRate": 0,
  "vatTotal": 0,
  "netTotal": 0,
  "pausedFrom": "2019-08-24T14:15:22Z",
  "pausedTo": "2019-08-24T14:15:22Z",
  "paused": true,
  "paymentType": "card",
  "lastError": "string",
  "lastErrorCorrelationID": "string",
  "paymentDetails": [
    {
      "paymentType": "card",
      "amount": 0
    }
  ],
  "failedAttemptsCount": 0,
  "expirationEmailSent": "2019-08-24T14:15:22Z",
  "tokenUpdated": "2019-08-24T14:15:22Z",
  "tokenCreated": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|billingDealID|string(uuid)|false|none|Primary transaction reference|
|billingDealTimestamp|string(date-time)¦null|false|none|Date-time when deal created initially in UTC|
|initialTransactionID|string(uuid)¦null|false|none|Reference to initial transaction|
|terminalID|string(uuid)¦null|false|none|Terminal|
|terminalName|string¦null|false|none|EasyCard terminal name|
|merchantID|string(uuid)¦null|false|none|Merchant|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|transactionAmount|number(double)|false|none|This transaction amount|
|amount|number(double)|false|none|none|
|totalAmount|number(double)|false|none|TotalAmount = TransactionAmount * NumberOfPayments|
|currentDeal|integer(int32)¦null|false|none|Current deal (billing)|
|currentTransactionTimestamp|string(date-time)¦null|false|none|Date-time when last created initially in UTC|
|currentTransactionID|string(uuid)¦null|false|none|Reference to last deal|
|nextScheduledTransaction|string(date-time)¦null|false|none|Date-time when next transaction should be generated|
|creditCardDetails|[CreditCardDetails](#schemacreditcarddetails)|false|none|Does not store full card number. Used 123456****1234 pattern|
|bankDetails|[BankDetails](#schemabankdetails)|false|none|For billing deal only. For invoice and payment transaction use <see cref="T:Shared.Integration.Models.PaymentDetails.BankTransferDetails"></see>|
|creditCardToken|string(uuid)¦null|false|none|Stored credit card details token|
|dealDetails|[DealDetails](#schemadealdetails)|false|none|Additional deal information. All these data are not required and used only for merchant's business purposes.|
|billingSchedule|[BillingSchedule](#schemabillingschedule)|false|none|none|
|updatedDate|string(date-time)¦null|false|none|Date-time when transaction status updated|
|updateTimestamp|string(byte)¦null|false|none|Concurrency key|
|operationDoneBy|string¦null|false|none|none|
|operationDoneByID|string(uuid)¦null|false|none|none|
|correlationId|string¦null|false|none|none|
|sourceIP|string¦null|false|none|none|
|active|boolean|false|none|none|
|cardExpired|boolean¦null|false|none|none|
|tokenNotAvailable|boolean¦null|false|none|none|
|invoiceDetails|[InvoiceDetails](#schemainvoicedetails)|false|none|none|
|issueInvoice|boolean|false|none|Create document for transaction|
|invoiceOnly|boolean|false|none|none|
|vatRate|number(double)|false|none|none|
|vatTotal|number(double)|false|none|none|
|netTotal|number(double)|false|none|none|
|pausedFrom|string(date-time)¦null|false|none|none|
|pausedTo|string(date-time)¦null|false|none|none|
|paused|boolean|false|none|none|
|paymentType|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|card<br><br>cheque<br><br>cash<br><br>bank|
|lastError|string¦null|false|none|none|
|lastErrorCorrelationID|string¦null|false|none|none|
|paymentDetails|[[PaymentDetails](#schemapaymentdetails)]¦null|false|none|none|
|failedAttemptsCount|integer(int32)¦null|false|none|none|
|expirationEmailSent|string(date-time)¦null|false|none|none|
|tokenUpdated|string(date-time)¦null|false|none|none|
|tokenCreated|string(date-time)¦null|false|none|none|

<h2 id="tocS_BillingDealSummary">BillingDealSummary</h2>
<!-- backwards compatibility -->
<a id="schemabillingdealsummary"></a>
<a id="schema_BillingDealSummary"></a>
<a id="tocSbillingdealsummary"></a>
<a id="tocsbillingdealsummary"></a>

```json
{
  "billingDealID": "4cd118ba-cace-48f5-9541-35d080140955",
  "terminalName": "string",
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
  "transactionAmount": 0,
  "currency": "ILS",
  "billingDealTimestamp": "2019-08-24T14:15:22Z",
  "nextScheduledTransaction": "2019-08-24T14:15:22Z",
  "currentTransactionTimestamp": "2019-08-24T14:15:22Z",
  "consumerName": "string",
  "billingSchedule": {
    "repeatPeriodType": "oneTime",
    "startAtType": "today",
    "startAt": "2019-08-24T14:15:22Z",
    "endAtType": "never",
    "endAt": "2019-08-24T14:15:22Z",
    "endAtNumberOfPayments": 0
  },
  "cardNumber": "string",
  "cardExpired": true,
  "active": true,
  "currentDeal": 0,
  "pausedFrom": "2019-08-24T14:15:22Z",
  "pausedTo": "2019-08-24T14:15:22Z",
  "paused": true,
  "paymentType": "card",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  },
  "invoiceOnly": true,
  "creditCardToken": "8000dee3-fd2b-4f6f-9c2f-678fb99e8ae4",
  "consumerExternalReference": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|billingDealID|string(uuid)|false|none|none|
|terminalName|string¦null|false|none|none|
|terminalID|string(uuid)|false|none|none|
|merchantID|string(uuid)|false|none|none|
|transactionAmount|number(double)|false|none|none|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|billingDealTimestamp|string(date-time)¦null|false|none|none|
|nextScheduledTransaction|string(date-time)¦null|false|none|none|
|currentTransactionTimestamp|string(date-time)¦null|false|none|Date-time when last created initially in UTC|
|consumerName|string¦null|false|none|none|
|billingSchedule|[BillingSchedule](#schemabillingschedule)|false|none|none|
|cardNumber|string¦null|false|none|none|
|cardExpired|boolean¦null|false|none|none|
|active|boolean|false|none|none|
|currentDeal|integer(int32)¦null|false|none|none|
|pausedFrom|string(date-time)¦null|false|none|none|
|pausedTo|string(date-time)¦null|false|none|none|
|paused|boolean|false|none|none|
|paymentType|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|card<br><br>cheque<br><br>cash<br><br>bank|
|dealDetails|[DealDetails](#schemadealdetails)|false|none|Additional deal information. All these data are not required and used only for merchant's business purposes.|
|invoiceOnly|boolean|false|none|none|
|creditCardToken|string(uuid)¦null|false|none|Stored credit card details token|
|consumerExternalReference|string¦null|false|none|none|

<h2 id="tocS_BillingDealTypeEnum">BillingDealTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemabillingdealtypeenum"></a>
<a id="schema_BillingDealTypeEnum"></a>
<a id="tocSbillingdealtypeenum"></a>
<a id="tocsbillingdealtypeenum"></a>

```json
"CreditCard"

```

CreditCard

InvoiceOnly

Bank

<h2 id="tocS_BillingDealUpdateRequest">BillingDealUpdateRequest</h2>
<!-- backwards compatibility -->
<a id="schemabillingdealupdaterequest"></a>
<a id="schema_BillingDealUpdateRequest"></a>
<a id="tocSbillingdealupdaterequest"></a>
<a id="tocsbillingdealupdaterequest"></a>

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "currency": "ILS",
  "creditCardToken": "8000dee3-fd2b-4f6f-9c2f-678fb99e8ae4",
  "transactionAmount": 0.01,
  "vatRate": 1,
  "vatTotal": 0,
  "netTotal": 0.01,
  "billingSchedule": {
    "repeatPeriodType": "oneTime",
    "startAtType": "today",
    "startAt": "2019-08-24T14:15:22Z",
    "endAtType": "never",
    "endAt": "2019-08-24T14:15:22Z",
    "endAtNumberOfPayments": 0
  },
  "issueInvoice": true,
  "invoiceDetails": {
    "invoiceType": "invoice",
    "invoiceSubject": "string",
    "sendCCTo": [
      "string"
    ],
    "donation": true,
    "invoiceLanguage": "string"
  },
  "paymentType": "card",
  "bankDetails": {
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|terminalID|string(uuid)¦null|false|none|EasyCard terminal reference|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|creditCardToken|string(uuid)¦null|false|none|Stored credit card details token (should be omitted in case if full credit card details used)|
|transactionAmount|number(currency)|false|none|Transaction amount|
|vatRate|number(currency)¦null|false|none|none|
|vatTotal|number(currency)¦null|false|none|none|
|netTotal|number(currency)¦null|false|none|none|
|billingSchedule|[BillingSchedule](#schemabillingschedule)|false|none|none|
|issueInvoice|boolean¦null|false|none|none|
|invoiceDetails|[InvoiceDetails](#schemainvoicedetails)|false|none|none|
|paymentType|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|card<br><br>cheque<br><br>cash<br><br>bank|
|bankDetails|[BankDetails](#schemabankdetails)|false|none|For billing deal only. For invoice and payment transaction use <see cref="T:Shared.Integration.Models.PaymentDetails.BankTransferDetails"></see>|
|dealDetails|[DealDetails](#schemadealdetails)|false|none|Additional deal information. All these data are not required and used only for merchant's business purposes.|

<h2 id="tocS_BillingSchedule">BillingSchedule</h2>
<!-- backwards compatibility -->
<a id="schemabillingschedule"></a>
<a id="schema_BillingSchedule"></a>
<a id="tocSbillingschedule"></a>
<a id="tocsbillingschedule"></a>

```json
{
  "repeatPeriodType": "oneTime",
  "startAtType": "today",
  "startAt": "2019-08-24T14:15:22Z",
  "endAtType": "never",
  "endAt": "2019-08-24T14:15:22Z",
  "endAtNumberOfPayments": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|repeatPeriodType|[RepeatPeriodTypeEnum](#schemarepeatperiodtypeenum)|false|none|oneTime<br><br>monthly<br><br>biMonthly<br><br>quarter<br><br>halfYear<br><br>year|
|startAtType|[StartAtTypeEnum](#schemastartattypeenum)|false|none|today<br><br>specifiedDate|
|startAt|string(date-time)¦null|false|none|none|
|endAtType|[EndAtTypeEnum](#schemaendattypeenum)|false|none|never<br><br>specifiedDate<br><br>afterNumberOfPayments|
|endAt|string(date-time)¦null|false|none|none|
|endAtNumberOfPayments|integer(int32)¦null|false|none|none|

<h2 id="tocS_BillingsQuickStatusFilterEnum">BillingsQuickStatusFilterEnum</h2>
<!-- backwards compatibility -->
<a id="schemabillingsquickstatusfilterenum"></a>
<a id="schema_BillingsQuickStatusFilterEnum"></a>
<a id="tocSbillingsquickstatusfilterenum"></a>
<a id="tocsbillingsquickstatusfilterenum"></a>

```json
"All"

```

All

Completed

Inactive

Failed

CardExpired

TriggeredTomorrow

Paused

ExpiredNextMonth

ManualTrigger

InProgress

<h2 id="tocS_BlockCreditCardRequest">BlockCreditCardRequest</h2>
<!-- backwards compatibility -->
<a id="schemablockcreditcardrequest"></a>
<a id="schema_BlockCreditCardRequest"></a>
<a id="tocSblockcreditcardrequest"></a>
<a id="tocsblockcreditcardrequest"></a>

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "currency": "ILS",
  "cardPresence": "cardNotPresent",
  "creditCardSecureDetails": {
    "cvv": "stri",
    "authNum": "string",
    "cardNumber": "stringstr",
    "cardExpiration": {
      "year": 20,
      "month": 1,
      "expired": true
    },
    "cardVendor": "string",
    "cardBrand": "string",
    "solek": "string",
    "cardOwnerName": "string",
    "cardOwnerNationalID": "string",
    "cardReaderInput": "string"
  },
  "creditCardToken": "string",
  "transactionAmount": 0.01,
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  }
}

```

Blocking funds on credit card

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|terminalID|string(uuid)|true|none|EasyCard terminal reference|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|cardPresence|[CardPresenceEnum](#schemacardpresenceenum)|false|none|Is the card physically scanned<br><br>cardNotPresent<br><br>regular<br><br>Internet|
|creditCardSecureDetails|[CreditCardSecureDetails](#schemacreditcardsecuredetails)|false|none|none|
|creditCardToken|string¦null|false|none|Stored credit card details token (should be omitted in case if full credit card details used)|
|transactionAmount|number(currency)|true|none|Transaction amount|
|dealDetails|[DealDetails](#schemadealdetails)|false|none|Additional deal information. All these data are not required and used only for merchant's business purposes.|

<h2 id="tocS_CardExpiration">CardExpiration</h2>
<!-- backwards compatibility -->
<a id="schemacardexpiration"></a>
<a id="schema_CardExpiration"></a>
<a id="tocScardexpiration"></a>
<a id="tocscardexpiration"></a>

```json
{
  "year": 20,
  "month": 1,
  "expired": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|year|integer(int32)|true|none|none|
|month|integer(int32)|true|none|none|
|expired|boolean|false|none|none|

<h2 id="tocS_CardPresenceEnum">CardPresenceEnum</h2>
<!-- backwards compatibility -->
<a id="schemacardpresenceenum"></a>
<a id="schema_CardPresenceEnum"></a>
<a id="tocScardpresenceenum"></a>
<a id="tocscardpresenceenum"></a>

```json
"cardNotPresent"

```

Is the card physically scanned

cardNotPresent

regular

Internet

<h2 id="tocS_ChargebackRequest">ChargebackRequest</h2>
<!-- backwards compatibility -->
<a id="schemachargebackrequest"></a>
<a id="schema_ChargebackRequest"></a>
<a id="tocSchargebackrequest"></a>
<a id="tocschargebackrequest"></a>

```json
{
  "existingPaymentTransactionID": "2762f298-e9d0-42fb-959a-4f9d92b7ad24",
  "refundAmount": 0.01
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|existingPaymentTransactionID|string(uuid)|true|none|none|
|refundAmount|number(currency)|true|none|none|

<h2 id="tocS_CheckCreditCardRequest">CheckCreditCardRequest</h2>
<!-- backwards compatibility -->
<a id="schemacheckcreditcardrequest"></a>
<a id="schema_CheckCreditCardRequest"></a>
<a id="tocScheckcreditcardrequest"></a>
<a id="tocscheckcreditcardrequest"></a>

```json
{
  "currency": "ILS",
  "cardPresence": "cardNotPresent",
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "creditCardSecureDetails": {
    "cvv": "stri",
    "authNum": "string",
    "cardNumber": "stringstr",
    "cardExpiration": {
      "year": 20,
      "month": 1,
      "expired": true
    },
    "cardVendor": "string",
    "cardBrand": "string",
    "solek": "string",
    "cardOwnerName": "string",
    "cardOwnerNationalID": "string",
    "cardReaderInput": "string"
  },
  "creditCardToken": "string",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  }
}

```

Check if credit card is valid

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|cardPresence|[CardPresenceEnum](#schemacardpresenceenum)|false|none|Is the card physically scanned<br><br>cardNotPresent<br><br>regular<br><br>Internet|
|terminalID|string(uuid)|true|none|EasyCard terminal reference|
|creditCardSecureDetails|[CreditCardSecureDetails](#schemacreditcardsecuredetails)|false|none|none|
|creditCardToken|string¦null|false|none|Stored credit card details token (should be omitted in case if full credit card details used)|
|dealDetails|[DealDetails](#schemadealdetails)|false|none|Additional deal information. All these data are not required and used only for merchant's business purposes.|

<h2 id="tocS_CreateTransactionRequest">CreateTransactionRequest</h2>
<!-- backwards compatibility -->
<a id="schemacreatetransactionrequest"></a>
<a id="schema_CreateTransactionRequest"></a>
<a id="tocScreatetransactionrequest"></a>
<a id="tocscreatetransactionrequest"></a>

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "transactionType": "regularDeal",
  "currency": "ILS",
  "paymentTypeEnum": "card",
  "cardPresence": "cardNotPresent",
  "creditCardSecureDetails": {
    "cvv": "stri",
    "authNum": "string",
    "cardNumber": "stringstr",
    "cardExpiration": {
      "year": 20,
      "month": 1,
      "expired": true
    },
    "cardVendor": "string",
    "cardBrand": "string",
    "solek": "string",
    "cardOwnerName": "string",
    "cardOwnerNationalID": "string",
    "cardReaderInput": "string"
  },
  "bankTransferDetails": {
    "dueDate": "2019-08-24T14:15:22Z",
    "reference": "string",
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "creditCardToken": "8000dee3-fd2b-4f6f-9c2f-678fb99e8ae4",
  "transactionAmount": 0.01,
  "vatRate": 1,
  "vatTotal": 0,
  "netTotal": 0.01,
  "netDiscountTotal": 0,
  "discountTotal": 0,
  "installmentDetails": {
    "numberOfPayments": 1,
    "initialPaymentAmount": 0.01,
    "totalAmount": 0.01,
    "installmentPaymentAmount": 0.01
  },
  "consumerIP": "string",
  "saveCreditCard": true,
  "initialJ5TransactionID": "b1db8f7a-f604-476b-8778-c5d18039cba8",
  "issueInvoice": true,
  "invoiceDetails": {
    "invoiceType": "invoice",
    "invoiceSubject": "string",
    "sendCCTo": [
      "string"
    ],
    "donation": true,
    "invoiceLanguage": "string"
  },
  "pinPad": true,
  "pinPadDeviceID": "string",
  "paymentRequestID": "e1c25505-9cc4-4f14-8180-c89257d3d43a",
  "paymentIntentID": "8962affd-b035-46fc-a6ea-e3666300c228",
  "okNumber": "string",
  "cardOwnerNationalID": "string",
  "cardOwnerName": "string",
  "connectionID": "string",
  "extension": null,
  "threeDSServerTransID": "string",
  "origin": "string",
  "userAmount": true,
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  }
}

```

Create the charge based on credit card or previously stored credit card token

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|terminalID|string(uuid)|true|none|EasyCard terminal reference|
|transactionType|[TransactionTypeEnum](#schematransactiontypeenum)|false|none|Generic transaction type<br><br>regularDeal (Simple deal type)<br><br>installments (Deal to pay by parts)<br><br>credit (Credit deal)<br><br>immediate (Credit deal)|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|paymentTypeEnum|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|card<br><br>cheque<br><br>cash<br><br>bank|
|cardPresence|[CardPresenceEnum](#schemacardpresenceenum)|false|none|Is the card physically scanned<br><br>cardNotPresent<br><br>regular<br><br>Internet|
|creditCardSecureDetails|[CreditCardSecureDetails](#schemacreditcardsecuredetails)|false|none|none|
|bankTransferDetails|[BankTransferDetails](#schemabanktransferdetails)|false|none|none|
|creditCardToken|string(uuid)¦null|false|none|Stored credit card details token (should be omitted in case if full credit card details used)|
|transactionAmount|number(currency)|false|none|Transaction amount. Must always be specified. In case of Installments must match InstallmentDetails.TotalAmount|
|vatRate|number(currency)¦null|false|none|none|
|vatTotal|number(currency)¦null|false|none|none|
|netTotal|number(currency)¦null|false|none|none|
|netDiscountTotal|number(currency)¦null|false|none|none|
|discountTotal|number(currency)¦null|false|none|none|
|installmentDetails|[InstallmentDetails](#schemainstallmentdetails)|false|none|Installment payments details|
|consumerIP|string¦null|false|none|Original consumer IP|
|saveCreditCard|boolean¦null|false|none|Save credit card from request.<br>Requires Feature CreditCardTokens to be enabled.|
|initialJ5TransactionID|string(uuid)¦null|false|none|Reference to initial transaction|
|issueInvoice|boolean¦null|false|none|Create document|
|invoiceDetails|[InvoiceDetails](#schemainvoicedetails)|false|none|none|
|pinPad|boolean¦null|false|none|Create Pinpad Transaction|
|pinPadDeviceID|string¦null|false|none|Pinpad device in case of terminal with multiple devices|
|paymentRequestID|string(uuid)¦null|false|none|none|
|paymentIntentID|string(uuid)¦null|false|none|none|
|okNumber|string¦null|false|none|none|
|cardOwnerNationalID|string¦null|false|none|Only to be used for pin pad transactions when CreditCardSecureDetails is not available|
|cardOwnerName|string¦null|false|none|Only to be used for pin pad transactions when CreditCardSecureDetails is not available|
|connectionID|string¦null|false|none|SignalR connection id|
|extension|any|false|none|none|
|threeDSServerTransID|string¦null|false|none|none|
|origin|string¦null|false|none|none|
|userAmount|boolean|false|none|none|
|dealDetails|[DealDetails](#schemadealdetails)|false|none|Additional deal information. All these data are not required and used only for merchant's business purposes.|

<h2 id="tocS_CreditCardDetails">CreditCardDetails</h2>
<!-- backwards compatibility -->
<a id="schemacreditcarddetails"></a>
<a id="schema_CreditCardDetails"></a>
<a id="tocScreditcarddetails"></a>
<a id="tocscreditcarddetails"></a>

```json
{
  "cardNumber": "stringstr",
  "cardExpiration": {
    "year": 20,
    "month": 1,
    "expired": true
  },
  "cardVendor": "string",
  "cardBrand": "string",
  "solek": "string",
  "cardOwnerName": "string",
  "cardOwnerNationalID": "string",
  "cardReaderInput": "string"
}

```

Does not store full card number. Used 123456****1234 pattern

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|cardNumber|string|true|none|none|
|cardExpiration|[CardExpiration](#schemacardexpiration)|true|none|none|
|cardVendor|string¦null|false|none|none|
|cardBrand|string¦null|false|none|none|
|solek|string¦null|false|none|none|
|cardOwnerName|string¦null|false|none|none|
|cardOwnerNationalID|string¦null|false|none|none|
|cardReaderInput|string¦null|false|none|none|

<h2 id="tocS_CreditCardSecureDetails">CreditCardSecureDetails</h2>
<!-- backwards compatibility -->
<a id="schemacreditcardsecuredetails"></a>
<a id="schema_CreditCardSecureDetails"></a>
<a id="tocScreditcardsecuredetails"></a>
<a id="tocscreditcardsecuredetails"></a>

```json
{
  "cvv": "stri",
  "authNum": "string",
  "cardNumber": "stringstr",
  "cardExpiration": {
    "year": 20,
    "month": 1,
    "expired": true
  },
  "cardVendor": "string",
  "cardBrand": "string",
  "solek": "string",
  "cardOwnerName": "string",
  "cardOwnerNationalID": "string",
  "cardReaderInput": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|cvv|string¦null|false|none|none|
|authNum|string¦null|false|none|after code 3 or 4 user can insert this value from credit company|
|cardNumber|string|true|none|none|
|cardExpiration|[CardExpiration](#schemacardexpiration)|true|none|none|
|cardVendor|string¦null|false|none|none|
|cardBrand|string¦null|false|none|none|
|solek|string¦null|false|none|none|
|cardOwnerName|string¦null|false|none|none|
|cardOwnerNationalID|string¦null|false|none|none|
|cardReaderInput|string¦null|false|none|none|

<h2 id="tocS_CreditCardTokenSummary">CreditCardTokenSummary</h2>
<!-- backwards compatibility -->
<a id="schemacreditcardtokensummary"></a>
<a id="schema_CreditCardTokenSummary"></a>
<a id="tocScreditcardtokensummary"></a>
<a id="tocscreditcardtokensummary"></a>

```json
{
  "creditCardTokenID": "f6aae4d3-a111-4061-86e5-728917783b8c",
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
  "cardNumber": "string",
  "cardExpiration": {
    "year": 20,
    "month": 1,
    "expired": true
  },
  "cardVendor": "string",
  "created": "2019-08-24T14:15:22Z",
  "cardOwnerName": "string",
  "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
  "consumerEmail": "string",
  "expired": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|creditCardTokenID|string(uuid)¦null|false|none|none|
|terminalID|string(uuid)¦null|false|none|none|
|merchantID|string(uuid)¦null|false|none|none|
|cardNumber|string¦null|false|none|none|
|cardExpiration|[CardExpiration](#schemacardexpiration)|false|none|none|
|cardVendor|string¦null|false|none|none|
|created|string(date-time)¦null|false|none|none|
|cardOwnerName|string¦null|false|none|none|
|consumerID|string(uuid)¦null|false|none|Consumer ID|
|consumerEmail|string¦null|false|none|End-customer Email|
|expired|boolean|false|none|none|

<h2 id="tocS_CurrencyEnum">CurrencyEnum</h2>
<!-- backwards compatibility -->
<a id="schemacurrencyenum"></a>
<a id="schema_CurrencyEnum"></a>
<a id="tocScurrencyenum"></a>
<a id="tocscurrencyenum"></a>

```json
"ILS"

```

ILS

USD

EUR

<h2 id="tocS_DealDetails">DealDetails</h2>
<!-- backwards compatibility -->
<a id="schemadealdetails"></a>
<a id="schema_DealDetails"></a>
<a id="tocSdealdetails"></a>
<a id="tocsdealdetails"></a>

```json
{
  "dealReference": "string",
  "dealDescription": "string",
  "consumerEmail": "user@example.com",
  "consumerName": "string",
  "consumerNationalID": "string",
  "consumerPhone": "string",
  "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
  "items": [
    {
      "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
      "externalReference": "string",
      "itemName": "string",
      "sku": "string",
      "price": 0,
      "netPrice": 0,
      "quantity": 0.01,
      "amount": 0,
      "vatRate": 1,
      "vat": 0,
      "netAmount": 0,
      "discount": 0,
      "netDiscount": 0,
      "extension": null,
      "woocommerceID": "string",
      "ecwidID": "string"
    }
  ],
  "consumerAddress": {
    "countryCode": "string",
    "city": "string",
    "zip": "string",
    "street": "string",
    "house": "string",
    "apartment": "string"
  },
  "consumerExternalReference": "string",
  "consumerWoocommerceID": "string",
  "consumerEcwidID": "string",
  "responsiblePerson": "string",
  "externalUserID": "string",
  "branch": "string",
  "department": "string"
}

```

Additional deal information. All these data are not required and used only for merchant's business purposes.

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|dealReference|string¦null|false|none|Deal identifier in merchant's system|
|dealDescription|string¦null|false|none|Deal description. In case of generating payment link, these description will be displayed on Checkout Page|
|consumerEmail|string(email)¦null|false|none|End-customer Email|
|consumerName|string¦null|false|none|End-customer Name|
|consumerNationalID|string¦null|false|none|End-customer National Id|
|consumerPhone|string¦null|false|none|End-customer Phone|
|consumerID|string(uuid)¦null|false|none|End-customer record UUId in EasyCard system|
|items|[[Item](#schemaitem)]¦null|false|none|Deal Items<br>ID, Count, Name|
|consumerAddress|[Address](#schemaaddress)|false|none|none|
|consumerExternalReference|string¦null|false|none|External system consumer identifier for example RapidOne customer code|
|consumerWoocommerceID|string¦null|false|none|none|
|consumerEcwidID|string¦null|false|none|none|
|responsiblePerson|string¦null|false|none|External responsible person|
|externalUserID|string¦null|false|none|External user id|
|branch|string¦null|false|none|External branch|
|department|string¦null|false|none|External department|

<h2 id="tocS_DocumentOriginEnum">DocumentOriginEnum</h2>
<!-- backwards compatibility -->
<a id="schemadocumentoriginenum"></a>
<a id="schema_DocumentOriginEnum"></a>
<a id="tocSdocumentoriginenum"></a>
<a id="tocsdocumentoriginenum"></a>

```json
"UI"

```

Document origin (primarely payment transaction origin)

UI (Document created manually by merchant user using Merchant's UI)

API (Document created via API)

checkout (Document created by consumer using Checkout Page)

billing (Document generated based on billing schedule)

device (Transaction created using pinpad device (or other device))

paymentRequest (Document created by consumer using Checkout Page with a payment link)

bit (Document created by consumer using Bit)

<h2 id="tocS_EndAtTypeEnum">EndAtTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemaendattypeenum"></a>
<a id="schema_EndAtTypeEnum"></a>
<a id="tocSendattypeenum"></a>
<a id="tocsendattypeenum"></a>

```json
"never"

```

never

specifiedDate

afterNumberOfPayments

<h2 id="tocS_Error">Error</h2>
<!-- backwards compatibility -->
<a id="schemaerror"></a>
<a id="schema_Error"></a>
<a id="tocSerror"></a>
<a id="tocserror"></a>

```json
{
  "code": "string",
  "description": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|code|string¦null|false|none|none|
|description|string¦null|false|none|none|

<h2 id="tocS_ExecutedWebhookSummary">ExecutedWebhookSummary</h2>
<!-- backwards compatibility -->
<a id="schemaexecutedwebhooksummary"></a>
<a id="schema_ExecutedWebhookSummary"></a>
<a id="tocSexecutedwebhooksummary"></a>
<a id="tocsexecutedwebhooksummary"></a>

```json
{
  "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "url": "string",
  "payload": null,
  "correlationId": "string",
  "eventID": "d66eb199-edae-4511-96e7-d2277ccf1d87"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|merchantID|string(uuid)¦null|false|none|none|
|terminalID|string(uuid)¦null|false|none|none|
|url|string¦null|false|none|none|
|payload|any|false|none|none|
|correlationId|string¦null|false|none|none|
|eventID|string(uuid)¦null|false|none|none|

<h2 id="tocS_InstallmentDetails">InstallmentDetails</h2>
<!-- backwards compatibility -->
<a id="schemainstallmentdetails"></a>
<a id="schema_InstallmentDetails"></a>
<a id="tocSinstallmentdetails"></a>
<a id="tocsinstallmentdetails"></a>

```json
{
  "numberOfPayments": 1,
  "initialPaymentAmount": 0.01,
  "totalAmount": 0.01,
  "installmentPaymentAmount": 0.01
}

```

Installment payments details

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|numberOfPayments|integer(int32)|true|none|Number Of Installments|
|initialPaymentAmount|number(currency)|true|none|Initial installment payment|
|totalAmount|number(currency)|true|none|TotalAmount = InitialPaymentAmount + (NumberOfInstallments - 1) * InstallmentPaymentAmount|
|installmentPaymentAmount|number(currency)|true|none|Amount of each additional payments|

<h2 id="tocS_InvoiceDetails">InvoiceDetails</h2>
<!-- backwards compatibility -->
<a id="schemainvoicedetails"></a>
<a id="schema_InvoiceDetails"></a>
<a id="tocSinvoicedetails"></a>
<a id="tocsinvoicedetails"></a>

```json
{
  "invoiceType": "invoice",
  "invoiceSubject": "string",
  "sendCCTo": [
    "string"
  ],
  "donation": true,
  "invoiceLanguage": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|invoiceType|[InvoiceTypeEnum](#schemainvoicetypeenum)|false|none|invoice<br><br>invoiceWithPaymentInfo<br><br>creditNote<br><br>paymentInfo<br><br>refundInvoice|
|invoiceSubject|string¦null|false|none|none|
|sendCCTo|[string]¦null|false|none|none|
|donation|boolean|false|none|none|
|invoiceLanguage|string¦null|false|none|none|

<h2 id="tocS_InvoiceTypeEnum">InvoiceTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemainvoicetypeenum"></a>
<a id="schema_InvoiceTypeEnum"></a>
<a id="tocSinvoicetypeenum"></a>
<a id="tocsinvoicetypeenum"></a>

```json
"invoice"

```

invoice

invoiceWithPaymentInfo

creditNote

paymentInfo

refundInvoice

<h2 id="tocS_Item">Item</h2>
<!-- backwards compatibility -->
<a id="schemaitem"></a>
<a id="schema_Item"></a>
<a id="tocSitem"></a>
<a id="tocsitem"></a>

```json
{
  "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
  "externalReference": "string",
  "itemName": "string",
  "sku": "string",
  "price": 0,
  "netPrice": 0,
  "quantity": 0.01,
  "amount": 0,
  "vatRate": 1,
  "vat": 0,
  "netAmount": 0,
  "discount": 0,
  "netDiscount": 0,
  "extension": null,
  "woocommerceID": "string",
  "ecwidID": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|itemID|string(uuid)¦null|false|none|none|
|externalReference|string¦null|false|none|none|
|itemName|string|true|none|none|
|sku|string¦null|false|none|none|
|price|number(double)¦null|false|none|none|
|netPrice|number(double)¦null|false|none|none|
|quantity|number(currency)¦null|false|none|none|
|amount|number(currency)¦null|false|none|Row amount|
|vatRate|number(currency)¦null|false|none|VAT Rate|
|vat|number(currency)¦null|false|none|VAT amount|
|netAmount|number(currency)¦null|false|none|Net amount (before VAT)|
|discount|number(currency)¦null|false|none|Discount|
|netDiscount|number(currency)¦null|false|none|Discount|
|extension|any|false|none|none|
|woocommerceID|string¦null|false|none|External ID inside https://woocommerce.com system|
|ecwidID|string¦null|false|none|External ID inside https://www.ecwid.com system|

<h2 id="tocS_JDealTypeEnum">JDealTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemajdealtypeenum"></a>
<a id="schema_JDealTypeEnum"></a>
<a id="tocSjdealtypeenum"></a>
<a id="tocsjdealtypeenum"></a>

```json
"J4"

```

Type of Deal. optional values are; J2 for Check,J4 for Charge, J5 for Block card

J4 (Regular deal)

J2 (Check)

J5 (Block card)

<h2 id="tocS_OperationResponse">OperationResponse</h2>
<!-- backwards compatibility -->
<a id="schemaoperationresponse"></a>
<a id="schema_OperationResponse"></a>
<a id="tocSoperationresponse"></a>
<a id="tocsoperationresponse"></a>

```json
{
  "message": "string",
  "status": "success",
  "entityID": 0,
  "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
  "entityReference": "string",
  "correlationId": "string",
  "entityType": "string",
  "errors": [
    {
      "code": "string",
      "description": "string"
    }
  ],
  "concurrencyToken": "string",
  "innerResponse": {
    "message": "string",
    "status": "success",
    "entityID": 0,
    "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
    "entityReference": "string",
    "correlationId": "string",
    "entityType": "string",
    "errors": [
      {
        "code": "string",
        "description": "string"
      }
    ],
    "concurrencyToken": "string",
    "innerResponse": {},
    "additionalData": null
  },
  "additionalData": null
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|message|string¦null|false|none|none|
|status|[StatusEnum](#schemastatusenum)|false|none|success<br><br>warning<br><br>error|
|entityID|integer(int64)¦null|false|none|none|
|entityUID|string(uuid)¦null|false|none|none|
|entityReference|string¦null|false|none|none|
|correlationId|string¦null|false|none|none|
|entityType|string¦null|false|none|none|
|errors|[[Error](#schemaerror)]¦null|false|none|none|
|concurrencyToken|string¦null|false|none|none|
|innerResponse|[OperationResponse](#schemaoperationresponse)|false|none|none|
|additionalData|any|false|none|none|

<h2 id="tocS_PayReqQuickStatusFilterTypeEnum">PayReqQuickStatusFilterTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemapayreqquickstatusfiltertypeenum"></a>
<a id="schema_PayReqQuickStatusFilterTypeEnum"></a>
<a id="tocSpayreqquickstatusfiltertypeenum"></a>
<a id="tocspayreqquickstatusfiltertypeenum"></a>

```json
"pending"

```

pending

completed

failed

canceled

overdue

viewed

<h2 id="tocS_PaymentDetails">PaymentDetails</h2>
<!-- backwards compatibility -->
<a id="schemapaymentdetails"></a>
<a id="schema_PaymentDetails"></a>
<a id="tocSpaymentdetails"></a>
<a id="tocspaymentdetails"></a>

```json
{
  "paymentType": "card",
  "amount": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|paymentType|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|card<br><br>cheque<br><br>cash<br><br>bank|
|amount|number(double)|false|none|none|

<h2 id="tocS_PaymentRequestCreate">PaymentRequestCreate</h2>
<!-- backwards compatibility -->
<a id="schemapaymentrequestcreate"></a>
<a id="schema_PaymentRequestCreate"></a>
<a id="tocSpaymentrequestcreate"></a>
<a id="tocspaymentrequestcreate"></a>

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  },
  "currency": "ILS",
  "paymentRequestAmount": 0,
  "dueDate": "2019-08-24T14:15:22Z",
  "transactionType": "regularDeal",
  "installmentDetails": {
    "numberOfPayments": 1,
    "initialPaymentAmount": 0.01,
    "totalAmount": 0.01,
    "installmentPaymentAmount": 0.01
  },
  "invoiceDetails": {
    "invoiceType": "invoice",
    "invoiceSubject": "string",
    "sendCCTo": [
      "string"
    ],
    "donation": true,
    "invoiceLanguage": "string"
  },
  "pinPadDetails": {
    "terminalID": "string"
  },
  "issueInvoice": true,
  "allowPinPad": true,
  "vatRate": 1,
  "vatTotal": 0,
  "netDiscountTotal": 0,
  "discountTotal": 0,
  "netTotal": 0,
  "requestSubject": "string",
  "fromAddress": "string",
  "isRefund": true,
  "redirectUrl": "string",
  "userAmount": true,
  "cardOwnerNationalID": "string",
  "extension": null,
  "language": "string",
  "origin": "string",
  "allowInstallments": true,
  "allowCredit": true,
  "allowImmediate": true,
  "hidePhone": true,
  "hideEmail": true,
  "hideNationalID": true,
  "showAuthCode": true
}

```

Create a link to Checkout Page

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|terminalID|string(uuid)¦null|false|none|EasyCard Terminal|
|dealDetails|[DealDetails](#schemadealdetails)|false|none|Additional deal information. All these data are not required and used only for merchant's business purposes.|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|paymentRequestAmount|number(currency)¦null|false|none|Deal amount including VAT. This amount will be displayed on Checkout Page. Consumer can override this amount in case if UserAmount flag specified.|
|dueDate|string(date-time)¦null|false|none|Due date of payment link|
|transactionType|[TransactionTypeEnum](#schematransactiontypeenum)|false|none|Generic transaction type<br><br>regularDeal (Simple deal type)<br><br>installments (Deal to pay by parts)<br><br>credit (Credit deal)<br><br>immediate (Credit deal)|
|installmentDetails|[InstallmentDetails](#schemainstallmentdetails)|false|none|Installment payments details|
|invoiceDetails|[InvoiceDetails](#schemainvoicedetails)|false|none|none|
|pinPadDetails|[PinPadDetails](#schemapinpaddetails)|false|none|none|
|issueInvoice|boolean¦null|false|none|Create document - Invoice, Receipt etc. If omitted, default terminal settings will be used|
|allowPinPad|boolean¦null|false|none|Enables PinPad button on checkout page|
|vatRate|number(currency)¦null|false|none|Deal tax rate. Can be omitted if only PaymentRequestAmount specified - in this case VAT rate from terminal settings will be used|
|vatTotal|number(currency)¦null|false|none|Total deal tax amount. VATTotal = NetTotal * VATRate. Can be omitted if only PaymentRequestAmount specified|
|netDiscountTotal|number(currency)¦null|false|none|none|
|discountTotal|number(currency)¦null|false|none|none|
|netTotal|number(currency)¦null|false|none|Deal amount before tax. PaymentRequestAmount = NetTotal + VATTotal. Can be omitted if only PaymentRequestAmount specified|
|requestSubject|string¦null|false|none|You can override default email subject When sending payment link via email|
|fromAddress|string¦null|false|none|You can override "from" address subject When sending payment link via email|
|isRefund|boolean|false|none|Generate link to Checkout Page to create refund|
|redirectUrl|string¦null|false|none|Url to merchant's web site. Base url should be configured in terminal settings. You can add any details to query string.|
|userAmount|boolean|false|none|Consumer can override PaymentRequestAmount|
|cardOwnerNationalID|string¦null|false|none|none|
|extension|any|false|none|Any advanced payload which will be stored in EasyCard and then can be obtained using "GetTransaction"|
|language|string¦null|false|none|Default language to display checkout page|
|origin|string¦null|false|none|none|
|allowInstallments|boolean¦null|false|none|none|
|allowCredit|boolean¦null|false|none|none|
|allowImmediate|boolean¦null|false|none|none|
|hidePhone|boolean¦null|false|none|none|
|hideEmail|boolean¦null|false|none|none|
|hideNationalID|boolean¦null|false|none|none|
|showAuthCode|boolean¦null|false|none|none|

<h2 id="tocS_PaymentRequestHistorySummary">PaymentRequestHistorySummary</h2>
<!-- backwards compatibility -->
<a id="schemapaymentrequesthistorysummary"></a>
<a id="schema_PaymentRequestHistorySummary"></a>
<a id="tocSpaymentrequesthistorysummary"></a>
<a id="tocspaymentrequesthistorysummary"></a>

```json
{
  "paymentRequestHistoryID": "a27f677d-9bac-4614-b73b-38acec040a90",
  "operationDate": "2019-08-24T14:15:22Z",
  "operationDoneBy": "string",
  "operationCode": "PaymentRequestCreated",
  "operationMessage": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|paymentRequestHistoryID|string(uuid)|false|none|none|
|operationDate|string(date-time)¦null|false|none|none|
|operationDoneBy|string¦null|false|none|none|
|operationCode|[PaymentRequestOperationCodesEnum](#schemapaymentrequestoperationcodesenum)|false|none|PaymentRequestCreated<br><br>PaymentRequestUpdated<br><br>PaymentRequestSent<br><br>PaymentRequestCanceled<br><br>PaymentRequestViewed<br><br>PaymentRequestRejected<br><br>PaymentRequestPaymentFailed<br><br>PaymentRequestPayed|
|operationMessage|string¦null|false|none|none|

<h2 id="tocS_PaymentRequestOperationCodesEnum">PaymentRequestOperationCodesEnum</h2>
<!-- backwards compatibility -->
<a id="schemapaymentrequestoperationcodesenum"></a>
<a id="schema_PaymentRequestOperationCodesEnum"></a>
<a id="tocSpaymentrequestoperationcodesenum"></a>
<a id="tocspaymentrequestoperationcodesenum"></a>

```json
"PaymentRequestCreated"

```

PaymentRequestCreated

PaymentRequestUpdated

PaymentRequestSent

PaymentRequestCanceled

PaymentRequestViewed

PaymentRequestRejected

PaymentRequestPaymentFailed

PaymentRequestPayed

<h2 id="tocS_PaymentRequestResponse">PaymentRequestResponse</h2>
<!-- backwards compatibility -->
<a id="schemapaymentrequestresponse"></a>
<a id="schema_PaymentRequestResponse"></a>
<a id="tocSpaymentrequestresponse"></a>
<a id="tocspaymentrequestresponse"></a>

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "terminalName": "string",
  "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
  "paymentTransactionID": "19fb5b03-41a8-4687-a896-97851484218b",
  "paymentRequestUrl": "string",
  "history": [
    {
      "paymentRequestHistoryID": "a27f677d-9bac-4614-b73b-38acec040a90",
      "operationDate": "2019-08-24T14:15:22Z",
      "operationDoneBy": "string",
      "operationCode": "PaymentRequestCreated",
      "operationMessage": "string"
    }
  ],
  "userPaidDetails": {
    "vatRate": 0,
    "vatTotal": 0,
    "netTotal": 0,
    "transactionAmount": 0
  },
  "amount": 0,
  "origin": "string",
  "paymentRequestID": "e1c25505-9cc4-4f14-8180-c89257d3d43a",
  "paymentRequestTimestamp": "2019-08-24T14:15:22Z",
  "dueDate": "2019-08-24T14:15:22Z",
  "currency": "ILS",
  "status": "initial",
  "quickStatus": "pending",
  "cardOwnerName": "string",
  "cardOwnerNationalID": "string",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  },
  "vatRate": 0,
  "vatTotal": 0,
  "netTotal": 0,
  "numberOfPayments": 0,
  "initialPaymentAmount": 0,
  "totalAmount": 0,
  "installmentPaymentAmount": 0,
  "paymentRequestAmount": 0,
  "isRefund": true,
  "userAmount": true,
  "redirectUrl": "string",
  "onlyAddCard": true,
  "showAuthCode": true,
  "transactionType": "regularDeal"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|terminalID|string(uuid)¦null|false|none|Terminal|
|terminalName|string¦null|false|none|EasyCard terminal name|
|consumerID|string(uuid)¦null|false|none|none|
|paymentTransactionID|string(uuid)¦null|false|none|none|
|paymentRequestUrl|string¦null|false|none|none|
|history|[[PaymentRequestHistorySummary](#schemapaymentrequesthistorysummary)]¦null|false|none|none|
|userPaidDetails|[PaymentRequestUserPaidDetails](#schemapaymentrequestuserpaiddetails)|false|none|Information regarding what user actually paid in payment request (only relevant for UserAmount allowed PRs)|
|amount|number(double)|false|none|none|
|origin|string¦null|false|none|none|
|paymentRequestID|string(uuid)|false|none|Primary reference|
|paymentRequestTimestamp|string(date-time)¦null|false|none|Date-time when deal created initially in UTC|
|dueDate|string(date-time)¦null|false|none|Due date|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|status|[PaymentRequestStatusEnum](#schemapaymentrequeststatusenum)|false|none|initial<br><br>sending<br><br>sent<br><br>viewed<br><br>payed<br><br>paymentFailed<br><br>rejected<br><br>canceled<br><br>sendingFailed|
|quickStatus|[PayReqQuickStatusFilterTypeEnum](#schemapayreqquickstatusfiltertypeenum)|false|none|pending<br><br>completed<br><br>failed<br><br>canceled<br><br>overdue<br><br>viewed|
|cardOwnerName|string¦null|false|none|none|
|cardOwnerNationalID|string¦null|false|none|none|
|dealDetails|[DealDetails](#schemadealdetails)|false|none|Additional deal information. All these data are not required and used only for merchant's business purposes.|
|vatRate|number(double)|false|none|none|
|vatTotal|number(double)|false|none|none|
|netTotal|number(double)|false|none|none|
|numberOfPayments|integer(int32)|false|none|Number Of payments (cannot be more than 999)|
|initialPaymentAmount|number(double)|false|none|Initial installment payment|
|totalAmount|number(double)|false|none|TotalAmount = InitialPaymentAmount + (NumberOfInstallments - 1) * InstallmentPaymentAmount|
|installmentPaymentAmount|number(double)|false|none|Amount of one instalment payment|
|paymentRequestAmount|number(double)|false|none|This amount|
|isRefund|boolean|false|none|none|
|userAmount|boolean|false|none|none|
|redirectUrl|string¦null|false|none|none|
|onlyAddCard|boolean|false|read-only|none|
|showAuthCode|boolean¦null|false|none|none|
|transactionType|[TransactionTypeEnum](#schematransactiontypeenum)|false|none|Generic transaction type<br><br>regularDeal (Simple deal type)<br><br>installments (Deal to pay by parts)<br><br>credit (Credit deal)<br><br>immediate (Credit deal)|

<h2 id="tocS_PaymentRequestStatusEnum">PaymentRequestStatusEnum</h2>
<!-- backwards compatibility -->
<a id="schemapaymentrequeststatusenum"></a>
<a id="schema_PaymentRequestStatusEnum"></a>
<a id="tocSpaymentrequeststatusenum"></a>
<a id="tocspaymentrequeststatusenum"></a>

```json
"initial"

```

initial

sending

sent

viewed

payed

paymentFailed

rejected

canceled

sendingFailed

<h2 id="tocS_PaymentRequestSummary">PaymentRequestSummary</h2>
<!-- backwards compatibility -->
<a id="schemapaymentrequestsummary"></a>
<a id="schema_PaymentRequestSummary"></a>
<a id="tocSpaymentrequestsummary"></a>
<a id="tocspaymentrequestsummary"></a>

```json
{
  "paymentRequestID": "e1c25505-9cc4-4f14-8180-c89257d3d43a",
  "paymentRequestTimestamp": "2019-08-24T14:15:22Z",
  "dueDate": "2019-08-24T14:15:22Z",
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "status": "initial",
  "quickStatus": "pending",
  "currency": "ILS",
  "paymentRequestAmount": 0,
  "cardOwnerName": "string",
  "consumerEmail": "string",
  "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
  "paymentTransactionID": "19fb5b03-41a8-4687-a896-97851484218b",
  "isRefund": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|paymentRequestID|string(uuid)|false|none|Primary reference|
|paymentRequestTimestamp|string(date-time)¦null|false|none|Date-time when deal created initially in UTC|
|dueDate|string(date-time)¦null|false|none|Due date|
|terminalID|string(uuid)¦null|false|none|Terminal|
|status|[PaymentRequestStatusEnum](#schemapaymentrequeststatusenum)|false|none|initial<br><br>sending<br><br>sent<br><br>viewed<br><br>payed<br><br>paymentFailed<br><br>rejected<br><br>canceled<br><br>sendingFailed|
|quickStatus|[PayReqQuickStatusFilterTypeEnum](#schemapayreqquickstatusfiltertypeenum)|false|none|pending<br><br>completed<br><br>failed<br><br>canceled<br><br>overdue<br><br>viewed|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|paymentRequestAmount|number(double)¦null|false|none|none|
|cardOwnerName|string¦null|false|none|none|
|consumerEmail|string¦null|false|none|none|
|consumerID|string(uuid)¦null|false|none|none|
|paymentTransactionID|string(uuid)¦null|false|none|none|
|isRefund|boolean|false|none|none|

<h2 id="tocS_PaymentRequestUserPaidDetails">PaymentRequestUserPaidDetails</h2>
<!-- backwards compatibility -->
<a id="schemapaymentrequestuserpaiddetails"></a>
<a id="schema_PaymentRequestUserPaidDetails"></a>
<a id="tocSpaymentrequestuserpaiddetails"></a>
<a id="tocspaymentrequestuserpaiddetails"></a>

```json
{
  "vatRate": 0,
  "vatTotal": 0,
  "netTotal": 0,
  "transactionAmount": 0
}

```

Information regarding what user actually paid in payment request (only relevant for UserAmount allowed PRs)

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|vatRate|number(double)|false|none|none|
|vatTotal|number(double)|false|none|none|
|netTotal|number(double)|false|none|none|
|transactionAmount|number(double)|false|none|none|

<h2 id="tocS_PaymentTypeEnum">PaymentTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemapaymenttypeenum"></a>
<a id="schema_PaymentTypeEnum"></a>
<a id="tocSpaymenttypeenum"></a>
<a id="tocspaymenttypeenum"></a>

```json
"card"

```

card

cheque

cash

bank

<h2 id="tocS_PinPadDetails">PinPadDetails</h2>
<!-- backwards compatibility -->
<a id="schemapinpaddetails"></a>
<a id="schema_PinPadDetails"></a>
<a id="tocSpinpaddetails"></a>
<a id="tocspinpaddetails"></a>

```json
{
  "terminalID": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|terminalID|string¦null|false|none|none|

<h2 id="tocS_PropertyPresenceEnum">PropertyPresenceEnum</h2>
<!-- backwards compatibility -->
<a id="schemapropertypresenceenum"></a>
<a id="schema_PropertyPresenceEnum"></a>
<a id="tocSpropertypresenceenum"></a>
<a id="tocspropertypresenceenum"></a>

```json
"All"

```

All

Yes

No

<h2 id="tocS_QuickDateFilterTypeEnum">QuickDateFilterTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemaquickdatefiltertypeenum"></a>
<a id="schema_QuickDateFilterTypeEnum"></a>
<a id="tocSquickdatefiltertypeenum"></a>
<a id="tocsquickdatefiltertypeenum"></a>

```json
"today"

```

today

yesterday

thisWeek

lastWeek

last30Days

thisMonth

lastMonth

last3Months

<h2 id="tocS_QuickStatusFilterTypeEnum">QuickStatusFilterTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemaquickstatusfiltertypeenum"></a>
<a id="schema_QuickStatusFilterTypeEnum"></a>
<a id="tocSquickstatusfiltertypeenum"></a>
<a id="tocsquickstatusfiltertypeenum"></a>

```json
"Pending"

```

Pending

Completed

Failed

Canceled

AwaitingForTransmission

Chargeback

<h2 id="tocS_RefundRequest">RefundRequest</h2>
<!-- backwards compatibility -->
<a id="schemarefundrequest"></a>
<a id="schema_RefundRequest"></a>
<a id="tocSrefundrequest"></a>
<a id="tocsrefundrequest"></a>

```json
{
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "currency": "ILS",
  "cardPresence": "cardNotPresent",
  "creditCardSecureDetails": {
    "cvv": "stri",
    "authNum": "string",
    "cardNumber": "stringstr",
    "cardExpiration": {
      "year": 20,
      "month": 1,
      "expired": true
    },
    "cardVendor": "string",
    "cardBrand": "string",
    "solek": "string",
    "cardOwnerName": "string",
    "cardOwnerNationalID": "string",
    "cardReaderInput": "string"
  },
  "creditCardToken": "string",
  "transactionAmount": 0.01,
  "vatRate": 1,
  "vatTotal": 0,
  "netTotal": 0.01,
  "issueInvoice": true,
  "pinPad": true,
  "pinPadDeviceID": "string",
  "invoiceDetails": {
    "invoiceType": "invoice",
    "invoiceSubject": "string",
    "sendCCTo": [
      "string"
    ],
    "donation": true,
    "invoiceLanguage": "string"
  },
  "installmentDetails": {
    "numberOfPayments": 1,
    "initialPaymentAmount": 0.01,
    "totalAmount": 0.01,
    "installmentPaymentAmount": 0.01
  },
  "transactionType": "regularDeal",
  "cardOwnerNationalID": "string",
  "connectionID": "string",
  "okNumber": "string",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  }
}

```

Refund request

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|terminalID|string(uuid)|true|none|EasyCard terminal reference|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|cardPresence|[CardPresenceEnum](#schemacardpresenceenum)|false|none|Is the card physically scanned<br><br>cardNotPresent<br><br>regular<br><br>Internet|
|creditCardSecureDetails|[CreditCardSecureDetails](#schemacreditcardsecuredetails)|false|none|none|
|creditCardToken|string¦null|false|none|Stored credit card details token (should be omitted in case if full credit card details used)|
|transactionAmount|number(currency)|true|none|Refund amount|
|vatRate|number(currency)¦null|false|none|none|
|vatTotal|number(currency)¦null|false|none|none|
|netTotal|number(currency)¦null|false|none|none|
|issueInvoice|boolean¦null|false|none|Create document|
|pinPad|boolean¦null|false|none|Create Pinpad Transaction|
|pinPadDeviceID|string¦null|false|none|Pinpad device in case of terminal with multiple devices|
|invoiceDetails|[InvoiceDetails](#schemainvoicedetails)|false|none|none|
|installmentDetails|[InstallmentDetails](#schemainstallmentdetails)|false|none|Installment payments details|
|transactionType|[TransactionTypeEnum](#schematransactiontypeenum)|false|none|Generic transaction type<br><br>regularDeal (Simple deal type)<br><br>installments (Deal to pay by parts)<br><br>credit (Credit deal)<br><br>immediate (Credit deal)|
|cardOwnerNationalID|string¦null|false|none|Only to be used for pin pad transactions when CredotCardSecureDetails is not available|
|connectionID|string¦null|false|none|SignalR connection id|
|okNumber|string¦null|false|none|ShvaAuthNum|
|dealDetails|[DealDetails](#schemadealdetails)|false|none|Additional deal information. All these data are not required and used only for merchant's business purposes.|

<h2 id="tocS_RejectionReasonEnum">RejectionReasonEnum</h2>
<!-- backwards compatibility -->
<a id="schemarejectionreasonenum"></a>
<a id="schema_RejectionReasonEnum"></a>
<a id="tocSrejectionreasonenum"></a>
<a id="tocsrejectionreasonenum"></a>

```json
"unknown"

```

unknown

creditCardIsMerchantsCard

nationalIdIsMerchantsId

singleTransactionAmountExceeded

dailyAmountExceeded

creditCardDailyUsageExceeded

refundNotMatchRegularAmount

refundExceededCollateral

cardOwnerNationalIdRequired

authCodeRequired

<h2 id="tocS_RepeatPeriodTypeEnum">RepeatPeriodTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemarepeatperiodtypeenum"></a>
<a id="schema_RepeatPeriodTypeEnum"></a>
<a id="tocSrepeatperiodtypeenum"></a>
<a id="tocsrepeatperiodtypeenum"></a>

```json
"oneTime"

```

oneTime

monthly

biMonthly

quarter

halfYear

year

<h2 id="tocS_ShowDeletedEnum">ShowDeletedEnum</h2>
<!-- backwards compatibility -->
<a id="schemashowdeletedenum"></a>
<a id="schema_ShowDeletedEnum"></a>
<a id="tocSshowdeletedenum"></a>
<a id="tocsshowdeletedenum"></a>

```json
"OnlyActive"

```

OnlyActive

OnlyDeleted

All

<h2 id="tocS_SolekEnum">SolekEnum</h2>
<!-- backwards compatibility -->
<a id="schemasolekenum"></a>
<a id="schema_SolekEnum"></a>
<a id="tocSsolekenum"></a>
<a id="tocssolekenum"></a>

```json
"UNKNOWN"

```

UNKNOWN

ISRACARD

VISA

DINERS_CLUB

AMEX

JCB

DISCOVER

LEUMI_CARD

OTHER

MASTERCARD

<h2 id="tocS_SpecialTransactionTypeEnum">SpecialTransactionTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemaspecialtransactiontypeenum"></a>
<a id="schema_SpecialTransactionTypeEnum"></a>
<a id="tocSspecialtransactiontypeenum"></a>
<a id="tocsspecialtransactiontypeenum"></a>

```json
"regularDeal"

```

regularDeal

initialDeal

refund

<h2 id="tocS_StartAtTypeEnum">StartAtTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemastartattypeenum"></a>
<a id="schema_StartAtTypeEnum"></a>
<a id="tocSstartattypeenum"></a>
<a id="tocsstartattypeenum"></a>

```json
"today"

```

today

specifiedDate

<h2 id="tocS_StatusEnum">StatusEnum</h2>
<!-- backwards compatibility -->
<a id="schemastatusenum"></a>
<a id="schema_StatusEnum"></a>
<a id="tocSstatusenum"></a>
<a id="tocsstatusenum"></a>

```json
"success"

```

success

warning

error

<h2 id="tocS_SummariesAmountResponse_BillingDealSummary">SummariesAmountResponse_BillingDealSummary</h2>
<!-- backwards compatibility -->
<a id="schemasummariesamountresponse_billingdealsummary"></a>
<a id="schema_SummariesAmountResponse_BillingDealSummary"></a>
<a id="tocSsummariesamountresponse_billingdealsummary"></a>
<a id="tocssummariesamountresponse_billingdealsummary"></a>

```json
{
  "totalAmountILS": 0,
  "totalAmountUSD": 0,
  "totalAmountEUR": 0,
  "numberOfRecords": 0,
  "data": [
    {
      "billingDealID": "4cd118ba-cace-48f5-9541-35d080140955",
      "terminalName": "string",
      "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
      "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
      "transactionAmount": 0,
      "currency": "ILS",
      "billingDealTimestamp": "2019-08-24T14:15:22Z",
      "nextScheduledTransaction": "2019-08-24T14:15:22Z",
      "currentTransactionTimestamp": "2019-08-24T14:15:22Z",
      "consumerName": "string",
      "billingSchedule": {
        "repeatPeriodType": "oneTime",
        "startAtType": "today",
        "startAt": "2019-08-24T14:15:22Z",
        "endAtType": "never",
        "endAt": "2019-08-24T14:15:22Z",
        "endAtNumberOfPayments": 0
      },
      "cardNumber": "string",
      "cardExpired": true,
      "active": true,
      "currentDeal": 0,
      "pausedFrom": "2019-08-24T14:15:22Z",
      "pausedTo": "2019-08-24T14:15:22Z",
      "paused": true,
      "paymentType": "card",
      "dealDetails": {
        "dealReference": "string",
        "dealDescription": "string",
        "consumerEmail": "user@example.com",
        "consumerName": "string",
        "consumerNationalID": "string",
        "consumerPhone": "string",
        "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
        "items": [
          {
            "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
            "externalReference": "string",
            "itemName": "string",
            "sku": "string",
            "price": 0,
            "netPrice": 0,
            "quantity": 0.01,
            "amount": 0,
            "vatRate": 1,
            "vat": 0,
            "netAmount": 0,
            "discount": 0,
            "netDiscount": 0,
            "extension": null,
            "woocommerceID": "string",
            "ecwidID": "string"
          }
        ],
        "consumerAddress": {
          "countryCode": "string",
          "city": "string",
          "zip": "string",
          "street": "string",
          "house": "string",
          "apartment": "string"
        },
        "consumerExternalReference": "string",
        "consumerWoocommerceID": "string",
        "consumerEcwidID": "string",
        "responsiblePerson": "string",
        "externalUserID": "string",
        "branch": "string",
        "department": "string"
      },
      "invoiceOnly": true,
      "creditCardToken": "8000dee3-fd2b-4f6f-9c2f-678fb99e8ae4",
      "consumerExternalReference": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|totalAmountILS|number(double)¦null|false|none|none|
|totalAmountUSD|number(double)¦null|false|none|none|
|totalAmountEUR|number(double)¦null|false|none|none|
|numberOfRecords|integer(int32)|false|none|none|
|data|[[BillingDealSummary](#schemabillingdealsummary)]¦null|false|none|none|

<h2 id="tocS_SummariesAmountResponse_PaymentRequestSummary">SummariesAmountResponse_PaymentRequestSummary</h2>
<!-- backwards compatibility -->
<a id="schemasummariesamountresponse_paymentrequestsummary"></a>
<a id="schema_SummariesAmountResponse_PaymentRequestSummary"></a>
<a id="tocSsummariesamountresponse_paymentrequestsummary"></a>
<a id="tocssummariesamountresponse_paymentrequestsummary"></a>

```json
{
  "totalAmountILS": 0,
  "totalAmountUSD": 0,
  "totalAmountEUR": 0,
  "numberOfRecords": 0,
  "data": [
    {
      "paymentRequestID": "e1c25505-9cc4-4f14-8180-c89257d3d43a",
      "paymentRequestTimestamp": "2019-08-24T14:15:22Z",
      "dueDate": "2019-08-24T14:15:22Z",
      "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
      "status": "initial",
      "quickStatus": "pending",
      "currency": "ILS",
      "paymentRequestAmount": 0,
      "cardOwnerName": "string",
      "consumerEmail": "string",
      "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
      "paymentTransactionID": "19fb5b03-41a8-4687-a896-97851484218b",
      "isRefund": true
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|totalAmountILS|number(double)¦null|false|none|none|
|totalAmountUSD|number(double)¦null|false|none|none|
|totalAmountEUR|number(double)¦null|false|none|none|
|numberOfRecords|integer(int32)|false|none|none|
|data|[[PaymentRequestSummary](#schemapaymentrequestsummary)]¦null|false|none|none|

<h2 id="tocS_SummariesAmountResponse_TransactionSummary">SummariesAmountResponse_TransactionSummary</h2>
<!-- backwards compatibility -->
<a id="schemasummariesamountresponse_transactionsummary"></a>
<a id="schema_SummariesAmountResponse_TransactionSummary"></a>
<a id="tocSsummariesamountresponse_transactionsummary"></a>
<a id="tocssummariesamountresponse_transactionsummary"></a>

```json
{
  "totalAmountILS": 0,
  "totalAmountUSD": 0,
  "totalAmountEUR": 0,
  "numberOfRecords": 0,
  "data": [
    {
      "paymentTransactionID": "19fb5b03-41a8-4687-a896-97851484218b",
      "terminalName": "string",
      "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
      "documentOrigin": "UI",
      "cardNumber": "string",
      "rejectionMessage": "string",
      "processorResultCode": 0,
      "transactionAmount": 0,
      "initialPaymentAmount": 0,
      "installmentPaymentAmount": 0,
      "transactionType": "regularDeal",
      "currency": "ILS",
      "transactionTimestamp": "2019-08-24T14:15:22Z",
      "status": "initial",
      "paymentTypeEnum": "card",
      "quickStatus": "Pending",
      "specialTransactionType": "regularDeal",
      "jDealType": "J4",
      "rejectionReason": "unknown",
      "cardPresence": "cardNotPresent",
      "cardOwnerName": "string",
      "consumerExternalReference": "string",
      "shvaDealID": "string",
      "invoiceID": "4f03a727-9c4b-43a5-b699-271a3e6fdc9c",
      "dealDescription": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|totalAmountILS|number(double)¦null|false|none|none|
|totalAmountUSD|number(double)¦null|false|none|none|
|totalAmountEUR|number(double)¦null|false|none|none|
|numberOfRecords|integer(int32)|false|none|none|
|data|[[TransactionSummary](#schematransactionsummary)]¦null|false|none|none|

<h2 id="tocS_SummariesResponse_CreditCardTokenSummary">SummariesResponse_CreditCardTokenSummary</h2>
<!-- backwards compatibility -->
<a id="schemasummariesresponse_creditcardtokensummary"></a>
<a id="schema_SummariesResponse_CreditCardTokenSummary"></a>
<a id="tocSsummariesresponse_creditcardtokensummary"></a>
<a id="tocssummariesresponse_creditcardtokensummary"></a>

```json
{
  "numberOfRecords": 0,
  "data": [
    {
      "creditCardTokenID": "f6aae4d3-a111-4061-86e5-728917783b8c",
      "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
      "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
      "cardNumber": "string",
      "cardExpiration": {
        "year": 20,
        "month": 1,
        "expired": true
      },
      "cardVendor": "string",
      "created": "2019-08-24T14:15:22Z",
      "cardOwnerName": "string",
      "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
      "consumerEmail": "string",
      "expired": true
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|numberOfRecords|integer(int32)|false|none|none|
|data|[[CreditCardTokenSummary](#schemacreditcardtokensummary)]¦null|false|none|none|

<h2 id="tocS_SummariesResponse_ExecutedWebhookSummary">SummariesResponse_ExecutedWebhookSummary</h2>
<!-- backwards compatibility -->
<a id="schemasummariesresponse_executedwebhooksummary"></a>
<a id="schema_SummariesResponse_ExecutedWebhookSummary"></a>
<a id="tocSsummariesresponse_executedwebhooksummary"></a>
<a id="tocssummariesresponse_executedwebhooksummary"></a>

```json
{
  "numberOfRecords": 0,
  "data": [
    {
      "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
      "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
      "url": "string",
      "payload": null,
      "correlationId": "string",
      "eventID": "d66eb199-edae-4511-96e7-d2277ccf1d87"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|numberOfRecords|integer(int32)|false|none|none|
|data|[[ExecutedWebhookSummary](#schemaexecutedwebhooksummary)]¦null|false|none|none|

<h2 id="tocS_TransactionFinalizationStatusEnum">TransactionFinalizationStatusEnum</h2>
<!-- backwards compatibility -->
<a id="schematransactionfinalizationstatusenum"></a>
<a id="schema_TransactionFinalizationStatusEnum"></a>
<a id="tocStransactionfinalizationstatusenum"></a>
<a id="tocstransactionfinalizationstatusenum"></a>

```json
"initial"

```

initial

failedToCancelByAggregator

canceledByAggregator

<h2 id="tocS_TransactionResponse">TransactionResponse</h2>
<!-- backwards compatibility -->
<a id="schematransactionresponse"></a>
<a id="schema_TransactionResponse"></a>
<a id="tocStransactionresponse"></a>
<a id="tocstransactionresponse"></a>

```json
{
  "paymentTransactionID": "19fb5b03-41a8-4687-a896-97851484218b",
  "transactionDate": "2019-08-24T14:15:22Z",
  "transactionTimestamp": "2019-08-24T14:15:22Z",
  "initialTransactionID": "7423475c-5ccd-47b4-826d-813710b50fda",
  "currentDeal": 0,
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "terminalName": "string",
  "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
  "status": "initial",
  "paymentTypeEnum": "card",
  "quickStatus": "Pending",
  "finalizationStatus": "initial",
  "transactionType": "regularDeal",
  "specialTransactionType": "regularDeal",
  "jDealType": "J4",
  "transactionJ5ExpiredDate": "2019-08-24T14:15:22Z",
  "rejectionReason": "unknown",
  "currency": "ILS",
  "cardPresence": "cardNotPresent",
  "numberOfPayments": 0,
  "transactionAmount": 0,
  "amount": 0,
  "initialPaymentAmount": 0,
  "totalAmount": 0,
  "installmentPaymentAmount": 0,
  "creditCardDetails": {
    "cardNumber": "stringstr",
    "cardExpiration": {
      "year": 20,
      "month": 1,
      "expired": true
    },
    "cardVendor": "string",
    "cardBrand": "string",
    "solek": "string",
    "cardOwnerName": "string",
    "cardOwnerNationalID": "string",
    "cardReaderInput": "string"
  },
  "bankTransferDetails": {
    "dueDate": "2019-08-24T14:15:22Z",
    "reference": "string",
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "creditCardToken": "string",
  "dealDetails": {
    "dealReference": "string",
    "dealDescription": "string",
    "consumerEmail": "user@example.com",
    "consumerName": "string",
    "consumerNationalID": "string",
    "consumerPhone": "string",
    "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
    "items": [
      {
        "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
        "externalReference": "string",
        "itemName": "string",
        "sku": "string",
        "price": 0,
        "netPrice": 0,
        "quantity": 0.01,
        "amount": 0,
        "vatRate": 1,
        "vat": 0,
        "netAmount": 0,
        "discount": 0,
        "netDiscount": 0,
        "extension": null,
        "woocommerceID": "string",
        "ecwidID": "string"
      }
    ],
    "consumerAddress": {
      "countryCode": "string",
      "city": "string",
      "zip": "string",
      "street": "string",
      "house": "string",
      "apartment": "string"
    },
    "consumerExternalReference": "string",
    "consumerWoocommerceID": "string",
    "consumerEcwidID": "string",
    "responsiblePerson": "string",
    "externalUserID": "string",
    "branch": "string",
    "department": "string"
  },
  "shvaTransactionDetails": null,
  "clearingHouseTransactionDetails": null,
  "upayTransactionDetails": null,
  "updatedDate": "2019-08-24T14:15:22Z",
  "updateTimestamp": "string",
  "billingDealID": "4cd118ba-cace-48f5-9541-35d080140955",
  "rejectionMessage": "string",
  "vatRate": 0,
  "vatTotal": 0,
  "netTotal": 0,
  "consumerIP": "string",
  "merchantIP": "string",
  "correlationId": "string",
  "invoiceID": "4f03a727-9c4b-43a5-b699-271a3e6fdc9c",
  "issueInvoice": true,
  "documentOrigin": "UI",
  "paymentRequestID": "e1c25505-9cc4-4f14-8180-c89257d3d43a",
  "processorResultCode": 0,
  "extension": null,
  "bitTransactionDetails": null,
  "totalRefund": 0,
  "origin": "string",
  "allowTransmission": true,
  "allowTransmissionCancellation": true,
  "allowRefund": true,
  "allowInvoiceCreation": true,
  "merchantName": "string",
  "paymentIntentID": "8962affd-b035-46fc-a6ea-e3666300c228"
}

```

Payment transaction details

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|paymentTransactionID|string(uuid)|false|none|Primary transaction reference (UUId)|
|transactionDate|string(date-time)¦null|false|none|Legal transaction day|
|transactionTimestamp|string(date-time)¦null|false|none|Date-time when transaction created initially in UTC|
|initialTransactionID|string(uuid)¦null|false|none|Reference to initial billing deal|
|currentDeal|integer(int32)¦null|false|none|Current deal number (billing)|
|terminalID|string(uuid)¦null|false|none|EasyCard terminal UUId|
|terminalName|string¦null|false|none|EasyCard terminal name|
|merchantID|string(uuid)¦null|false|none|Merchant|
|status|[TransactionStatusEnum](#schematransactionstatusenum)|false|none|initial<br><br>confirmedByAggregator<br><br>confirmedByPinpadPreProcessor<br><br>confirmedByProcessor<br><br>awaitingForTransmission<br><br>transmissionInProgress<br><br>transmissionCancelingInProgress<br><br>completed<br><br>awaitingToSelectJ5<br><br>chargeback<br><br>chargebackFailed<br><br>transmissionToProcessorFailed<br><br>failedToCommitByAggregator<br><br>failedToConfirmByProcesor<br><br>failedToConfirmByAggregator<br><br>cancelledByMerchant<br><br>rejectedByProcessor<br><br>rejectedByAggregator<br><br>rejectedBy3Dsecure|
|paymentTypeEnum|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|card<br><br>cheque<br><br>cash<br><br>bank|
|quickStatus|[QuickStatusFilterTypeEnum](#schemaquickstatusfiltertypeenum)|false|none|Pending<br><br>Completed<br><br>Failed<br><br>Canceled<br><br>AwaitingForTransmission<br><br>Chargeback|
|finalizationStatus|[TransactionFinalizationStatusEnum](#schematransactionfinalizationstatusenum)|false|none|initial<br><br>failedToCancelByAggregator<br><br>canceledByAggregator|
|transactionType|[TransactionTypeEnum](#schematransactiontypeenum)|false|none|Generic transaction type<br><br>regularDeal (Simple deal type)<br><br>installments (Deal to pay by parts)<br><br>credit (Credit deal)<br><br>immediate (Credit deal)|
|specialTransactionType|[SpecialTransactionTypeEnum](#schemaspecialtransactiontypeenum)|false|none|regularDeal<br><br>initialDeal<br><br>refund|
|jDealType|[JDealTypeEnum](#schemajdealtypeenum)|false|none|Type of Deal. optional values are; J2 for Check,J4 for Charge, J5 for Block card<br><br>J4 (Regular deal)<br><br>J2 (Check)<br><br>J5 (Block card)|
|transactionJ5ExpiredDate|string(date-time)¦null|false|none|Transaction J5 expired date (in gengeral after 1 day)|
|rejectionReason|[RejectionReasonEnum](#schemarejectionreasonenum)|false|none|unknown<br><br>creditCardIsMerchantsCard<br><br>nationalIdIsMerchantsId<br><br>singleTransactionAmountExceeded<br><br>dailyAmountExceeded<br><br>creditCardDailyUsageExceeded<br><br>refundNotMatchRegularAmount<br><br>refundExceededCollateral<br><br>cardOwnerNationalIdRequired<br><br>authCodeRequired|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|cardPresence|[CardPresenceEnum](#schemacardpresenceenum)|false|none|Is the card physically scanned<br><br>cardNotPresent<br><br>regular<br><br>Internet|
|numberOfPayments|integer(int32)|false|none|Number Of Installments|
|transactionAmount|number(double)|false|none|This transaction amount|
|amount|number(double)|false|none|none|
|initialPaymentAmount|number(double)|false|none|Initial installment payment|
|totalAmount|number(double)|false|none|TotalAmount = InitialPaymentAmount + (NumberOfInstallments - 1) * InstallmentPaymentAmount|
|installmentPaymentAmount|number(double)|false|none|Amount of one instalment payment|
|creditCardDetails|[CreditCardDetails](#schemacreditcarddetails)|false|none|Does not store full card number. Used 123456****1234 pattern|
|bankTransferDetails|[BankTransferDetails](#schemabanktransferdetails)|false|none|none|
|creditCardToken|string¦null|false|none|Stored credit card details token reference|
|dealDetails|[DealDetails](#schemadealdetails)|false|none|Additional deal information. All these data are not required and used only for merchant's business purposes.|
|shvaTransactionDetails|any|false|none|Shva details|
|clearingHouseTransactionDetails|any|false|none|PayDay details|
|upayTransactionDetails|any|false|none|none|
|updatedDate|string(date-time)¦null|false|none|Date-time when transaction status updated|
|updateTimestamp|string(byte)¦null|false|none|Concurrency key|
|billingDealID|string(uuid)¦null|false|none|Reference to billing schedule which produced this transaction|
|rejectionMessage|string¦null|false|none|Rejection Reason Message (in case of rejected transaction)|
|vatRate|number(double)|false|none|Deal tax rate|
|vatTotal|number(double)|false|none|Total deal tax amount. VATTotal = NetTotal * VATRate|
|netTotal|number(double)|false|none|Deal amount before tax. PaymentRequestAmount = NetTotal + VATTotal|
|consumerIP|string¦null|false|none|We can know it from checkout page activity|
|merchantIP|string¦null|false|none|Merchant's IP|
|correlationId|string¦null|false|none|Request ID|
|invoiceID|string(uuid)¦null|false|none|Generated invoice ID|
|issueInvoice|boolean|false|none|Create document for transaction|
|documentOrigin|[DocumentOriginEnum](#schemadocumentoriginenum)|false|none|Document origin (primarely payment transaction origin)<br><br>UI (Document created manually by merchant user using Merchant's UI)<br><br>API (Document created via API)<br><br>checkout (Document created by consumer using Checkout Page)<br><br>billing (Document generated based on billing schedule)<br><br>device (Transaction created using pinpad device (or other device))<br><br>paymentRequest (Document created by consumer using Checkout Page with a payment link)<br><br>bit (Document created by consumer using Bit)|
|paymentRequestID|string(uuid)¦null|false|none|Reference to initial payment link creation request|
|processorResultCode|integer(int32)¦null|false|none|none|
|extension|any|false|none|Any advanced payload which will be stored in EasyCard and then can be obtained using "GetTransaction"|
|bitTransactionDetails|any|false|none|none|
|totalRefund|number(double)¦null|false|none|none|
|origin|string¦null|false|none|Origin site url or label|
|allowTransmission|boolean|false|none|Transaction can be transmitted manually|
|allowTransmissionCancellation|boolean|false|none|Transaction transmission cannot be canceled manually|
|allowRefund|boolean|false|none|none|
|allowInvoiceCreation|boolean|false|none|Invoice can be created for this transaction|
|merchantName|string¦null|false|none|Merchant name|
|paymentIntentID|string(uuid)¦null|false|none|none|

<h2 id="tocS_TransactionStatusEnum">TransactionStatusEnum</h2>
<!-- backwards compatibility -->
<a id="schematransactionstatusenum"></a>
<a id="schema_TransactionStatusEnum"></a>
<a id="tocStransactionstatusenum"></a>
<a id="tocstransactionstatusenum"></a>

```json
"initial"

```

initial

confirmedByAggregator

confirmedByPinpadPreProcessor

confirmedByProcessor

awaitingForTransmission

transmissionInProgress

transmissionCancelingInProgress

completed

awaitingToSelectJ5

chargeback

chargebackFailed

transmissionToProcessorFailed

failedToCommitByAggregator

failedToConfirmByProcesor

failedToConfirmByAggregator

cancelledByMerchant

rejectedByProcessor

rejectedByAggregator

rejectedBy3Dsecure

<h2 id="tocS_TransactionSummary">TransactionSummary</h2>
<!-- backwards compatibility -->
<a id="schematransactionsummary"></a>
<a id="schema_TransactionSummary"></a>
<a id="tocStransactionsummary"></a>
<a id="tocstransactionsummary"></a>

```json
{
  "paymentTransactionID": "19fb5b03-41a8-4687-a896-97851484218b",
  "terminalName": "string",
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "documentOrigin": "UI",
  "cardNumber": "string",
  "rejectionMessage": "string",
  "processorResultCode": 0,
  "transactionAmount": 0,
  "initialPaymentAmount": 0,
  "installmentPaymentAmount": 0,
  "transactionType": "regularDeal",
  "currency": "ILS",
  "transactionTimestamp": "2019-08-24T14:15:22Z",
  "status": "initial",
  "paymentTypeEnum": "card",
  "quickStatus": "Pending",
  "specialTransactionType": "regularDeal",
  "jDealType": "J4",
  "rejectionReason": "unknown",
  "cardPresence": "cardNotPresent",
  "cardOwnerName": "string",
  "consumerExternalReference": "string",
  "shvaDealID": "string",
  "invoiceID": "4f03a727-9c4b-43a5-b699-271a3e6fdc9c",
  "dealDescription": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|paymentTransactionID|string(uuid)|false|none|none|
|terminalName|string¦null|false|none|none|
|terminalID|string(uuid)|false|none|none|
|documentOrigin|[DocumentOriginEnum](#schemadocumentoriginenum)|false|none|Document origin (primarely payment transaction origin)<br><br>UI (Document created manually by merchant user using Merchant's UI)<br><br>API (Document created via API)<br><br>checkout (Document created by consumer using Checkout Page)<br><br>billing (Document generated based on billing schedule)<br><br>device (Transaction created using pinpad device (or other device))<br><br>paymentRequest (Document created by consumer using Checkout Page with a payment link)<br><br>bit (Document created by consumer using Bit)|
|cardNumber|string¦null|false|none|none|
|rejectionMessage|string¦null|false|none|Rejection Reason Message (in case of rejected transaction)|
|processorResultCode|integer(int32)¦null|false|none|none|
|transactionAmount|number(double)|false|none|none|
|initialPaymentAmount|number(double)|false|none|none|
|installmentPaymentAmount|number(double)|false|none|none|
|transactionType|[TransactionTypeEnum](#schematransactiontypeenum)|false|none|Generic transaction type<br><br>regularDeal (Simple deal type)<br><br>installments (Deal to pay by parts)<br><br>credit (Credit deal)<br><br>immediate (Credit deal)|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|transactionTimestamp|string(date-time)¦null|false|none|none|
|status|[TransactionStatusEnum](#schematransactionstatusenum)|false|none|initial<br><br>confirmedByAggregator<br><br>confirmedByPinpadPreProcessor<br><br>confirmedByProcessor<br><br>awaitingForTransmission<br><br>transmissionInProgress<br><br>transmissionCancelingInProgress<br><br>completed<br><br>awaitingToSelectJ5<br><br>chargeback<br><br>chargebackFailed<br><br>transmissionToProcessorFailed<br><br>failedToCommitByAggregator<br><br>failedToConfirmByProcesor<br><br>failedToConfirmByAggregator<br><br>cancelledByMerchant<br><br>rejectedByProcessor<br><br>rejectedByAggregator<br><br>rejectedBy3Dsecure|
|paymentTypeEnum|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|card<br><br>cheque<br><br>cash<br><br>bank|
|quickStatus|[QuickStatusFilterTypeEnum](#schemaquickstatusfiltertypeenum)|false|none|Pending<br><br>Completed<br><br>Failed<br><br>Canceled<br><br>AwaitingForTransmission<br><br>Chargeback|
|specialTransactionType|[SpecialTransactionTypeEnum](#schemaspecialtransactiontypeenum)|false|none|regularDeal<br><br>initialDeal<br><br>refund|
|jDealType|[JDealTypeEnum](#schemajdealtypeenum)|false|none|Type of Deal. optional values are; J2 for Check,J4 for Charge, J5 for Block card<br><br>J4 (Regular deal)<br><br>J2 (Check)<br><br>J5 (Block card)|
|rejectionReason|[RejectionReasonEnum](#schemarejectionreasonenum)|false|none|unknown<br><br>creditCardIsMerchantsCard<br><br>nationalIdIsMerchantsId<br><br>singleTransactionAmountExceeded<br><br>dailyAmountExceeded<br><br>creditCardDailyUsageExceeded<br><br>refundNotMatchRegularAmount<br><br>refundExceededCollateral<br><br>cardOwnerNationalIdRequired<br><br>authCodeRequired|
|cardPresence|[CardPresenceEnum](#schemacardpresenceenum)|false|none|Is the card physically scanned<br><br>cardNotPresent<br><br>regular<br><br>Internet|
|cardOwnerName|string¦null|false|none|none|
|consumerExternalReference|string¦null|false|none|none|
|shvaDealID|string¦null|false|none|none|
|invoiceID|string(uuid)¦null|false|none|none|
|dealDescription|string¦null|false|none|none|

<h2 id="tocS_TransactionTypeEnum">TransactionTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schematransactiontypeenum"></a>
<a id="schema_TransactionTypeEnum"></a>
<a id="tocStransactiontypeenum"></a>
<a id="tocstransactiontypeenum"></a>

```json
"regularDeal"

```

Generic transaction type

regularDeal (Simple deal type)

installments (Deal to pay by parts)

credit (Credit deal)

immediate (Credit deal)

