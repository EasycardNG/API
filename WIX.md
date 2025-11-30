EasyCard Next Generation API v1 - _WIX_
=================================================================

![image](https://github.com/user-attachments/assets/940efaa0-3832-4b73-9c36-51b64a1f6fdd)

 <br/>

WIX integration with ECNG plugin
----------------------------------------------------------------

 <br/>

Registration/Login to the WIX https://www.wix.com/
---------------------------------------------------------------

WIX Dashboard 
---------------------------------------------------------------
Dashboard menu: Site & Mobile App-> Website & SEO

![image](https://github.com/user-attachments/assets/479c7f9a-553f-4518-a7ed-6d63774c2f49)

Website Overview -> Edit site (redirect to the site Editor)

![image](https://github.com/user-attachments/assets/676300f5-6c7b-4171-9570-3b26f79f6ab5)


Site Editor
---------------------------------------------------------------
1. Swith on Dev Mode
   
![image](https://github.com/user-attachments/assets/6382c6e7-de24-40ab-85db-3dbbc3b6ce2d)

2. From the left menu select Backend & Public, add Service Plugins "Payment"

 ![image](https://github.com/user-attachments/assets/91afc92a-67f5-4468-a2ad-e62ba13cd7fc)

 ![image](https://github.com/user-attachments/assets/24369296-b83d-4fb0-b39f-e0282511980b)

3. Data for js files

![image](https://github.com/user-attachments/assets/300a9f19-68cf-4954-861e-47da61ad71e6)


  Backend  http-functions.js
 --------------------------------------------------------------- 
```j
import { ok, badRequest } from "wix-http-functions";
import wixPaymentProviderBackend from "wix-payment-provider-backend";

// An endpoint for receiving updates about transactions.
export async function post_updateTransaction(request) {
  console.log("Invoked post_updateTransaction");
  const transactionRequestBody = await request.body.json();
  console.log(transactionRequestBody);
  const response = {
    headers: {
      "Content-Type": "application/json",
    },
  };
  // Validate the request content.
  if (transactionRequestBody.eventName === "TransactionCreated") {
    // Update the transaction status on your site. This code assumes that the Wix
    // transaction ID and the payment provider's transaction ID are included in
    // the URL as query parameters.
    await wixPaymentProviderBackend.submitEvent({
      event: {
        transaction: {
          wixTransactionId: transactionRequestBody.entityExternalReference,
          //pluginTransactionId: request.query["pluginTransactionId"],
        },
      },
    });
    return ok(response);
  } else {
    return badRequest(response);
  }
}

 ```
Service Plugins easy-card-config.js
 ---------------------------------------------------------------
```j
// Place this code in the <my-plugin-name>-config.js file
// in the 'payment-provider' folder of the
// Service Plugins section on your site.

export function getConfig() {
  return {
    title: "EasyCard",
    paymentMethods: [
      {
        hostedPage: {
          title: "EasyCard",
          logos: {
            white: {
              svg: 'https://static.wixstatic.com/media/87b5fd_5f8435f73b4943b9918a9effa83bd8ec~mv2.png',
              png: 'https://static.wixstatic.com/media/87b5fd_5f8435f73b4943b9918a9effa83bd8ec~mv2.png'
            },
            colored: {
              svg: 'https://static.wixstatic.com/media/87b5fd_5f8435f73b4943b9918a9effa83bd8ec~mv2.png',
              png: 'https://static.wixstatic.com/media/87b5fd_5f8435f73b4943b9918a9effa83bd8ec~mv2.png'
            }
          },
        },
      },
    ],
    credentialsFields: [
      {
        simpleField: {
          name: "privateApiKey",
          label: "Private Api Key",
        },
      }
    ],
  };
}

 ```
Service Plugins easy-card.js
 ---------------------------------------------------------------
```j
import { fetch } from 'wix-fetch';
import { URLSearchParams } from 'url';
const urlToken = 'https://identity.e-c.co.il/connect/token';
const urlPaymentIntent = 'https://api.e-c.co.il/api/paymentIntent';

/**
 * This payment plugin endpoint is triggered when a merchant provides required data to connect their PSP account to a Wix site.
 * The plugin has to verify merchant's credentials, and ensure the merchant has an operational PSP account.
 * @param {import('interfaces-psp-v1-payment-service-provider').ConnectAccountOptions} options
 * @param {import('interfaces-psp-v1-payment-service-provider').Context} context
 * @returns {Promise<import('interfaces-psp-v1-payment-service-provider').ConnectAccountResponse | import('interfaces-psp-v1-payment-service-provider').BusinessError>}
 */
export const connectAccount = async (options, context) => {
    let response =  {
        credentials: {
            privateApiKey: options.credentials.privateApiKey
        },
        accountId: "",
        accountName: ""
    }
    if (await getToken(options.credentials.privateApiKey))
    {
        console.log("Account connected");
        return response;
    }
    response.errorMessage = "Can't connect";
    response.reasonCode = 2004;
    return response;
};

/**
 * This payment plugin endpoint is triggered when a buyer pays on a Wix site.
 * The plugin has to process this payment request but prevent double payments for the same `wixTransactionId`.
 * @param {import('interfaces-psp-v1-payment-service-provider').CreateTransactionOptions} options
 * @param {import('interfaces-psp-v1-payment-service-provider').Context} context
 * @returns {Promise<import('interfaces-psp-v1-payment-service-provider').CreateTransactionResponse | import('interfaces-psp-v1-payment-service-provider').BusinessError>}
 */
export const createTransaction = async (options, context) => {
    console.log("createTransaction invoiked");
    console.log(options);
    let accessToken = await getToken(options.merchantCredentials.privateApiKey);

    let order = options.order.description;
    let returnUrls = options.order.returnUrls;

    let items = []; 
    let totalAmount = 0;
    order.items.forEach(element => {
        totalAmount += element.quantity * element.price;
        items.push({
                "price": element.price / 100,
                "amount": element.price * element.quantity / 100,
                "itemName": element.name,
                "currency": order.currency,
                "quantity": element.quantity,
                "externalReference": element._id,
            });
    });
   if (order.charges.shipping) {
        items.push({
                "price": order.charges.shipping / 100,
                "amount": order.charges.shipping / 100,
                "itemName": "Shipping",
                "currency": order.currency,
                "quantity": 1,
            });
    }
    totalAmount = totalAmount / 100;

    const data =     
    {
        dealDetails: {
            dealReference: options.wixTransactionId,
            consumerEmail: order.billingAddress.email,
            consumerName: `${order.billingAddress.firstName} ${order.billingAddress.lastName} `.trim(),
            consumerPhone: order.billingAddress.phone,
            consumerAddress: {
                city: order.billingAddress.city,
                street: order.billingAddress.street,
                house: order.billingAddress.house,
                zip: order.billingAddress.zipCode
            },
            items: items
        },
        currency: order.currency,
        paymentRequestAmount: totalAmount,
        dueDate: null,
        allowPinPad: false,
        hideEmail: false,
        allowInstallments: false,
        allowCredit: false,
        allowImmediate: false,
        isRefund: false,
        hidePhone: false,
        //vatRate: 0,
        redirectUrl: returnUrls.successUrl,
        userAmount: false,
        hideNationalID: false,
        issueInvoice: true,
    }

    const opts = {
        method: 'POST',
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${accessToken}`
        },
        body: JSON.stringify(data)
    };

    console.log("body", opts.body);

    var response = await fetch(urlPaymentIntent, opts)
    .then(httpResponse => {
        if (httpResponse.ok) {
            return httpResponse.json();
        } else {
            return Promise.reject("Fetch did not succeed");
        }
    })
    .then(response => {
        console.log("Debug:", response);
        return response;
    })
    .catch(error => {
      console.error("Error:", error);
    });


    return {
        pluginTransactionId: response.entityReference,
        redirectUrl: response.additionalData.url
    }
};

/**
 * This payment plugin endpoint is triggered when a merchant refunds a payment made on a Wix site.
 * The plugin has to process this refund request but prevent double refunds for the same `wixRefundId`.
 * @param {import('interfaces-psp-v1-payment-service-provider').RefundTransactionOptions} options
 * @param {import('interfaces-psp-v1-payment-service-provider').Context} context
 * @returns {Promise<import('interfaces-psp-v1-payment-service-provider').CreateRefundResponse | import('interfaces-psp-v1-payment-service-provider').BusinessError>}
 */
export const refundTransaction = async (options, context) => {
    console.log("Refund invoked:", options);
};

const getToken = async (privateApiKey) => {
    const qs = {
        client_id: 'terminal',
        grant_type: 'terminal_rest_api',
        authorizationKey: privateApiKey
    };
    const encodedData = new URLSearchParams(qs).toString();
  
    // Set up the fetch options
    const opts = {
        method: 'POST',
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        body: encodedData
    };

    var response = await fetch(urlToken, opts)
    .then(httpResponse => {
        if (httpResponse.ok) {
            return httpResponse.json();
        } else {
            return Promise.reject("Fetch did not succeed");
        }
    })
    .then(response => {
        console.log("Debug:", response);
        return response;
    })
    .catch(error => {
      console.error("Error:", error);
    });
    if (response && response.access_token)
    {
        console.log("Got token");
        return response.access_token;
    }
    return null;
}
 ```
 5. Publish plugin config
 --------------------------------------------------------------- 
 
 <img width="1901" height="907" alt="image" src="https://github.com/user-attachments/assets/8356ede8-868a-45ff-af4d-6f6b155072ce" />
 
WIX Dashboard 
=================================================================

1. Select Accept payments from WIX Settings
   
![image](https://github.com/user-attachments/assets/96db0d1e-eae8-4f93-a5de-7345ee9bcd4c)

2. Accept payments page- select plugin "Easy Card" - Manage
   
![image](https://github.com/user-attachments/assets/4a9caded-d8a1-4683-9eb2-e9e3e88d16b7)

3. Add Private Apikey (select from terminal settings) to the plugin

![image](https://github.com/user-attachments/assets/9b587ee3-8ee9-4295-ba4a-3a27024e2783)


ECNG (Easy Card) Terminal settings 
=================================================================

1. Add the Redirect URL WIX https://cashier-services.wix.com/

![image](https://github.com/user-attachments/assets/4d162e5e-787b-4d48-9c8a-794b0e3eb8c0)

2. Add Webhooks for Passed transactions
   
URL WIX + _functions/updateTransaction

Simple https://www.easycardhub.com/_functions/updateTransaction

![image](https://github.com/user-attachments/assets/c0c59752-6b56-4315-a8ca-a00991a8b11b)

Payment from WIX checkout page
=================================================================

![image](https://github.com/user-attachments/assets/9bfc84f2-3d6c-4d78-94b5-a06eaf9d7b68)

![image](https://github.com/user-attachments/assets/a6dd4d20-33ba-4a2e-8b64-6f22198c25ea)

![image](https://github.com/user-attachments/assets/fe776512-888c-406f-8103-20dbc2db101e)

![image](https://github.com/user-attachments/assets/3d9c73cf-409a-4855-97d1-e5bb53984c9c)

![image](https://github.com/user-attachments/assets/4c418da8-bc93-4d5e-b77d-5d1e599ff6f1)

Check order details 
=================================================================

![image](https://github.com/user-attachments/assets/114b15a3-6f3e-4730-a68b-6481476f1c39)

Correct status for the passed transaction "Paid"
=================================================================

 <br/>
