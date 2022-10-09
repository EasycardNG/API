<!-- Generator: Widdershins v4.0.1 -->

<h1 id="easycard-metadata-api">EasyCard Metadata API v1</h1>

-----------------------------------------------------------------
> Please refer to Full API description if you need most recent development version

Metadata API development version [https://ecng-profile.azurewebsites.net/api-docs/index.html](https://ecng-profile.azurewebsites.net/api-docs/index.html)

Live version [https://merchant.e-c.co.il/api-docs/index.html](https://merchant.e-c.co.il/api-docs/index.html)


- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

> Scroll down for example requests and responses.

- [Authentication](Readme.md#authentication)
- [Environments](Readme.md#environments)
- [Examples](Readme.md#examples)
- [ConsumersApi](#consumersapi)
  - [Get Consumers list](#get-consumers-list)
  - [Create Consumer record](#create-consumer-record)
  - [Get Consumer details](#get-consumer-details)
  - [Update Consumer details](#update-consumer-details)
  - [Delete end-customer record and all related data like card tokens, billings, etc.](#delete-end-customer-record-and-all-related-data-like-card-tokens-billings-etc)
  - [Restore (un-delete) customer](#restore-un-delete-customer)
  - [Delete Consumer record](#delete-consumer-record)
- [ItemsApi](#itemsapi)
  - [Get custom selling Items](#get-custom-selling-items)
  - [Create new custom Item](#create-new-custom-item)
  - [Get Item by ID](#get-item-by-id)
  - [Update Item](#update-item)
  - [Delete Item](#delete-item)
  - [Delete sevaral items](#delete-sevaral-items)
- [Schemas](#schemas)


# ConsumersApi

## Get Consumers list

`GET /api/consumers`

<h3 id="get-consumers-list-parameters">Parameters</h3>

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
|WoocommerceID|query|string|false|External ID inside https://woocommerce.com system|
|EcwidID|query|string|false|External ID inside https://www.ecwid.com system|
|Take|query|integer(int32)|false|none|
|Skip|query|integer(int32)|false|none|
|SortBy|query|string|false|none|
|SortDesc|query|boolean|false|none|
|ShowDeleted|query|[ShowDeletedEnum](#schemashowdeletedenum)|false|none|

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
      "externalReference": "string",
      "woocommerceID": "string",
      "ecwidID": "string",
      "active": true,
      "hasBankAccount": true,
      "hasCreditCard": true
    }
  ]
}
```

<h3 id="get-consumers-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[SummariesResponse_ConsumerSummary](#schemasummariesresponse_consumersummary)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
</aside>

## Create Consumer record

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
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "woocommerceID": "string",
  "ecwidID": "string"
}
```

<h3 id="create-consumer-record-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[ConsumerRequest](#schemaconsumerrequest)|false|New Consumer details|

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
    "additionalData": null
  },
  "additionalData": null
}
```

<h3 id="create-consumer-record-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Created|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
</aside>

## Get Consumer details

`GET /api/consumers/{consumerID}`

<h3 id="get-consumer-details-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|consumerID|path|string(uuid)|true|Consumer ID|

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
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "woocommerceID": "string",
  "ecwidID": "string"
}
```

<h3 id="get-consumer-details-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[ConsumerResponse](#schemaconsumerresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
</aside>

## Update Consumer details

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
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "woocommerceID": "string",
  "ecwidID": "string"
}
```

<h3 id="update-consumer-details-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|consumerID|path|string(uuid)|true|Consumer ID|
|body|body|[UpdateConsumerRequest](#schemaupdateconsumerrequest)|false|Consumer details|

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
    "additionalData": null
  },
  "additionalData": null
}
```

<h3 id="update-consumer-details-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
</aside>

## Delete end-customer record and all related data like card tokens, billings, etc.

`DELETE /api/consumers/{consumerID}`

<h3 id="delete-end-customer-record-and-all-related-data-like-card-tokens,-billings,-etc.-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|consumerID|path|string(uuid)|true|Consumer ID|

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
    "additionalData": null
  },
  "additionalData": null
}
```

<h3 id="delete-end-customer-record-and-all-related-data-like-card-tokens,-billings,-etc.-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
</aside>

## Restore (un-delete) customer

`PUT /api/consumers/restore/{consumerID}`

<h3 id="restore-(un-delete)-customer-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|consumerID|path|string(uuid)|true|Consumer ID|

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
    "additionalData": null
  },
  "additionalData": null
}
```

<h3 id="restore-(un-delete)-customer-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
</aside>

## Delete Consumer record

`POST /api/consumers/bulkdelete`

> Body parameter

```json
[
  "497f6eca-6276-4993-bfeb-53cbbbba6f08"
]
```

<h3 id="delete-consumer-record-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|array[string]|false|IDs of Consumers to delete|

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
    "additionalData": null
  },
  "additionalData": null
}
```

<h3 id="delete-consumer-record-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
</aside>

# ItemsApi

## Get custom selling Items

`GET /api/items`

<h3 id="get-custom-selling-items-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|Search|query|string|false|none|
|Currency|query|[CurrencyEnum](#schemacurrencyenum)|false|none|
|TerminalID|query|string(uuid)|false|none|
|ExternalReference|query|string|false|none|
|BillingDesktopRefNumber|query|string|false|none|
|Origin|query|string|false|none|
|WoocommerceID|query|string|false|External ID inside https://woocommerce.com system|
|EcwidID|query|string|false|External ID inside https://www.ecwid.com system|
|Take|query|integer(int32)|false|none|
|Skip|query|integer(int32)|false|none|
|SortBy|query|string|false|none|
|SortDesc|query|boolean|false|none|
|ShowDeleted|query|[ShowDeletedEnum](#schemashowdeletedenum)|false|none|

> Example responses

> 200 Response

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
      "billingDesktopRefNumber": "string",
      "woocommerceID": "string",
      "ecwidID": "string"
    }
  ]
}
```

<h3 id="get-custom-selling-items-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[SummariesResponse_ItemSummary](#schemasummariesresponse_itemsummary)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
</aside>

## Create new custom Item

`POST /api/items`

> Body parameter

```json
{
  "itemName": "string",
  "price": 0,
  "active": true,
  "currency": "ILS",
  "externalReference": "string",
  "billingDesktopRefNumber": "string",
  "sku": "string",
  "origin": "string",
  "woocommerceID": "string",
  "ecwidID": "string"
}
```

<h3 id="create-new-custom-item-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[ItemRequest](#schemaitemrequest)|false|New Item details|

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
    "additionalData": null
  },
  "additionalData": null
}
```

<h3 id="create-new-custom-item-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Created|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
</aside>

## Get Item by ID

`GET /api/items/{itemID}`

<h3 id="get-item-by-id-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|itemID|path|string(uuid)|true|Item ID|

> Example responses

> 200 Response

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
  "active": true,
  "woocommerceID": "string",
  "ecwidID": "string"
}
```

<h3 id="get-item-by-id-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[ItemResponse](#schemaitemresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
</aside>

## Update Item

`PUT /api/items/{itemID}`

> Body parameter

```json
{
  "itemID": "f1f85a48-b9b1-447d-a06c-c1acf57ed3a8",
  "itemName": "string",
  "price": 0,
  "currency": "ILS",
  "updateTimestamp": "string",
  "externalReference": "string",
  "sku": "string",
  "woocommerceID": "string",
  "ecwidID": "string"
}
```

<h3 id="update-item-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|itemID|path|string(uuid)|true|Item ID|
|body|body|[UpdateItemRequest](#schemaupdateitemrequest)|false|Update exusting Item details|

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
    "additionalData": null
  },
  "additionalData": null
}
```

<h3 id="update-item-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
</aside>

## Delete Item

`DELETE /api/items/{itemID}`

<h3 id="delete-item-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|itemID|path|string(uuid)|true|Item ID|

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
    "additionalData": null
  },
  "additionalData": null
}
```

<h3 id="delete-item-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
</aside>

## Delete sevaral items

`POST /api/items/bulkdelete`

> Body parameter

```json
[
  "497f6eca-6276-4993-bfeb-53cbbbba6f08"
]
```

<h3 id="delete-sevaral-items-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|array[string]|false|IDs of Itms to delete|

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
    "additionalData": null
  },
  "additionalData": null
}
```

<h3 id="delete-sevaral-items-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[OperationResponse](#schemaoperationresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None ( Scopes: terminal_or_merchant_frontend )
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
  "bank": 0,
  "bankBranch": 0,
  "bankAccount": "string",
  "paymentType": "card",
  "amount": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|bank|integer(int32)|true|none|none|
|bankBranch|integer(int32)|true|none|none|
|bankAccount|string|true|none|none|
|paymentType|[PaymentTypeEnum](#schemapaymenttypeenum)|false|none|card<br><br>cheque<br><br>cash<br><br>bank|
|amount|number(double)|false|none|none|

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
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "woocommerceID": "string",
  "ecwidID": "string"
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
|consumerAddress|[Address](#schemaaddress)|false|none|none|
|externalReference|string¦null|false|none|ID in external system|
|billingDesktopRefNumber|string¦null|false|none|ID in BillingDesktop system|
|origin|string¦null|false|none|Origin of customer|
|active|boolean¦null|false|none|none|
|consumerSecondPhone|string¦null|false|none|none|
|consumerNote|string¦null|false|none|none|
|bankDetails|[BankDetails](#schemabankdetails)|false|none|none|
|woocommerceID|string¦null|false|none|External ID inside https://woocommerce.com system|
|ecwidID|string¦null|false|none|External ID inside https://www.ecwid.com system|

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
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "woocommerceID": "string",
  "ecwidID": "string"
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
|consumerAddress|[Address](#schemaaddress)|false|none|none|
|consumerNationalID|string¦null|false|none|none|
|created|string(date-time)¦null|false|none|none|
|operationDoneBy|string¦null|false|none|none|
|correlationId|string¦null|false|none|none|
|externalReference|string¦null|false|none|none|
|origin|string¦null|false|none|none|
|billingDesktopRefNumber|string¦null|false|none|none|
|consumerSecondPhone|string¦null|false|none|none|
|consumerNote|string¦null|false|none|none|
|bankDetails|[BankDetails](#schemabankdetails)|false|none|none|
|woocommerceID|string¦null|false|none|External ID inside https://woocommerce.com system|
|ecwidID|string¦null|false|none|External ID inside https://www.ecwid.com system|

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
  "externalReference": "string",
  "woocommerceID": "string",
  "ecwidID": "string",
  "active": true,
  "hasBankAccount": true,
  "hasCreditCard": true
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
|consumerAddress|[Address](#schemaaddress)|false|none|none|
|externalReference|string¦null|false|none|none|
|woocommerceID|string¦null|false|none|External ID inside https://woocommerce.com system|
|ecwidID|string¦null|false|none|External ID inside https://www.ecwid.com system|
|active|boolean|false|none|none|
|hasBankAccount|boolean|false|none|none|
|hasCreditCard|boolean|false|none|none|

<h2 id="tocS_CurrencyEnum">CurrencyEnum</h2>
<!-- backwards compatibility -->
<a id="schemacurrencyenum"></a>
<a id="schema_CurrencyEnum"></a>
<a id="tocScurrencyenum"></a>
<a id="tocscurrencyenum"></a>

```json
"ILS"

```

ILS

USD

EUR

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
  "origin": "string",
  "woocommerceID": "string",
  "ecwidID": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|itemName|string|true|none|none|
|price|number(double)|false|none|none|
|active|boolean¦null|false|none|none|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|externalReference|string¦null|false|none|none|
|billingDesktopRefNumber|string¦null|false|none|none|
|sku|string¦null|false|none|none|
|origin|string¦null|false|none|none|
|woocommerceID|string¦null|false|none|External ID inside https://woocommerce.com system|
|ecwidID|string¦null|false|none|External ID inside https://www.ecwid.com system|

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
  "active": true,
  "woocommerceID": "string",
  "ecwidID": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|itemID|string(uuid)|false|none|none|
|updateTimestamp|string(byte)¦null|false|none|none|
|itemName|string¦null|false|none|none|
|price|number(double)|false|none|none|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|created|string(date-time)¦null|false|none|none|
|operationDoneBy|string¦null|false|none|none|
|correlationId|string¦null|false|none|none|
|externalReference|string¦null|false|none|none|
|billingDesktopRefNumber|string¦null|false|none|none|
|sku|string¦null|false|none|none|
|active|boolean|false|none|none|
|woocommerceID|string¦null|false|none|External ID inside https://woocommerce.com system|
|ecwidID|string¦null|false|none|External ID inside https://www.ecwid.com system|

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
  "billingDesktopRefNumber": "string",
  "woocommerceID": "string",
  "ecwidID": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|itemID|string(uuid)|false|none|none|
|itemName|string¦null|false|none|none|
|price|number(double)¦null|false|none|none|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|externalReference|string¦null|false|none|none|
|billingDesktopRefNumber|string¦null|false|none|none|
|woocommerceID|string¦null|false|none|External ID inside https://woocommerce.com system|
|ecwidID|string¦null|false|none|External ID inside https://www.ecwid.com system|

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
    "additionalData": null
  },
  "additionalData": null
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|message|string¦null|false|none|none|
|status|[StatusEnum](#schemastatusenum)|false|none|success<br><br>warning<br><br>error|
|entityID|integer(int64)¦null|false|none|none|
|entityUID|string(uuid)¦null|false|none|none|
|entityReference|string¦null|false|none|none|
|correlationId|string¦null|false|none|none|
|entityType|string¦null|false|none|none|
|errors|[[Error](#schemaerror)]¦null|false|none|none|
|concurrencyToken|string¦null|false|none|none|
|innerResponse|[OperationResponse](#schemaoperationresponse)|false|none|none|
|additionalData|any|false|none|none|

<h2 id="tocS_PaymentTypeEnum">PaymentTypeEnum</h2>
<!-- backwards compatibility -->
<a id="schemapaymenttypeenum"></a>
<a id="schema_PaymentTypeEnum"></a>
<a id="tocSpaymenttypeenum"></a>
<a id="tocspaymenttypeenum"></a>

```json
"card"

```

card

cheque

cash

bank

<h2 id="tocS_ShowDeletedEnum">ShowDeletedEnum</h2>
<!-- backwards compatibility -->
<a id="schemashowdeletedenum"></a>
<a id="schema_ShowDeletedEnum"></a>
<a id="tocSshowdeletedenum"></a>
<a id="tocsshowdeletedenum"></a>

```json
"OnlyActive"

```

OnlyActive

OnlyDeleted

All

<h2 id="tocS_StatusEnum">StatusEnum</h2>
<!-- backwards compatibility -->
<a id="schemastatusenum"></a>
<a id="schema_StatusEnum"></a>
<a id="tocSstatusenum"></a>
<a id="tocsstatusenum"></a>

```json
"success"

```

success

warning

error

<h2 id="tocS_SummariesResponse_ConsumerSummary">SummariesResponse_ConsumerSummary</h2>
<!-- backwards compatibility -->
<a id="schemasummariesresponse_consumersummary"></a>
<a id="schema_SummariesResponse_ConsumerSummary"></a>
<a id="tocSsummariesresponse_consumersummary"></a>
<a id="tocssummariesresponse_consumersummary"></a>

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
      "externalReference": "string",
      "woocommerceID": "string",
      "ecwidID": "string",
      "active": true,
      "hasBankAccount": true,
      "hasCreditCard": true
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|numberOfRecords|integer(int32)|false|none|none|
|data|[[ConsumerSummary](#schemaconsumersummary)]¦null|false|none|none|

<h2 id="tocS_SummariesResponse_ItemSummary">SummariesResponse_ItemSummary</h2>
<!-- backwards compatibility -->
<a id="schemasummariesresponse_itemsummary"></a>
<a id="schema_SummariesResponse_ItemSummary"></a>
<a id="tocSsummariesresponse_itemsummary"></a>
<a id="tocssummariesresponse_itemsummary"></a>

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
      "billingDesktopRefNumber": "string",
      "woocommerceID": "string",
      "ecwidID": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|numberOfRecords|integer(int32)|false|none|none|
|data|[[ItemSummary](#schemaitemsummary)]¦null|false|none|none|

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
    "bank": 0,
    "bankBranch": 0,
    "bankAccount": "string",
    "paymentType": "card",
    "amount": 0
  },
  "woocommerceID": "string",
  "ecwidID": "string"
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
|consumerAddress|[Address](#schemaaddress)|false|none|none|
|externalReference|string¦null|false|none|ID in external system|
|origin|string¦null|false|none|Origin of customer|
|updateTimestamp|string(byte)|true|none|Concurrency check|
|consumerSecondPhone|string¦null|false|none|End-customer Phone|
|billingDesktopRefNumber|string¦null|false|none|ID in BillingDesktop system|
|active|boolean|false|none|none|
|bankDetails|[BankDetails](#schemabankdetails)|false|none|none|
|woocommerceID|string¦null|false|none|External ID inside https://woocommerce.com system|
|ecwidID|string¦null|false|none|External ID inside https://www.ecwid.com system|

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
  "sku": "string",
  "woocommerceID": "string",
  "ecwidID": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|itemID|string(uuid)|false|none|none|
|itemName|string|true|none|none|
|price|number(double)|false|none|none|
|currency|[CurrencyEnum](#schemacurrencyenum)|false|none|ILS<br><br>USD<br><br>EUR|
|updateTimestamp|string(byte)¦null|false|none|none|
|externalReference|string¦null|false|none|none|
|sku|string¦null|false|none|none|
|woocommerceID|string¦null|false|none|External ID inside https://woocommerce.com system|
|ecwidID|string¦null|false|none|External ID inside https://www.ecwid.com system|

