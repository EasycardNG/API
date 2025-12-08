EasyCard Next Generation API v1 - _Using Apple Pay&trade; on Checkout Page_
=================================================================

[Apple Pay&trade;](https://www.apple.com/apple-pay/) is the fast, simple way to pay with Apple

 ![image](https://github.com/user-attachments/assets/dcab99d1-4ea9-4095-acc0-893b53acf54a)


Apple Pay allows you to use NFC capable devices to make payments. It brings together everything you need at checkout and keeps your payment info safe in your Apple Account until you're ready to pay.

Apple Pay is built into iPhone, Apple Watch, Mac, iPad, and Apple Vision Pro. 

To get started on iPhone, open the Wallet app and tap the plus symbol.

Then add a credit or debit card by tapping the back of your iPhone with your eligible card. [Apple Pay&trade;](https://www.apple.com/apple-pay/) 

You’ll have the option to add your card to your other devices at the same time. When you want to pay, just double-click, tap, and you’re set. 

<br/>

EasyCard configuration
-----------------------------------------------------------------

To allow _Apple Pay_ payment method on EasyCard checkout page you need to enable _Apple Pay Feature_

>Please note: for the moment you need to request EasyCard administration team to enable Apple Pay feature for you.

As a result, a new payment method will appear on the checkout page - Apple Pay:
![image](https://github.com/user-attachments/assets/f1342b24-532a-4ea2-a32d-035102f15bf3)

![image](https://github.com/user-attachments/assets/9fe27d55-86d8-4378-97d1-4ad5612f98b8)

<br/>

Apple Pay&trade; technical detail
-----------------------------------------------------------------

PanEntryMode 52 should be allowed from Visa Cal

We support only Israel based merchants. We support any authorization methods provided by _Shva_ (which is the same as for regular cards processing)

We support all card networks which works in Israel: "AMEX", "MASTERCARD", "VISA". If you need additional details - please contact our support.

We do not support billing address processing for now.

We do not expect that merchant will send any Google Pay related data via API - we are doing payments on  behalf of the merchant using our web checkout page.

<br/>

Environments
-----------------------------------------------------------------
 
 Please note, that [Sandbox](Readme.md#environments) environment of EasyCard always configured for Google Pay _TEST_ environment and EasyCard Production is pointed to Google Pay _PRODUCTION_ environment.
