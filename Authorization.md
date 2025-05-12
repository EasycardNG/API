Authentication
-----------------------------------------------------------------

### Authentication/Authorization type

* Bearer (oauth2)
    - Parameter Name: **Authorization**, in: header. Standard Authorization header using the Bearer scheme. Example: `bearer {access_token}`

### Get Access Token

`POST {{IdentityServerAddress}}/connect/token`

> Live Identity Server Address is [https://identity.e-c.co.il](https://identity.e-c.co.il)

> Headers

|Name|Value|
|---|---|
|Content-Type|application/x-www-form-urlencoded|
|Content-Length| calculated when request is sent|
|Host|calculated when request is sent|

![image](https://github.com/user-attachments/assets/804c59ec-bde3-44b4-bb76-eed1a478837a)






|Name|Value|
|---|---|
|client_id|terminal|
|grant_type|terminal_rest_api|
|authorizationKey|{{TerminalApiKey}}|

![image](https://github.com/user-attachments/assets/916f35ac-7beb-4ace-8a23-47baa91dbb27)


You can get `TerminalApiKey` by using `Reset Private Key` button on merchant's portal:

![Reset Private Key](images/ResetApiKey.PNG)

> Please note - you need to store given key securely. You cannot get active value from the merchant's portal - you only can reset current value (new key will be generated and old key will be no longer valid)

> Response
```

```json

{
    "access_token": "eyJhbGciOiJSUzI1NsImtpZCI6Ij.....q7MQ8jfwbQ_JKJif_7lTuiVhOGWA",
    "expires_in": 86400,
    "token_type": "Bearer",
    "scope": "transactions_api"
}

```

|Name|Type|Description|
|---|---|---|
|access_token|string|Value which should be added to each API request in Authorization header with Bearer prefix `Bearer {{access_token}}`|
|expires_in|number|number of seconds before token will be expires|
|access_token|string|always Bearer|
|scope|string|API scope|

> Body parameter (`x-www-form-urlencoded`)
PHP
> 
```php
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
?>
```
C#
```C#
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class TokenResponse
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }
}

public class Program
{
    static async Task<string> GetTokenAsync()
    {
        var url = "https://identity.e-c.co.il/connect/token";

        // Data to send in the request
        var data = new
        {
            client_id = "terminal",
            grant_type = "terminal_rest_api",
            authorizationKey = "YOUR_TERMINAL_PRIVATE_KEY"
        };

        using (var httpClient = new HttpClient())
        {
            // For testing purposes; in production, remove this line
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/x-www-form-urlencoded");

            // Sending POST request
            var response = await httpClient.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseString);
                return tokenResponse?.AccessToken;
            }
            else
            {
                // Handle error or return null
                return null;
            }
        }
    }

    static async Task Main(string[] args)
    {
        var token = await GetTokenAsync();
        Console.WriteLine($"Access Token: {token}");
    }
}
```
Node.js

```Node.js
const axios = require('axios');
const qs = require('qs');

async function getToken() {
  try {
    const url = 'https://identity.e-c.co.il/connect/token';

    const data = {
      client_id: 'terminal',
      grant_type: 'terminal_rest_api',
      authorizationKey: 'YOUR_TERMINAL_PRIVATE_KEY'
    };

    const response = await axios.post(url, qs.stringify(data), {
      headers: {
        'Content-Type': 'application/x-www-form-urlencoded'
      },
      // For testing only: ignore SSL certificate (use with caution!)
      httpsAgent: new (require('https').Agent)({ rejectUnauthorized: false })
    });

    return response.data.access_token;
  } catch (error) {
    console.error('Error fetching token:', error.response?.data || error.message);
    return false;
  }
}

// Example usage
getToken().then(token => {
  if (token) {
    console.log('Access token:', token);
  } else {
    console.log('Failed to retrieve token');
  }
});
```
<br/><br/>
