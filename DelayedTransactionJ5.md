
Delayed transaction J5 
=================================================================

Delayed transactions J5 allow businesses to seize the billing amount from a customer's credit limit without charging them.

Delayed transactions  J5 allow businesses to hold the charge amount in reserve until the transaction is completed

There 2 options "Create delayed transaction J5: "blocking" and Creating transactions from the Checkout page where "jDealType": "J5"
---------------------------------------------------------------------------------------------------------------------------------------

Blocking method
-----------------
Post API request https://api.e-c.co.il/api/transactions/blocking   
```json
{
    "terminalID": "",
    "transactionType": "regularDeal",
    "jDealType": "J5",
    "currency": "ILS",
    "cardPresence": "cardNotPresent",
    "creditCardToken": null,
    "creditCardSecureDetails": {
        "cardExpiration": "",
        "cardNumber": "",
        "cvv": null,
        "cardOwnerNationalID": null,
        "cardOwnerName": "Dan Gonen",
        "cardReaderInput": null,
        "saveCreditCard": false
    },
    "transactionAmount": 5,
    "dealDetails": {
        "consumerAddress": {
            "city": null,
            "street": null,
            "house": null,
            "apartment": null,
            "zip": null
        },
        "dealReference": null,
        "consumerName": null,
        "consumerEmail": null,
        "consumerPhone": null,
        "consumerNationalID": null,
        "consumerID": null,
        "dealDescription": "ECNG service",
        "items": [
            {
                "price": 5,
                "discount": 0,
                "amount": 5,
                "itemName": "כללי",
                "currency": "ILS",
                "quantity": 1,
                "externalReference": null,
                "default": true,
                "vat": 0.73,
                "netAmount": 4.27,
                "vatRate": 0.17,
                "withoutVat": false
            }
        ]
    },
    "invoiceDetails": null,
    "installmentDetails": null,
    "netTotal": 4.27,
    "vatTotal": 0.73,
    "vatRate": 0.17,
    "saveCreditCard": false,
    "pinPadDeviceID": null,
    "cardOwnerNationalID": null,
    "pinPad": false,
    "issueInvoice": false
}
```

Response

```json
{
    "message": "Transaction Created",
    "status": "success",
    "entityUID": "dee79ccd-e70d-4f3c-86bd-b1bd00b61a04",
    "entityReference": "dee79ccd-e70d-4f3c-86bd-b1bd00b61a04",
    "innerResponse": {
        "message": "J5 Expiration date is 8/29/2024 11:03:00 AM",
        "status": "success"
    }
}
```

Transfer transaction J5 to J4
-----------------------------

Post https://api.e-c.co.il/api/transactions/selectJ5/dee79ccd-e70d-4f3c-86bd-b1bd00b61a04

Response 

```json

{
    "message": "Transaction Created",
    "status": "success",
    "entityUID": "5cadc379-fe34-4563-9e0c-b1bd00b71568",
    "entityReference": "5cadc379-fe34-4563-9e0c-b1bd00b71568",
    "innerResponse": {
        "message": "Invoice State is not valid",
        "status": "warning",
        "entityUID": "5cadc379-fe34-4563-9e0c-b1bd00b71568",
        "entityReference": "5cadc379-fe34-4563-9e0c-b1bd00b71568"
    }
}
```

Finally get transaction J4 (Transaction ID 5cadc379-fe34-4563-9e0c-b1bd00b71568)

Transaction J5. Converter J5-J4 works only with regular transactions and not with Credit/installments

Cancel a J5 if a transaction is not completed 
---------------------------------------------
Convert J5->J4 and cancel J4 before transmission. There is no option to cancel J5

https://api.e-c.co.il/api/transmission/cancel 
```json
{
    "terminalID": "98484a79-ee08-43fd-85fc-b1bd00b0feca",
    "paymentTransactionID": "5cadc379-fe34-4563-9e0c-b1bd00b71568"
}
```
Response

```json
{"message":"Transaction Canceled","status":"success"}
```
