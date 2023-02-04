EasyCard Next Generation API v1 - _Using Google Pay on Checkout Page_
=================================================================

> If you are planning to provide [Google Pay&trade;](https://developers.google.com/pay) payment method to your consumers please check requirements below

[Google Pay&trade;](https://developers.google.com/pay) is the fast, simple way to pay with Google

Google Pay allows you to use NFC capable Android devices to make payments. It brings together everything you need at checkout and keeps your payment info safe in your Google Account until you're ready to pay.

<br/>

EasyCard configuration
-----------------------------------------------------------------

To allow _Google Pay_ payment method on EasyCard checkout page you need to enable _Google Pay Feature_

>Please note: for the moment you need to request EasyCard administration team to enable Google Pay feature for you.

Next, you need to specify your company _Google Merchant ID_ in terminal settings:

![Google Merchant ID](images/GooglePaySettings.png)

As a result, a new payment method will appear on the checkout page - Google Pay:

![Google Pay Payment Option](images/GooglePayPaymentMethodSelection.png)

<br/>

Google Pay and Wallet Console configuration
-----------------------------------------------------------------

Before enabling Google Pay feature in your EasyCard terminal, please ensure that your Google Pay account meets all requirements. Please use [Google Pay and Wallet Console](https://pay.google.com/business/console) for registration and management actions. 
For _Google Pay API integration type_ parameter please use "Gateway" option.
After registration you can get _Google Merchant ID_ using that console and then you need to request Google administrators to enabled your account for production.

> Please ensure that your company adheres to the Google Pay APIs [Acceptable Use Policy](https://payments.developers.google.com/terms/aup) and accepts the terms defined in the [Google Pay API Terms of Service](https://payments.developers.google.com/terms/sellertos).

<br/>

Environments
-----------------------------------------------------------------
 
 Please note, that [Sandbox](Readme.md#environments) environment of EasyCard always configured for Google Pay _TEST_ environment and EasyCard Production is pointed to Google Pay _PRODUCTION_ environment.