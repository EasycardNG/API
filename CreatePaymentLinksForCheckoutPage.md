
# PaymentIntent

## Create a payment link to the Checkout Page

# PaymentIntent

`POST /api/paymentIntent`

# Link expired after successful payment

> Body parameter
 "paymentIntent": true
```json
{
    "terminalID": "95297b3b-2595-4f72-82f7-abdc006a1c2a",
    "currency": "ILS",
    "invoiceType": "invoiceWithPaymentInfo",
    "paymentRequestAmount": 20,
    "dueDate": null,
    "isRefund": false,
    "donation": true,
    "allowCredit": true,
    "allowInstallments": true,
    "hidePhone": false,
    "hideEmail": false,
    "hideNationalID": false,
    "consumerDataReadonly": null,
    "showClock": null,
    "issueInvoice": true,
    "addressRequired": false,
    "dealDetails": {
        "consumerAddress": {
            "city": "string",
            "street": "string",
            "house": "string",
            "apartment": "string",
            "zip": "string"
        },
        "dealReference": "string",
        "consumerEmail": "string",
        "consumerPhone": "string",
        "consumerID": "string",
        "dealDescription": "string",
        "items": [
            {
                "itemID": "ebc502e6-fdda-4dc2-9b13-b259014d4865",
                "itemName": "16.81",
                "price": 20,
                "discount": 0,
                "currency": "ILS",
                "quantity": 1,
                "externalReference": null,
                "woocommerceID": null,
                "amount": 20,
                "vat": 3.05,
                "netAmount": 16.95,
                "vatRate": 0.18,
                "withoutVat": false
            }
        ],
        "consumerNationalID": "string"
    },
    "invoiceDetails": {
        "invoiceType": "invoiceWithPaymentInfo",
        "donation": false,
        "invoiceLanguage": "he-IL",
        "invoiceNumber": null,
        "invoiceSubject": "Invoice",
        "sendCCTo": ["string"]},
    "installmentDetails": {
        "minInstallments": 2,
        "maxInstallments": 36,
        "minCreditInstallments": 3,
        "maxCreditInstallments": 12,
        "totalAmount": 20,
        "numberOfPayments": 1,
        "initialPaymentAmount": 20,
        "installmentPaymentAmount": 20
    },
    "minInstallments": 2,
    "maxInstallments": 36,
    "minCreditInstallments": 3,
    "maxCreditInstallments": 12,
    "customCssReference": null,
    "redirectUrl": "string",
    "legacyRedirectResponse": false,
    "continueInCaseOf3DSecureError": null,
    "defaultLanguage": "he-IL",
    "allowImmediate": true,
    "hideConsumerName": false,
    "allowSaveCreditCard": true,
    "consumerNationalIDReadonly": null,
    "consumerPhoneReadonly": null,
    "consumerNameReadonly": null,
    "saveCreditCardByDefault": false,
    "disableCancelPayment": null,
    "phoneRequired": null,
    "emailRequired": true,
    "hideDealDescription": true,
    "noteEnabled": true,
    "alternativeMerchantName": null,
    "allowOnlyILS": false,
    "hideAddress": false,
    "transactionSucceedUrl": "string",
    "transactionFailedUrl": "string",
    "netTotal": 16.95,
    "vatTotal": 3.05,
    "vatRate": 0.18,
    "totalAmount": 20,
    "amount": 20,
    "transactionAmount": 20,
    "transactionType": "regularDeal",
    "consumerSpecified": false,
    "consumerNationalIdSpecified": false,
    "consumerEmailSpecified": false,
    "jDealType": "J4",
    "allowRegular": true,
    "additionalFields": {},
    "paymentIntent": true
}

```
[> ](https://checkout.e-c.co.il:443/i?r=HiIt%2bQnsBN6x8WZ3k%2fM7EpraYRVSujPK%2fSIX2Ig82mx5BNQh%2fCS3qw%3d%3d&l=he-IL)Example responses

> 201 Response

```json
{
    "message": "Payment Request created",
    "status": "success",
    "entityUID": "f9926da8-67b0-4332-b0e3-b2610072f757",
    "entityReference": "f9926da8-67b0-4332-b0e3-b2610072f757",
    "additionalData": {
        "url": "https://checkout.e-c.co.il:443/i?r=kNDqeKlpdRurYVjzoBfIDdaJRaqr3rWMb78yI0NC7COa6hZ5xLmEkg%3d%3d&l=he-IL"
    }
}
```
## Link after success payment is not available

https://checkout.e-c.co.il:443/i?r=HiIt%2bQnsBN6x8WZ3k%2fM7EpraYRVSujPK%2fSIX2Ig82mx5BNQh%2fCS3qw%3d%3d&l=he-IL

# Payment request

`POST /api/paymentRequests`

# Link is not available after the expiration date or successful payment 

Customer Mail or phone number is mandatory for the link

"paymentIntent": false

> Body parameter
 "paymentIntent": false
> 
```json
{
    "terminalID": "0b03e7af-4bde-4dc1-a89c-ad86007e7562",
    "currency": "ILS",
    "invoiceType": "invoiceWithPaymentInfo",
    "paymentRequestAmount": 100,
    "dueDate": null,
    "isRefund": false,
    "donation": true,
    "allowCredit": false,
    "allowInstallments": true,
    "hidePhone": false,
    "hideEmail": false,
    "hideNationalID": false,
    "consumerDataReadonly": null,
    "showClock": false,
    "issueInvoice": true,
    "addressRequired": false,
    "dealDetails": {
        "consumerAddress": {
            "city": "String",
            "street": "String",
            "house": "String",
            "apartment": "String",
            "zip": "String"
        },
        "dealReference": "String",
        "consumerEmail": "String",
        "consumerPhone": "String",
        "consumerID": "String",
        "dealDescription": "String",
        "items": [
            {
                "itemID": "6f731824-251e-42d5-8a41-b203008b3661",
                "itemName": "String",
                "price": 100,
                "discount": 0,
                "currency": "ILS",
                "quantity": 1,
                "externalReference": "String",
                "woocommerceID": "",
                "amount": 100,
                "vat": 15.25,
                "netAmount": 84.75,
                "vatRate": 0.18,
                "withoutVat": false
            }
        ],
        "consumerNationalID": null
    },
    "invoiceDetails": {
        "invoiceType": "invoiceWithPaymentInfo",
        "donation": false,
        "invoiceLanguage": "he-IL",
        "invoiceNumber": null,
        "invoiceSubject": "Invoice from ECNG",
        "sendCCTo": "String"},
    "installmentDetails": {
        "minInstallments": 2,
        "maxInstallments": 2,
        "minCreditInstallments": 3,
        "maxCreditInstallments": 3,
        "totalAmount": 100,
        "numberOfPayments": 1,
        "initialPaymentAmount": 100,
        "installmentPaymentAmount": 100
    },
    "minInstallments": 2,
    "maxInstallments": 2,
    "minCreditInstallments": 3,
    "maxCreditInstallments": 3,
    "customCssReference": null,
    "redirectUrl": "String",
    "legacyRedirectResponse": true,
    "continueInCaseOf3DSecureError": null,
    "defaultLanguage": "he-IL",
    "allowImmediate": false,
    "hideConsumerName": false,
    "allowSaveCreditCard": false,
    "consumerNationalIDReadonly": null,
    "consumerPhoneReadonly": null,
    "consumerNameReadonly": null,
    "countdownTime": 20,
    "saveCreditCardByDefault": false,
    "disableCancelPayment": null,
    "phoneRequired": null,
    "emailRequired": true,
    "hideDealDescription": false,
    "noteEnabled": true,
    "alternativeMerchantName": "String",
    "allowOnlyILS": false,
    "hideAddress": false,
    "transactionSucceedUrl": "String",
    "transactionFailedUrl": "String",
    "netTotal": 84.75,
    "vatTotal": 15.25,
    "vatRate": 0.18,
    "totalAmount": 100,
    "amount": 100,
    "transactionAmount": 100,
    "transactionType": "regularDeal",
    "consumerSpecified": false,
    "consumerNationalIdSpecified": false,
    "consumerEmailSpecified": false,
    "jDealType": "J4",
    "allowRegular": true,
    "additionalFields": {
        "KEY": {
            "title": "First additional field",
            "required": true
        },
        "Keys": {
            "title": "Second additional field",
            "required": false
        }
    },
    "paymentIntent": false
}
```
> 201 Response

```json
{
{
    "message": "Payment Request created",
    "status": "success",
    "entityUID": "8d16ab8c-ca51-4ece-9254-b261007850b1",
    "entityReference": "8d16ab8c-ca51-4ece-9254-b261007850b1",
    "additionalData": {
        "url": "https://checkout.e-c.co.il:443/i?r=kNDqeKlpdRurYVjzoBfIDdaJRaqr3rWMb78yI0NC7COa6hZ5xLmEkg%3d%3d&l=he-IL"
    }
}

```
# Permanent Link - multiple using

`POST /api/paymentRequests`

> Body parameter
> 
  "permanent": true,
> 
  "paymentIntent": false
> 
```json
{
    "terminalID": "0b03e7af-4bde-4dc1-a89c-ad86007e7562",
    "currency": "ILS",
    "invoiceType": "invoiceWithPaymentInfo",
    "paymentRequestAmount": 100,
    "dueDate": null,
    "isRefund": false,
    "donation": true,
    "allowCredit": false,
    "allowInstallments": true,
    "hidePhone": false,
    "hideEmail": false,
    "hideNationalID": false,
    "consumerDataReadonly": null,
    "showClock": false,
    "issueInvoice": true,
    "addressRequired": false,
    "dealDetails": {
        "consumerAddress": {
            "city": null,
            "street": null,
            "house": null,
            "apartment": null,
            "zip": null
        },
        "dealReference": null,
        "consumerEmail": null,
        "consumerPhone": null,
        "consumerID": null,
        "dealDescription": null,
        "items": [
            {
                "itemID": "6f731824-251e-42d5-8a41-b203008b3661",
                "itemName": "String",
                "price": 100,
                "discount": 0,
                "currency": "ILS",
                "quantity": 1,
                "externalReference": null,
                "woocommerceID": "",
                "amount": 100,
                "vat": 15.25,
                "netAmount": 84.75,
                "vatRate": 0.18,
                "withoutVat": false
            }
        ],
        "consumerNationalID": null
    },
    "invoiceDetails": {
        "invoiceType": "invoiceWithPaymentInfo",
        "donation": false,
        "invoiceLanguage": "he-IL",
        "invoiceNumber": null,
        "invoiceSubject": "Invoice from ECNG",
        "sendCCTo": "String"
 },
    "installmentDetails": {
        "minInstallments": 2,
        "maxInstallments": 2,
        "minCreditInstallments": 3,
        "maxCreditInstallments": 3,
        "totalAmount": 100,
        "numberOfPayments": 1,
        "initialPaymentAmount": 100,
        "installmentPaymentAmount": 100
    },
    "minInstallments": 2,
    "maxInstallments": 2,
    "minCreditInstallments": 3,
    "maxCreditInstallments": 3,
    "customCssReference": null,
    "redirectUrl":  "String",
    "legacyRedirectResponse": true,
    "continueInCaseOf3DSecureError": null,
    "defaultLanguage": "he-IL",
    "allowImmediate": false,
    "hideConsumerName": false,
    "allowSaveCreditCard": false,
    "consumerNationalIDReadonly": null,
    "consumerPhoneReadonly": null,
    "consumerNameReadonly": null,
    "countdownTime": 20,
    "saveCreditCardByDefault": false,
    "disableCancelPayment": null,
    "phoneRequired": null,
    "emailRequired": true,
    "hideDealDescription": false,
    "noteEnabled": true,
    "alternativeMerchantName": "Test Terminal",
    "allowOnlyILS": false,
    "hideAddress": false,
    "transactionSucceedUrl": "String",
    "transactionFailedUrl":  "String",
    "netTotal": 84.75,
    "vatTotal": 15.25,
    "vatRate": 0.18,
    "totalAmount": 100,
    "amount": 100,
    "transactionAmount": 100,
    "transactionType": "regularDeal",
    "consumerSpecified": false,
    "consumerNationalIdSpecified": false,
    "consumerEmailSpecified": false,
    "jDealType": "J4",
    "allowRegular": true,
    "additionalFields": {},
    "permanent": true,
    "paymentIntent": false
}

```
