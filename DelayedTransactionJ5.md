
"Delayed" transaction J5 
=================================================================

Delayed transactions J5 allow businesses to seize the billing amount from a customer's credit limit without charging them.

Delayed transactions  J5 allow businesses to hold the charge amount in reserve until the transaction is completed

Delayed transactions J5 assures customers that they'll only be charged after the transaction is completed, giving them peace of mind when making purchases. 


There 2 options "Create delayed transaction J5:
"blocking" and Creating transaction from the Checkout page where "jDealType": "J5"
-------------------------------------------------------------------
<br/>

Post method 
API request https://api.e-c.co.il/api/transactions/blocking   

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

