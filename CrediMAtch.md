Integration with CREDIMATCH
=================================
Comprehensive, automated platform for credit card reconciliation in medium and large businesses. Its system helps businesses monitor, control, and match all credit card transactions from the point of sale to the bank account, ensuring they are correctly charged and credited.
CrediMatch provides a flexible API for integrating its credit card reconciliation system with a business's existing accounting or ERP software. The API allows for the automatic transfer of data to ensure all transactions are accounted for, from the initial swipe to the bank deposit.

<img width="355" height="292" alt="image" src="https://github.com/user-attachments/assets/c17a92ca-f95f-4eda-974c-ae705a034a25" />

Integration with CREDIMATCH. TERMINAL SETTINGS (The same for all Easy Card merchants)

Add new Integration "Reconciliation Service"- 

<img width="762" height="398" alt="image" src="https://github.com/user-attachments/assets/d5e3e4fb-11be-4693-a8fd-e1b95fe5a6bb" />

Fill the form for CrediMatch – the same data for all Easy card merchants

User Name: api@easycard.co.il

Password: jC4@lwICg3x5

ID Invoice 8abe6a88-aed4-4bc8-af09-c8aea4a93058

<img width="1629" height="219" alt="image" src="https://github.com/user-attachments/assets/9ef2c4c0-baf6-4447-aa8e-f40060e98d0c" />


In our case, if Terminal is defined as the CrediMatch terminal:
-	After transmission transaction get status "Awaiting for Reconciliation" ממתין לשליחה למערכת התאמות: 
-	Daily, we send a  request to CrediMatch to verify that the transmission data is valid
-	If request passed- Transaction change status as "Done"
-	If the request to CrediMatch failed- transaction Status changed as  Transaction status  Failed to send to Reconciliation service-נכשל משלוח למערכת התאמות   

------------------------------------------------------------------------------------------------------------------------------------------------------------

