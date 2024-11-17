# BillingCustomerApi

## Create consumer

`POST https://merchant.e-c.co.il/api/consumers`

```json
{
    "terminalID": "0b03e7af-4bde-4dc1-a89c-ad86007e7562",
    "consumerName": "Customer name",
    "consumerPhone": "0580000000",
    "consumerEmail": "yelenak@e-c.co.il",
    "consumerAddress": {
        "city": null,
        "zip": null,
        "street": null,
        "house": null,
        "apartment": null
    },
    "externalReference": "RW67484683",
    "origin": null,
    "bankDetails": {
        "bank": "10",
        "bankBranch": "456",
        "bankAccount": "5553535345"
    }
}
```

## Add Credit Card Token to the Consumer

`POST https://api.e-c.co.il/api/cardtokens`
```json
{
    "cardExpiration": "06/26",
    "cardNumber": "......",
    "cvv": null,
    "cardOwnerNationalID": null,
    "cardOwnerName": "Test Consumer",
    "terminalID": "0b03e7af-4bde-4dc1-a89c-ad86007e7562",
    "consumerID": "ed4b7d1b-ac94-43e5-b619-b22b00cbfe65",
    "consumerEmail": "yelenak@e-c.co.il",
    "oKNumber": "",
    "cardReaderInput": null
}
```
<h3 id="get-consumers-list-parameters">Parameters</h3>

## Get Consumers list

`GET /api/consumers`

