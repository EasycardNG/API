<?php 

//Access token
function getToken(){
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_URL,"https://identity.e-c.co.il/connect/token");
	curl_setopt($ch, CURLOPT_POST, 1);
	
	//Remove for production code. ONLY FOR TEST PURPOSES
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);

	$data = array('client_id'=>'terminal',
				  'grant_type'=>'terminal_rest_api',
				  'authorizationKey'=>'YOUR_TERMINAL_PRIVATE_KEY');
				  
	curl_setopt($ch, CURLOPT_POSTFIELDS, http_build_query($data));
	curl_setopt($ch, CURLOPT_HTTPHEADER, array('Content-Type: application/x-www-form-urlencoded'));

	// receive server response ...
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
	$server_output = curl_exec ($ch);
	curl_close ($ch);

	if($server_output){
		$response = json_decode($server_output);
		return $response->access_token;
	}
	//something went wrong
	return false;
}

function createPaymentIntent($amount){
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_URL,"https://api.e-c.co.il/api/paymentIntent");
	curl_setopt($ch, CURLOPT_POST, 1);
	
	//Remove for production code. ONLY FOR TEST PURPOSES
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);

	$callback_url =  "https://{$_SERVER['HTTP_HOST']}{$_SERVER['REQUEST_URI']}";
	$api_token = getToken();
	
	$data = array('currency'=>'ILS',
				  'dueDate'=>NULL,
				  'dealDetails'=> array(
					'consumerEmail' => 'email.@gmail.com',
					'consumerPhone' => '12345678',
					'consumerAddress' => array(
						'street' => 'some street',
					),
					'dealDescription' => 'Test deal',
				  ),
				  'consumerName'=>'Test Customer',
				  'redirectUrl'=>$callback_url,
				  'paymentRequestAmount' => $amount,
				  'userAmount'=>false, //when set to true allows user to change amount on checkout page
				  );
				  
	curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($data));
	curl_setopt($ch, CURLOPT_HTTPHEADER, array(
		'Content-Type: application/json',
		'Authorization: Bearer '.$api_token,
	));

	// receive server response ...
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
	$server_output = curl_exec ($ch);
	curl_close ($ch);
	
	var_dump($server_output);

	if($server_output){
		$response = json_decode($server_output);
		header('Location: '.$response->additionalData->url);
		die();
	}
	//something went wrong
	return false;
}

function getTransactionById($transactionID){
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_URL,"https://api.e-c.co.il/api/transactions/".$transactionID);
	//Remove for production code. ONLY FOR TEST PURPOSES
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);

	$api_token = getToken();
	
	curl_setopt($ch, CURLOPT_HTTPHEADER, array(
		'Authorization: Bearer '.$api_token,
	));

	// receive server response ...
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
	$server_output = curl_exec ($ch);
	curl_close ($ch);

	if($server_output){
		$response = json_decode($server_output);
		return $response;
	}
	//something went wrong
	return false;
}

$amount = 1;
if(isset($_POST["amount"])){
	$amount = $_POST["amount"];
	createPaymentIntent($amount);
}

$transactionID = NULL;
if(isset($_GET["transactionID"]) && $_GET["transactionID"]){
	$transactionID = $_GET["transactionID"];
	$transaction_info = getTransactionById($transactionID);
}

?>

<h2>Create payment intent</h2>

<form method="POST">
  <label for="amount">Amount:</label><br>
  <input type="number" id="amount" name="amount" value="<?= $amount ?>"><br>
  <input type="submit" value="Submit">
</form> 

<?php if (isset($transaction_info)): ?>
	<pre><?php print_r($transaction_info) ?></pre>
<?php endif ?>
