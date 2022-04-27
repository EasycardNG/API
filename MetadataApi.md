EasyCard Next Generation API v1 - _Metadata API_
=================================================================

# Authentication

* API Key (oauth2)
    - Parameter Name: **Authorization**, in: header. Standard Authorization header using the Bearer scheme. Example: "bearer {token}"

<h1 id="merchantprofile-api-consumersapi">ConsumersApi</h1>

## End-customers list (Auth policies: terminal_or_merchant_frontend)

`GET /api/consumers`

<h3 id="end-customers-list-(auth-policies:-terminal_or_merchant_frontend)-parameters">Parameters</h3>

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
|Take|query|integer(int32)|false|none|
|Skip|query|integer(int32)|false|none|
|SortBy|query|string|false|none|
|SortDesc|query|boolean|false|none|
|ShowDeleted|query|[ShowDeletedEnum](#schemashowdeletedenum)|false|none|

#### Enumerated Values

|Parameter|Value|
|---|---|
|ShowDeleted|OnlyActive|
|ShowDeleted|OnlyDeleted|
|ShowDeleted|All|

> Example responses

> 200 Response

```json
{
  "numberOfRecords": 0,
  "data": [
    {
      "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
      "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
      "consumerEmail": "string",
      "consumerName": "string",
      "consumerPhone": "string",
      "consumerNationalID": "string",
      "consumerAddress": {
        "countryCode": "string",
        "city": "string",
        "zip": "string",
        "street": "string",
        "house": "string",
        "apartment": "string"
      },
      "externalReference": "string"
    }
  ]
}
```

<h3 id="end-customers-list-(auth-policies:-terminal_or_merchant_frontend)-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[ConsumerSummarySummariesResponse](#schemaconsumersummarysummariesresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: terminal_or_merchant_frontend )
</aside>

## Create end-customer record (Auth policies: terminal_or_merchant_frontend)

`POST /api/consumers`

> Body parameter

```json
{
  "consumerEmail": "string",
  "consumerName": "string",
  "consumerPhone": "string",
  "consumerNationalID": "string",
  "note": "string",
  "consumerAddress": {
    "countryCode": "string",
    "city": "string",
    "zip": "string",
    "street": "string",
    "house": "string",
    "apartment": "string"
  },
  "externalReference": "string",
  "billingDesktopRefNumber": "string",
  "origin": "string",
  "active": true,
  "consumerSecondPhone": "string",
  "consumerNote": "string",
  "bankDetails": {
    "paymentType": "card",
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string"
  }
}
```

<h3 id="create-end-customer-record-(auth-policies:-terminal_or_merchant_frontend)-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[ConsumerRequest](#schemaconsumerrequest)|false|none|

> Example responses

> 201 Response

```json
{
  "message": "string",
  "status": "success",
  "entityID": 0,
  "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
  "entityReference": "string",
  "correlationId": "string",
  "entityType": "string",
  "errors": [
    {
      "code": "string",
      "description": "string"
    }
  ],
  "concurrencyToken": "string",
  "innerResponse": {
    "message": "string",
    "status": "success",
    "entityID": 0,
    "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
    "entityReference": "string",
    "correlationId": "string",
    "entityType": "string",
    "errors": [
      {
        "code": "string",
        "description": "string"
      }
    ],
    "concurrencyToken": "string",
    "innerResponse": {},
    "additionalData": {
      "property1": [
        []
      ],
      "property2": [
        []
      ]
    }
  },
  "additionalData": {
    "property1": [
      []
    ],
    "property2": [
      []
    ]
  }
}
```

<h3 id="create-end-customer-record-(auth-policies:-terminal_or_merchant_frontend)-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: terminal_or_merchant_frontend )
</aside>

## End-customer details (Auth policies: terminal_or_merchant_frontend)

`GET /api/consumers/{consumerID}`

<h3 id="end-customer-details-(auth-policies:-terminal_or_merchant_frontend)-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|consumerID|path|string(uuid)|true|none|

> Example responses

> 200 Response

```json
{
  "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
  "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
  "active": true,
  "updateTimestamp": "string",
  "consumerEmail": "string",
  "consumerName": "string",
  "consumerPhone": "string",
  "consumerAddress": {
    "countryCode": "string",
    "city": "string",
    "zip": "string",
    "street": "string",
    "house": "string",
    "apartment": "string"
  },
  "consumerNationalID": "string",
  "created": "2019-08-24T14:15:22Z",
  "operationDoneBy": "string",
  "correlationId": "string",
  "externalReference": "string",
  "origin": "string",
  "billingDesktopRefNumber": "string",
  "consumerSecondPhone": "string",
  "consumerNote": "string",
  "bankDetails": {
    "paymentType": "card",
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string"
  }
}
```

<h3 id="end-customer-details-(auth-policies:-terminal_or_merchant_frontend)-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[ConsumerResponse](#schemaconsumerresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: terminal_or_merchant_frontend )
</aside>

## Update end-customer details (Auth policies: terminal_or_merchant_frontend)

`PUT /api/consumers/{consumerID}`

> Body parameter

```json
{
  "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
  "consumerEmail": "user@example.com",
  "consumerName": "string",
  "consumerPhone": "string",
  "consumerNationalID": "string",
  "consumerAddress": {
    "countryCode": "string",
    "city": "string",
    "zip": "string",
    "street": "string",
    "house": "string",
    "apartment": "string"
  },
  "externalReference": "string",
  "origin": "string",
  "updateTimestamp": "string",
  "consumerSecondPhone": "string",
  "billingDesktopRefNumber": "string",
  "active": true,
  "bankDetails": {
    "paymentType": "card",
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string"
  }
}
```

<h3 id="update-end-customer-details-(auth-policies:-terminal_or_merchant_frontend)-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|consumerID|path|string(uuid)|true|none|
|body|body|[UpdateConsumerRequest](#schemaupdateconsumerrequest)|false|none|

> Example responses

> 200 Response

```json
{
  "message": "string",
  "status": "success",
  "entityID": 0,
  "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
  "entityReference": "string",
  "correlationId": "string",
  "entityType": "string",
  "errors": [
    {
      "code": "string",
      "description": "string"
    }
  ],
  "concurrencyToken": "string",
  "innerResponse": {
    "message": "string",
    "status": "success",
    "entityID": 0,
    "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
    "entityReference": "string",
    "correlationId": "string",
    "entityType": "string",
    "errors": [
      {
        "code": "string",
        "description": "string"
      }
    ],
    "concurrencyToken": "string",
    "innerResponse": {},
    "additionalData": {
      "property1": [
        []
      ],
      "property2": [
        []
      ]
    }
  },
  "additionalData": {
    "property1": [
      []
    ],
    "property2": [
      []
    ]
  }
}
```

<h3 id="update-end-customer-details-(auth-policies:-terminal_or_merchant_frontend)-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: terminal_or_merchant_frontend )
</aside>

## Delete end-customer record (Auth policies: terminal_or_merchant_frontend)

`DELETE /api/consumers/{consumerID}`

<h3 id="delete-end-customer-record-(auth-policies:-terminal_or_merchant_frontend)-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|consumerID|path|string(uuid)|true|none|

> Example responses

> 200 Response

```json
{
  "message": "string",
  "status": "success",
  "entityID": 0,
  "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
  "entityReference": "string",
  "correlationId": "string",
  "entityType": "string",
  "errors": [
    {
      "code": "string",
      "description": "string"
    }
  ],
  "concurrencyToken": "string",
  "innerResponse": {
    "message": "string",
    "status": "success",
    "entityID": 0,
    "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
    "entityReference": "string",
    "correlationId": "string",
    "entityType": "string",
    "errors": [
      {
        "code": "string",
        "description": "string"
      }
    ],
    "concurrencyToken": "string",
    "innerResponse": {},
    "additionalData": {
      "property1": [
        []
      ],
      "property2": [
        []
      ]
    }
  },
  "additionalData": {
    "property1": [
      []
    ],
    "property2": [
      []
    ]
  }
}
```

<h3 id="delete-end-customer-record-(auth-policies:-terminal_or_merchant_frontend)-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: terminal_or_merchant_frontend )
</aside>

## Delete customers (Auth policies: terminal_or_merchant_frontend)

`POST /api/consumers/bulkdelete`

> Body parameter

```json
[
  "497f6eca-6276-4993-bfeb-53cbbbba6f08"
]
```

> Example responses

> 200 Response

```json
{
  "message": "string",
  "status": "success",
  "entityID": 0,
  "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
  "entityReference": "string",
  "correlationId": "string",
  "entityType": "string",
  "errors": [
    {
      "code": "string",
      "description": "string"
    }
  ],
  "concurrencyToken": "string",
  "innerResponse": {
    "message": "string",
    "status": "success",
    "entityID": 0,
    "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
    "entityReference": "string",
    "correlationId": "string",
    "entityType": "string",
    "errors": [
      {
        "code": "string",
        "description": "string"
      }
    ],
    "concurrencyToken": "string",
    "innerResponse": {},
    "additionalData": {
      "property1": [
        []
      ],
      "property2": [
        []
      ]
    }
  },
  "additionalData": {
    "property1": [
      []
    ],
    "property2": [
      []
    ]
  }
}
```

<h3 id="delete-customers-(auth-policies:-terminal_or_merchant_frontend)-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: terminal_or_merchant_frontend )
</aside>

<h1 id="merchantprofile-api-home">Home</h1>

## get__config

`GET /config`

<h3 id="get__config-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="merchantprofile-api-itemsapi">ItemsApi</h1>

##  (Auth policies: terminal_or_merchant_frontend)

`DELETE /api/items/{itemID}`

<h3 id="-(auth-policies:-terminal_or_merchant_frontend)-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|itemID|path|string(uuid)|true|none|

> Example responses

> 200 Response

```json
{
  "message": "string",
  "status": "success",
  "entityID": 0,
  "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
  "entityReference": "string",
  "correlationId": "string",
  "entityType": "string",
  "errors": [
    {
      "code": "string",
      "description": "string"
    }
  ],
  "concurrencyToken": "string",
  "innerResponse": {
    "message": "string",
    "status": "success",
    "entityID": 0,
    "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
    "entityReference": "string",
    "correlationId": "string",
    "entityType": "string",
    "errors": [
      {
        "code": "string",
        "description": "string"
      }
    ],
    "concurrencyToken": "string",
    "innerResponse": {},
    "additionalData": {
      "property1": [
        []
      ],
      "property2": [
        []
      ]
    }
  },
  "additionalData": {
    "property1": [
      []
    ],
    "property2": [
      []
    ]
  }
}
```

<h3 id="-(auth-policies:-terminal_or_merchant_frontend)-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: terminal_or_merchant_frontend )
</aside>

## Delete items (Auth policies: terminal_or_merchant_frontend)

`POST /api/items/bulkdelete`

> Body parameter

```json
[
  "497f6eca-6276-4993-bfeb-53cbbbba6f08"
]
```

> Example responses

> 200 Response

```json
{
  "message": "string",
  "status": "success",
  "entityID": 0,
  "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
  "entityReference": "string",
  "correlationId": "string",
  "entityType": "string",
  "errors": [
    {
      "code": "string",
      "description": "string"
    }
  ],
  "concurrencyToken": "string",
  "innerResponse": {
    "message": "string",
    "status": "success",
    "entityID": 0,
    "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
    "entityReference": "string",
    "correlationId": "string",
    "entityType": "string",
    "errors": [
      {
        "code": "string",
        "description": "string"
      }
    ],
    "concurrencyToken": "string",
    "innerResponse": {},
    "additionalData": {
      "property1": [
        []
      ],
      "property2": [
        []
      ]
    }
  },
  "additionalData": {
    "property1": [
      []
    ],
    "property2": [
      []
    ]
  }
}
```

<h3 id="delete-items-(auth-policies:-terminal_or_merchant_frontend)-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: terminal_or_merchant_frontend )
</aside>

# Schemas

<h2 id="tocS_Address">Address</h2>
<!-- backwards compatibility -->
<a id="schemaaddress"></a>
<a id="schema_Address"></a>
<a id="tocSaddress"></a>
<a id="tocsaddress"></a>

```json
{
  "countryCode": "string",
  "city": "string",
  "zip": "string",
  "street": "string",
  "house": "string",
  "apartment": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|countryCode|string¦null|false|none|none|
|city|string¦null|false|none|none|
|zip|string¦null|false|none|none|
|street|string¦null|false|none|none|
|house|string¦null|false|none|none|
|apartment|string¦null|false|none|none|

<h2 id="tocS_BankDetails">BankDetails</h2>
<!-- backwards compatibility -->
<a id="schemabankdetails"></a>
<a id="schema_BankDetails"></a>
<a id="tocSbankdetails"></a>
<a id="tocsbankdetails"></a>

```json
{
  "paymentType": "card",
  "bank": 0,
  "bankBranch": 0,
  "bankAccount": "string"
}

```

### Properties

*None*

<h2 id="tocS_ConsumerRequest">ConsumerRequest</h2>
<!-- backwards compatibility -->
<a id="schemaconsumerrequest"></a>
<a id="schema_ConsumerRequest"></a>
<a id="tocSconsumerrequest"></a>
<a id="tocsconsumerrequest"></a>

```json
{
  "consumerEmail": "string",
  "consumerName": "string",
  "consumerPhone": "string",
  "consumerNationalID": "string",
  "note": "string",
  "consumerAddress": {
    "countryCode": "string",
    "city": "string",
    "zip": "string",
    "street": "string",
    "house": "string",
    "apartment": "string"
  },
  "externalReference": "string",
  "billingDesktopRefNumber": "string",
  "origin": "string",
  "active": true,
  "consumerSecondPhone": "string",
  "consumerNote": "string",
  "bankDetails": {
    "paymentType": "card",
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string"
  }
}

```

Create consumer

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|consumerEmail|string¦null|false|none|End-customer Email|
|consumerName|string|true|none|End-customer name|
|consumerPhone|string¦null|false|none|End-customer Phone|
|consumerNationalID|string¦null|false|none|End-customer National ID|
|note|string¦null|false|none|End-customer note details|

<h2 id="tocS_ConsumerResponse">ConsumerResponse</h2>
<!-- backwards compatibility -->
<a id="schemaconsumerresponse"></a>
<a id="schema_ConsumerResponse"></a>
<a id="tocSconsumerresponse"></a>
<a id="tocsconsumerresponse"></a>

```json
{
  "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
  "merchantID": "c30c8496-c2db-425f-8614-0e5f16767e31",
  "active": true,
  "updateTimestamp": "string",
  "consumerEmail": "string",
  "consumerName": "string",
  "consumerPhone": "string",
  "consumerAddress": {
    "countryCode": "string",
    "city": "string",
    "zip": "string",
    "street": "string",
    "house": "string",
    "apartment": "string"
  },
  "consumerNationalID": "string",
  "created": "2019-08-24T14:15:22Z",
  "operationDoneBy": "string",
  "correlationId": "string",
  "externalReference": "string",
  "origin": "string",
  "billingDesktopRefNumber": "string",
  "consumerSecondPhone": "string",
  "consumerNote": "string",
  "bankDetails": {
    "paymentType": "card",
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|consumerID|string(uuid)|false|none|none|
|merchantID|string(uuid)|false|none|none|
|active|boolean|false|none|none|
|updateTimestamp|string(byte)¦null|false|none|none|
|consumerEmail|string¦null|false|none|End-customer Email|
|consumerName|string¦null|false|none|none|
|consumerPhone|string¦null|false|none|End-customer Phone|

<h2 id="tocS_ConsumerSummary">ConsumerSummary</h2>
<!-- backwards compatibility -->
<a id="schemaconsumersummary"></a>
<a id="schema_ConsumerSummary"></a>
<a id="tocSconsumersummary"></a>
<a id="tocsconsumersummary"></a>

```json
{
  "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
  "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
  "consumerEmail": "string",
  "consumerName": "string",
  "consumerPhone": "string",
  "consumerNationalID": "string",
  "consumerAddress": {
    "countryCode": "string",
    "city": "string",
    "zip": "string",
    "street": "string",
    "house": "string",
    "apartment": "string"
  },
  "externalReference": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|consumerID|string(uuid)|false|none|none|
|terminalID|string(uuid)|false|none|none|
|consumerEmail|string¦null|false|none|End-customer Email|
|consumerName|string¦null|false|none|none|
|consumerPhone|string¦null|false|none|none|
|consumerNationalID|string¦null|false|none|none|

<h2 id="tocS_ConsumerSummarySummariesResponse">ConsumerSummarySummariesResponse</h2>
<!-- backwards compatibility -->
<a id="schemaconsumersummarysummariesresponse"></a>
<a id="schema_ConsumerSummarySummariesResponse"></a>
<a id="tocSconsumersummarysummariesresponse"></a>
<a id="tocsconsumersummarysummariesresponse"></a>

```json
{
  "numberOfRecords": 0,
  "data": [
    {
      "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
      "terminalID": "57d5dd68-4280-44f6-a8f7-547180e3a1d6",
      "consumerEmail": "string",
      "consumerName": "string",
      "consumerPhone": "string",
      "consumerNationalID": "string",
      "consumerAddress": {
        "countryCode": "string",
        "city": "string",
        "zip": "string",
        "street": "string",
        "house": "string",
        "apartment": "string"
      },
      "externalReference": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|numberOfRecords|integer(int32)|false|none|none|
|data|[[ConsumerSummary](#schemaconsumersummary)]¦null|false|none|none|

<h2 id="tocS_CurrencyEnum">CurrencyEnum</h2>
<!-- backwards compatibility -->
<a id="schemacurrencyenum"></a>
<a id="schema_CurrencyEnum"></a>
<a id="tocScurrencyenum"></a>
<a id="tocscurrencyenum"></a>

```json
"ILS"

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|integer(int32)|false|none|none|

#### Enumerated Values

|Property|Value|
|---|---|
|*anonymous*|ILS|
|*anonymous*|USD|
|*anonymous*|EUR|

<h2 id="tocS_Error">Error</h2>
<!-- backwards compatibility -->
<a id="schemaerror"></a>
<a id="schema_Error"></a>
<a id="tocSerror"></a>
<a id="tocserror"></a>

```json
{
  "code": "string",
  "description": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|code|string¦null|false|none|none|
|description|string¦null|false|none|none|

<h2 id="tocS_ItemRequest">ItemRequest</h2>
<!-- backwards compatibility -->
<a id="schemaitemrequest"></a>
<a id="schema_ItemRequest"></a>
<a id="tocSitemrequest"></a>
<a id="tocsitemrequest"></a>

```json
{
  "itemName": "string",
  "price": 0,
  "active": true,
  "currency": "ILS",
  "externalReference": "string",
  "billingDesktopRefNumber": "string",
  "sku": "string",
  "origin": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|itemName|string|true|none|none|
|price|number(double)|false|none|none|
|active|boolean¦null|false|none|none|

<h2 id="tocS_ItemResponse">ItemResponse</h2>
<!-- backwards compatibility -->
<a id="schemaitemresponse"></a>
<a id="schema_ItemResponse"></a>
<a id="tocSitemresponse"></a>
<a id="tocsitemresponse"></a>

```json
{
  "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
  "updateTimestamp": "string",
  "itemName": "string",
  "price": 0,
  "currency": "ILS",
  "created": "2019-08-24T14:15:22Z",
  "operationDoneBy": "string",
  "correlationId": "string",
  "externalReference": "string",
  "billingDesktopRefNumber": "string",
  "sku": "string",
  "active": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|itemID|string(uuid)|false|none|none|
|updateTimestamp|string(byte)¦null|false|none|none|
|itemName|string¦null|false|none|none|
|price|number(double)|false|none|none|

<h2 id="tocS_ItemSummary">ItemSummary</h2>
<!-- backwards compatibility -->
<a id="schemaitemsummary"></a>
<a id="schema_ItemSummary"></a>
<a id="tocSitemsummary"></a>
<a id="tocsitemsummary"></a>

```json
{
  "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
  "itemName": "string",
  "price": 0,
  "currency": "ILS",
  "externalReference": "string",
  "billingDesktopRefNumber": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|itemID|string(uuid)|false|none|none|
|itemName|string¦null|false|none|none|
|price|number(double)¦null|false|none|none|

<h2 id="tocS_ItemSummarySummariesResponse">ItemSummarySummariesResponse</h2>
<!-- backwards compatibility -->
<a id="schemaitemsummarysummariesresponse"></a>
<a id="schema_ItemSummarySummariesResponse"></a>
<a id="tocSitemsummarysummariesresponse"></a>
<a id="tocsitemsummarysummariesresponse"></a>

```json
{
  "numberOfRecords": 0,
  "data": [
    {
      "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
      "itemName": "string",
      "price": 0,
      "currency": "ILS",
      "externalReference": "string",
      "billingDesktopRefNumber": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|numberOfRecords|integer(int32)|false|none|none|
|data|[[ItemSummary](#schemaitemsummary)]¦null|false|none|none|

<h2 id="tocS_JToken">JToken</h2>
<!-- backwards compatibility -->
<a id="schemajtoken"></a>
<a id="schema_JToken"></a>
<a id="tocSjtoken"></a>
<a id="tocsjtoken"></a>

```json
[
  [
    []
  ]
]

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[JToken](#schemajtoken)]|false|none|none|

<h2 id="tocS_OperationResponse">OperationResponse</h2>
<!-- backwards compatibility -->
<a id="schemaoperationresponse"></a>
<a id="schema_OperationResponse"></a>
<a id="tocSoperationresponse"></a>
<a id="tocsoperationresponse"></a>

```json
{
  "message": "string",
  "status": "success",
  "entityID": 0,
  "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
  "entityReference": "string",
  "correlationId": "string",
  "entityType": "string",
  "errors": [
    {
      "code": "string",
      "description": "string"
    }
  ],
  "concurrencyToken": "string",
  "innerResponse": {
    "message": "string",
    "status": "success",
    "entityID": 0,
    "entityUID": "1a366e78-0ad8-4c6d-9367-977d46d0652e",
    "entityReference": "string",
    "correlationId": "string",
    "entityType": "string",
    "errors": [
      {
        "code": "string",
        "description": "string"
      }
    ],
    "concurrencyToken": "string",
    "innerResponse": {},
    "additionalData": {
      "property1": [
        []
      ],
      "property2": [
        []
      ]
    }
  },
  "additionalData": {
    "property1": [
      []
    ],
    "property2": [
      []
    ]
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|message|string¦null|false|none|none|

<h2 id="tocS_PaymentTypeEnum">PaymentTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemapaymenttypeenum"></a>
<a id="schema_PaymentTypeEnum"></a>
<a id="tocSpaymenttypeenum"></a>
<a id="tocspaymenttypeenum"></a>

```json
"card"

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|integer(int32)|false|none|none|

#### Enumerated Values

|Property|Value|
|---|---|
|*anonymous*|card|
|*anonymous*|cheque|
|*anonymous*|cash|
|*anonymous*|bank|

<h2 id="tocS_ShowDeletedEnum">ShowDeletedEnum</h2>
<!-- backwards compatibility -->
<a id="schemashowdeletedenum"></a>
<a id="schema_ShowDeletedEnum"></a>
<a id="tocSshowdeletedenum"></a>
<a id="tocsshowdeletedenum"></a>

```json
"OnlyActive"

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|integer(int32)|false|none|none|

#### Enumerated Values

|Property|Value|
|---|---|
|*anonymous*|OnlyActive|
|*anonymous*|OnlyDeleted|
|*anonymous*|All|

<h2 id="tocS_StatusEnum">StatusEnum</h2>
<!-- backwards compatibility -->
<a id="schemastatusenum"></a>
<a id="schema_StatusEnum"></a>
<a id="tocSstatusenum"></a>
<a id="tocsstatusenum"></a>

```json
"success"

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|integer(int32)|false|none|none|

#### Enumerated Values

|Property|Value|
|---|---|
|*anonymous*|success|
|*anonymous*|warning|
|*anonymous*|error|

<h2 id="tocS_UpdateConsumerRequest">UpdateConsumerRequest</h2>
<!-- backwards compatibility -->
<a id="schemaupdateconsumerrequest"></a>
<a id="schema_UpdateConsumerRequest"></a>
<a id="tocSupdateconsumerrequest"></a>
<a id="tocsupdateconsumerrequest"></a>

```json
{
  "consumerID": "9e541e9d-045d-45e2-8cf0-ead10a4f23cf",
  "consumerEmail": "user@example.com",
  "consumerName": "string",
  "consumerPhone": "string",
  "consumerNationalID": "string",
  "consumerAddress": {
    "countryCode": "string",
    "city": "string",
    "zip": "string",
    "street": "string",
    "house": "string",
    "apartment": "string"
  },
  "externalReference": "string",
  "origin": "string",
  "updateTimestamp": "string",
  "consumerSecondPhone": "string",
  "billingDesktopRefNumber": "string",
  "active": true,
  "bankDetails": {
    "paymentType": "card",
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string"
  }
}

```

Update end-customer info

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|consumerID|string(uuid)|true|none|Target record ID|
|consumerEmail|string(email)¦null|false|none|End-customer Email|
|consumerName|string|true|none|End-customer name|
|consumerPhone|string¦null|false|none|End-customer Phone|
|consumerNationalID|string¦null|false|none|End-customer National ID|

<h2 id="tocS_UpdateItemRequest">UpdateItemRequest</h2>
<!-- backwards compatibility -->
<a id="schemaupdateitemrequest"></a>
<a id="schema_UpdateItemRequest"></a>
<a id="tocSupdateitemrequest"></a>
<a id="tocsupdateitemrequest"></a>

```json
{
  "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
  "itemName": "string",
  "price": 0,
  "currency": "ILS",
  "updateTimestamp": "string",
  "externalReference": "string",
  "sku": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|itemID|string(uuid)|false|none|none|
|itemName|string|true|none|none|
|price|number(double)|false|none|none|

