EasyCard Next Generation API v1 - _Woocomerce_
=================================================================
![image](https://github.com/user-attachments/assets/db480d22-df74-4041-97f8-82a802598498)
 <br/>

Woocomerce integration with ECNG plugin
----------------------------------------------------------------
Note: The Easy Card plugin is supported only with the Classic checkout page 
https://docs.wpovernight.com/woocommerce-postcode-checker/classic-checkout-and-woo-checkout-blocks/ 
<img width="980" height="442" alt="image" src="https://github.com/user-attachments/assets/5323a831-4447-4be5-987f-6d784f6278a9" />


 <br/>

Instructions for installing the plugin  
https://www.e-c.co.il/woocommerce-plugin   (Hebrew)
---------------------------------------------------------------

1.	Enter the site's control panel
2.	Go to the plugins and select "New plugin"
   
 ![image](https://github.com/user-attachments/assets/f3fdce62-c278-4990-8995-942aa9ec25a8)

3.	In a new plugin window search for "Easycard NG" and click the "Install" button
   
![image](https://github.com/user-attachments/assets/cdd92be5-65cc-4e2d-a80c-8fb23052bde5)

4.	When the installation is complete, go to WooCommerce > Settings:
   
![image](https://github.com/user-attachments/assets/8e562040-7e0f-40d3-b11b-bc493c5908ad)

5.	Enter the "Payments" button and click the "Manage" button in the Easycard line:
   
![image](https://github.com/user-attachments/assets/189e8e72-84a0-4a18-85d1-52dafd18364c)

---------------------------------------------------------------


6. We will complete the settings:
   
 <br/>

•	Activating the payment method – Enable Easycard – must be marked with a V

•	Title – the name of the payment method as it will appear on the website

•	Description – Description of the payment method as it will appear on the website

•	Logo – URL to Logo Made for Payment Methods

•	Instructions – additional text that will be displayed on the thank you page and in the email sent with the invitation.

•	Payment Mode – Choose the desired billing method – Redirect or IFrame.

•	DealType – Here you can choose between J4 (instant debit) or an armor transaction (J5), so it is the merchant's responsibility to fulfill the transaction when the order is delivered.

•	Checkout Page Language

•	Enable Sandbox Environment – If you were provided by Isicard with a test terminal, and only in this situation, mark V in this field, no actual charges will be made.

•	Private Key – Enter the API key given to you by EasyCard.

![image](https://github.com/user-attachments/assets/32f0019b-1284-43fc-8ab5-1a1dff7c23c2)

  <br/>

Affect Woocomerce settings to our plugin. Add Product/items
-----------------------------------------------------------------

 <br/>

Install the additional plugin for item code

https://wordpress.com/de/plugins/product-code-for-woocommerce  

![image](https://github.com/user-attachments/assets/0dda2e30-5539-48bf-9408-ba2faaad031e)

<br/>
 
Affect Woocomerce settings to our plugin. How to add SKU and Item code. Select an item from the list, open the details
-----------------------------------------------------------------

https://www.youtube.com/watch?v=BCPjthg0FOs 

Inventory

![image](https://github.com/user-attachments/assets/93cf6f35-bd3f-4105-932c-b0446c29219c)

 <br/>
 
 SKU and Product Code should be the same value (for clients with RapidOne and ICount invoice integration)

![image](https://github.com/user-attachments/assets/02afa62c-368f-4d64-bd61-b0c69002d9ad)

  <br/>

Affect Woocomerce settings to our plugin. How to enable Direct Checkout
-----------------------------------------------------------------

https://woocommerce.com/document/cashier-for-woocommerce/how-to-enable-a-direct-checkout/#:~:text=Go%20to%3A%20WordPress%20Admin%20%3E%20WooCommerce,%2C%20Purchase%20Now%2C%20or%20others.

 <br/>
 
Change the payment button Woocomerce store
-----------------------------------------------------------------

![image](https://github.com/user-attachments/assets/0ce45e9d-7a8b-42a4-a167-1c3d368f0b69)
 
<br/>
 
 Affect Woocomerce settings to our plugin. Blocks and Classic Woocomerce editor
 -----------------------------------------------------------------
 
 <br/>

ECNG plugin is not supported with Blocker Editor, supported only with Classic editor 

Pages. Select and Edit page

![image](https://github.com/user-attachments/assets/e8ee3326-ce36-473b-affa-a7d00176035e)

Should be selected classic page editor, not BLOCK

![image](https://github.com/user-attachments/assets/fc589c6d-1425-464f-bc8d-f3fa66bb9cb2)

 <br/>

 Add Coupons/Sales for payment
 --------------------------------------------------------------

 Marketing-> Coupons
 
 ![image](https://github.com/user-attachments/assets/7972a555-56dd-4768-a010-d72c36ef0075)
 
Fill form and submit

![image](https://github.com/user-attachments/assets/a2c8a127-1fcc-43f0-b9c5-150e3ad1b3a0)

 Add code coupon as a discount:
 
 ![image](https://github.com/user-attachments/assets/3afd6d57-b642-4596-8dcd-38d94dcb5ca8)

 <br/>

 “Thank you” page
----------------------------------------------------------------

“Thank you page” by default is Woocomerce “Thank you page”, customer “Thank you page” is not supported

 ![image](https://github.com/user-attachments/assets/b8bd1633-4096-40cd-8c6b-601f83f194e4)


 <br/>

Webhooks
----------------------------------------------------------------

ECNG terminal settings 

Add webhook: Return redirect URL + /wc-api/ecng_webhook

![image](https://github.com/user-attachments/assets/30396daf-2575-4393-a495-e9ae7ffc5c70)

<br/>

Order Status
----------------------------------------------------------------

Woocomerce order statuses
https://woocommerce.com/document/managing-orders/order-statuses/

![image](https://github.com/user-attachments/assets/1b7b6ccb-44e0-4051-a2b0-0a7c00c18a69)

<br/>

Payment Gateway Taxes settings 
----------------------------------------------------------------

https://woocommerce.com/document/setting-up-taxes-in-woocommerce/ 

The case when the Price includes Tax

General 

![image](https://github.com/user-attachments/assets/0bc69ea1-a6de-43dd-85cd-097841c6ded4)

Tax

![image](https://github.com/user-attachments/assets/6eb5886c-359a-4937-aa32-bb3ef5d84851)

Shipping Zone settings

![image](https://github.com/user-attachments/assets/9a181e0e-2254-42fc-a184-30800309a2d9)

![image](https://github.com/user-attachments/assets/b7a60083-1c0a-472c-937d-27790adfa7bf)


<br/>