<h3 id="get-consumers-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|Search|query|string|false|none|
|ConsumerID|query|string(uuid)|false|none|
|ConsumersID|query|string|false|none|
|NationalID|query|string|false|none|
|Email|query|string|false|none|
|Phone|query|string|false|none|
|ExternalReference|query|string|false|none|
|BillingDesktopRefNumber|query|string|false|none|
|Origin|query|string|false|none|
|WoocommerceID|query|string|false|External ID inside https://woocommerce.com system|
|EcwidID|query|string|false|External ID inside https://www.ecwid.com system|
|Take|query|integer(int32)|false|none|
|Skip|query|integer(int32)|false|none|
|SortBy|query|string|false|none|
|SortDesc|query|boolean|false|none|
|ShowDeleted|query|[ShowDeletedEnum](#schemashowdeletedenum)|false|none|


`GET customer data https://merchant.e-c.co.il/api/consumers/ed4b7d1b-ac94-43e5-b619-b22b00cbfe65`
```json
{
    "consumerID": "ed4b7d1b-ac94-43e5-b619-b22b00cbfe65",
    "merchantID": "644ce03a-f189-421f-8a91-ad86007e465b",
    "active": true,
    "updateTimestamp": "AAAAAAAL+aE=",
    "consumerEmail": "yelenak@e-c.co.il",
    "consumerName": "Customer name",
    "consumerPhone": "0580000000",
    "consumerAddress": {
        "countryCode": null,
        "city": null,
        "zip": null,
        "street": null,
        "house": null,
        "apartment": null
    },
    "consumerNationalID": null,
    "created": "2024-11-17T12:22:43.1075329",
    "operationDoneBy": "Yelenak@e-c.co.il",
    "correlationId": "40001371-0001-9000-b63f-84710c7967bb",
    "externalReference": "RW67484683",
    "origin": null,
    "billingDesktopRefNumber": null,
    "consumerSecondPhone": null,
    "consumerNote": null,
    "bankDetails": {
        "bank": 10,
        "bankBranch": 456,
        "bankAccount": "5553535345",
        "paymentType": "bank",
        "amount": 0.0
    },
    "woocommerceID": null,
    "ecwidID": null,
    "vatExempt": null,
    "externalPriceListID": null,
    "morningID": null
}

```
## Billings types
|Name|Billing Type|
|---|---|
|Credit card|"paymentType": "card"|
|Bnk|"paymentType": "bank"|
|Invoice Only||

## Create Billing Deal with Customer and Credit Card token

`POST https://api.e-c.co.il/api/billing`

```json
{
    "terminalID": "0b03e7af-4bde-4dc1-a89c-ad86007e7562",
    "currency": "ILS",
    "creditCardToken": "abe85e9b-cef2-4cef-966e-b22b00cdcefa",
    "transactionAmount": 5,
    "numberOfPayments": 0,
    "totalAmount": 0,
    "dealDetails": {
        "consumerAddress": {
            "countryCode": null,
            "city": null,
            "zip": null,
            "street": null,
            "house": null,
            "apartment": null
        },
        "dealReference": null,
        "consumerEmail": "yelenak@e-c.co.il",
        "consumerPhone": "0580000000",
        "consumerID": "ed4b7d1b-ac94-43e5-b619-b22b00cbfe65",
        "dealDescription": null,
        "items": [
            {
                "price": 5,
                "discount": 0,
                "amount": 5,
                "itemName": "Item name by default ",
                "currency": "ILS",
                "quantity": 1,
                "externalReference": null,
                "default": true,
                "vat": 0.73,
                "netAmount": 4.27,
                "vatRate": 0.17,
                "withoutVat": false
            }
        ],
        "consumerNationalID": null,
        "consumerName": "Customer name",
        "consumerExternalReference": "RW67484683"
    },
    "billingSchedule": {
        "startAt": "2024-11-17",
        "endAt": "2025-01-31",
        "repeatPeriodType": "monthly",
        "startAtType": "specifiedDate",
        "endAtType": "specifiedDate",
        "endAtNumberOfPayments": null
    },
    "issueInvoice": true,
    "vatRate": 0.17,
    "netTotal": 4.27,
    "vatTotal": 0.73,
    "paymentType": "card",
    "invoiceDetails": {
        "invoiceType": "invoiceWithPaymentInfo",
        "donation": false,
        "invoiceLanguage": "he-IL",
        "invoiceSubject": "Invoice from ECNG",
        "sendCCTo": [
            "korsakovyelena@gmail.com"
        ]
    },
    "bankDetails": null
}
```

## Get Billing details

`Get https://api.e-c.co.il/api/billing/9fc010a8-639b-46f9-a241-b22b00d22f9c`
response:

```json
{
    "billingDealID": "9fc010a8-639b-46f9-a241-b22b00d22f9c",
    "billingDealTimestamp": "2024-11-17T12:45:15.8230087",
    "initialTransactionID": null,
    "terminalID": "0b03e7af-4bde-4dc1-a89c-ad86007e7562",
    "terminalName": "Non Agregator",
    "merchantID": "644ce03a-f189-421f-8a91-ad86007e465b",
    "currency": "ILS",
    "transactionAmount": 5.0000,
    "amount": 5.0000,
    "totalAmount": 0.0000,
    "currentDeal": null,
    "currentTransactionTimestamp": null,
    "currentTransactionID": null,
    "nextScheduledTransaction": "2024-11-17T00:00:00",
    "creditCardDetails": {
        "cardNumber": "****5895",
        "cardExpiration": "06/26",
        "cardOwnerName": "Test Consumer"
    },
    "bankDetails": null,
    "creditCardToken": "abe85e9b-cef2-4cef-966e-b22b00cdcefa",
    "dealDetails": {
        "dealDescription": "Item name by default",
        "consumerEmail": "yelenak@e-c.co.il",
        "consumerName": "Customer name",
        "consumerPhone": "0580000000",
        "consumerID": "ed4b7d1b-ac94-43e5-b619-b22b00cbfe65",
        "items": [
            {
                "itemID": null,
                "externalReference": null,
                "itemName": "Item name by default",
                "sku": "_",
                "price": 5.0,
                "netPrice": 4.27,
                "quantity": 1.0,
                "amount": 5.0,
                "vatRate": 0.17,
                "vat": 0.73,
                "netAmount": 4.27,
                "discount": 0.0,
                "netDiscount": null,
                "extension": null,
                "woocommerceID": null,
                "ecwidID": null,
                "morningID": null,
                "iCountID": null
            }
        ],
        "consumerAddress": {
            "countryCode": null,
            "city": null,
            "zip": null,
            "street": null,
            "house": null,
            "apartment": null
        },
        "consumerExternalReference": "RW67484683"
    },
    "billingSchedule": {
        "repeatPeriodType": "monthly",
        "startAtType": "specifiedDate",
        "startAt": "2024-11-17T00:00:00",
        "endAtType": "specifiedDate",
        "endAt": "2025-01-31T00:00:00",
        "endAtNumberOfPayments": null
    },
    "updatedDate": null,
    "updateTimestamp": "AAAAAACGzso=",
    "operationDoneBy": "Yelenak@e-c.co.il",
    "operationDoneByID": "e360183f-e423-4c9d-8ad9-713d252e8b86",
    "correlationId": "4000425d-0000-f400-b63f-84710c7967bb",
    "sourceIP": "147.243.98.19",
    "active": true,
    "cardExpired": false,
    "tokenNotAvailable": false,
    "invoiceDetails": {
        "invoiceType": "invoiceWithPaymentInfo",
        "invoiceSubject": "Invoice from ECNG",
        "sendCCTo": [
            "korsakovyelena@gmail.com"
        ],
        "donation": false,
        "invoiceLanguage": "he-IL"
    },
    "issueInvoice": true,
    "invoiceOnly": false,
    "vatRate": 0.1700,
    "vatTotal": 0.7300,
    "netTotal": 4.2700,
    "pausedFrom": null,
    "pausedTo": null,
    "paused": false,
    "paymentType": "card",
    "lastError": null,
    "lastErrorCorrelationID": null,
    "paymentDetails": [],
    "failedAttemptsCount": null,
    "expirationEmailSent": null,
    "tokenUpdated": "2024-11-17T00:00:00",
    "tokenCreated": "2024-11-17T00:00:00"
}
```
