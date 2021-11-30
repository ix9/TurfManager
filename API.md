---
title: TurfManager v1
language_tabs:
  - http: HTTP
language_clients:
  - http: ""
toc_footers: []
includes: []
search: true
highlight_theme: darkula
headingLevel: 2

---

<!-- Generator: Widdershins v4.0.1 -->

<h1 id="turfmanager">TurfManager v1</h1>

> Scroll down for code samples, example requests and responses. Select a language for code samples from the tabs above or the mobile navigation menu.

Access the TurfManager API that allows you to work with the backend

Web: <a href="https://blog.xrw.tech">XRW Technology</a> 

<h1 id="turfmanager-summaries">Summaries</h1>

## Returns all summaries in the database. No JWT required.

> Code samples

```http
GET /api/Summaries HTTP/1.1

Accept: application/json

```

`GET /api/Summaries`

<h3 id="returns-all-summaries-in-the-database.-no-jwt-required.-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|Last45|query|boolean|false|none|

> Example responses

> 200 Response

```json
[
  {
    "summaryId": 0,
    "summaryDateGenerated": "2019-08-24T14:15:22Z",
    "summaryDateWst": "2019-08-24T14:15:22Z",
    "summaryDateString": "string",
    "summaryMaxTemp": 0,
    "summaryMinTemp": 0,
    "summaryGddtotal": 0,
    "summaryApplication": true,
    "summaryAction": 0
  }
]
```

<h3 id="returns-all-summaries-in-the-database.-no-jwt-required.-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<h3 id="returns-all-summaries-in-the-database.-no-jwt-required.-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[Summary](#schemasummary)]|false|none|none|
|» summaryId|integer(int32)|false|none|none|
|» summaryDateGenerated|string(date-time)|false|none|none|
|» summaryDateWst|string(date-time)|false|none|none|
|» summaryDateString|string¦null|false|none|none|
|» summaryMaxTemp|number(double)¦null|false|none|none|
|» summaryMinTemp|number(double)¦null|false|none|none|
|» summaryGddtotal|number(double)¦null|false|none|none|
|» summaryApplication|boolean¦null|false|none|none|
|» summaryAction|integer(int32)¦null|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## OLD: Log an Action to the Summary table. Send in an Action Integer. Replaced by POST: /api/Summaries/SummaryAction. Requires JWT.

> Code samples

```http
POST /api/Summaries HTTP/1.1

Accept: application/json

```

`POST /api/Summaries`

<h3 id="old:-log-an-action-to-the-summary-table.-send-in-an-action-integer.-replaced-by-post:-/api/summaries/summaryaction.-requires-jwt.-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|Action|query|integer(int32)|false|none|

> Example responses

> 400 Response

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="old:-log-an-action-to-the-summary-table.-send-in-an-action-integer.-replaced-by-post:-/api/summaries/summaryaction.-requires-jwt.-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|

<aside class="success">
This operation does not require authentication
</aside>

## Get an Overview of the last time each of the actions were performed.

> Code samples

```http
GET /api/Summaries/GetActionSummary HTTP/1.1

Accept: application/json

```

`GET /api/Summaries/GetActionSummary`

> Example responses

> 200 Response

```json
[
  {
    "actionID": 0,
    "actionName": "string",
    "actionIcon": "string",
    "actionLastDate": "2019-08-24T14:15:22Z",
    "actionDaysAgo": 0
  }
]
```

<h3 id="get-an-overview-of-the-last-time-each-of-the-actions-were-performed.-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<h3 id="get-an-overview-of-the-last-time-each-of-the-actions-were-performed.-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[ActionSummary](#schemaactionsummary)]|false|none|none|
|» actionID|integer(int32)|false|none|none|
|» actionName|string¦null|false|none|none|
|» actionIcon|string¦null|false|none|none|
|» actionLastDate|string(date-time)¦null|false|none|none|
|» actionDaysAgo|integer(int32)¦null|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Get the Cumulative GDD Since the last application of PGR. Requires JWT.

> Code samples

```http
GET /api/Summaries/GetCumulativeGDD HTTP/1.1

Accept: application/json

```

`GET /api/Summaries/GetCumulativeGDD`

> Example responses

> 200 Response

```json
[
  {
    "summaryId": 0,
    "summaryDateGenerated": "2019-08-24T14:15:22Z",
    "summaryDateWst": "2019-08-24T14:15:22Z",
    "summaryDateString": "string",
    "summaryMaxTemp": 0,
    "summaryMinTemp": 0,
    "summaryGddtotal": 0,
    "summaryApplication": true,
    "summaryAction": 0
  }
]
```

<h3 id="get-the-cumulative-gdd-since-the-last-application-of-pgr.-requires-jwt.-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|

<h3 id="get-the-cumulative-gdd-since-the-last-application-of-pgr.-requires-jwt.-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[Summary](#schemasummary)]|false|none|none|
|» summaryId|integer(int32)|false|none|none|
|» summaryDateGenerated|string(date-time)|false|none|none|
|» summaryDateWst|string(date-time)|false|none|none|
|» summaryDateString|string¦null|false|none|none|
|» summaryMaxTemp|number(double)¦null|false|none|none|
|» summaryMinTemp|number(double)¦null|false|none|none|
|» summaryGddtotal|number(double)¦null|false|none|none|
|» summaryApplication|boolean¦null|false|none|none|
|» summaryAction|integer(int32)¦null|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Get a specific Summary by ID (not really useful yet) Requires JWT.

> Code samples

```http
GET /api/Summaries/GetByID/{id} HTTP/1.1

Accept: application/json

```

`GET /api/Summaries/GetByID/{id}`

<h3 id="get-a-specific-summary-by-id-(not-really-useful-yet)-requires-jwt.-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "summaryId": 0,
  "summaryDateGenerated": "2019-08-24T14:15:22Z",
  "summaryDateWst": "2019-08-24T14:15:22Z",
  "summaryDateString": "string",
  "summaryMaxTemp": 0,
  "summaryMinTemp": 0,
  "summaryGddtotal": 0,
  "summaryApplication": true,
  "summaryAction": 0
}
```

<h3 id="get-a-specific-summary-by-id-(not-really-useful-yet)-requires-jwt.-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[Summary](#schemasummary)|

<aside class="success">
This operation does not require authentication
</aside>

## OLD: Create a Summary record (min and max temperature) for a specific date (send in a YYYYMMDD string) Uses Stored Prod = TO BE DEPRECATED. Requires JWT.

> Code samples

```http
PUT /api/Summaries/{DateString} HTTP/1.1

Accept: application/json

```

`PUT /api/Summaries/{DateString}`

<h3 id="old:-create-a-summary-record-(min-and-max-temperature)-for-a-specific-date-(send-in-a-yyyymmdd-string)-uses-stored-prod-=-to-be-deprecated.-requires-jwt.-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|DateString|path|string|true|none|

> Example responses

> 400 Response

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="old:-create-a-summary-record-(min-and-max-temperature)-for-a-specific-date-(send-in-a-yyyymmdd-string)-uses-stored-prod-=-to-be-deprecated.-requires-jwt.-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|

<aside class="success">
This operation does not require authentication
</aside>

## NEW: Generate a Summary Record for a specific date (send in YYYYMMDD as string) Requires JWT.

> Code samples

```http
POST /api/Summaries/Generate/{inDate} HTTP/1.1

Accept: application/json

```

`POST /api/Summaries/Generate/{inDate}`

<h3 id="new:-generate-a-summary-record-for-a-specific-date-(send-in-yyyymmdd-as-string)-requires-jwt.-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|inDate|path|string|true|none|

> Example responses

> 400 Response

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="new:-generate-a-summary-record-for-a-specific-date-(send-in-yyyymmdd-as-string)-requires-jwt.-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|

<aside class="success">
This operation does not require authentication
</aside>

## NEW: Log a new Action to the Summary Table. TO DO: Account for Timezone Offset. Requires JWT

> Code samples

```http
POST /api/Summaries/LogAction/{id} HTTP/1.1

Accept: application/json

```

`POST /api/Summaries/LogAction/{id}`

<h3 id="new:-log-a-new-action-to-the-summary-table.-to-do:-account-for-timezone-offset.-requires-jwt-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "summaryId": 0,
  "summaryDateGenerated": "2019-08-24T14:15:22Z",
  "summaryDateWst": "2019-08-24T14:15:22Z",
  "summaryDateString": "string",
  "summaryMaxTemp": 0,
  "summaryMinTemp": 0,
  "summaryGddtotal": 0,
  "summaryApplication": true,
  "summaryAction": 0
}
```

<h3 id="new:-log-a-new-action-to-the-summary-table.-to-do:-account-for-timezone-offset.-requires-jwt-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[Summary](#schemasummary)|

<aside class="success">
This operation does not require authentication
</aside>

## Delete a specific Summary by ID - Requires JWT.

> Code samples

```http
DELETE /api/Summaries/DeleteByID/{id} HTTP/1.1

Accept: application/json

```

`DELETE /api/Summaries/DeleteByID/{id}`

<h3 id="delete-a-specific-summary-by-id---requires-jwt.-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "summaryId": 0,
  "summaryDateGenerated": "2019-08-24T14:15:22Z",
  "summaryDateWst": "2019-08-24T14:15:22Z",
  "summaryDateString": "string",
  "summaryMaxTemp": 0,
  "summaryMinTemp": 0,
  "summaryGddtotal": 0,
  "summaryApplication": true,
  "summaryAction": 0
}
```

<h3 id="delete-a-specific-summary-by-id---requires-jwt.-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[Summary](#schemasummary)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="turfmanager-temperatures">Temperatures</h1>

## get__api_Temperatures

> Code samples

```http
GET /api/Temperatures HTTP/1.1

Accept: text/plain

```

`GET /api/Temperatures`

<h3 id="get__api_temperatures-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|ShowAll|query|boolean|false|none|

> Example responses

> 200 Response

```
[{"readingKey":0,"readingDateString":"string","readingDateTimeWst":"2019-08-24T14:15:22Z","readingValue":0}]
```

```json
[
  {
    "readingKey": 0,
    "readingDateString": "string",
    "readingDateTimeWst": "2019-08-24T14:15:22Z",
    "readingValue": 0
  }
]
```

<h3 id="get__api_temperatures-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|

<h3 id="get__api_temperatures-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[Temperatures](#schematemperatures)]|false|none|none|
|» readingKey|integer(int32)|false|none|none|
|» readingDateString|string¦null|false|none|none|
|» readingDateTimeWst|string(date-time)|false|none|none|
|» readingValue|number(double)|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## post__api_Temperatures

> Code samples

```http
POST /api/Temperatures HTTP/1.1

Content-Type: application/json
Accept: text/plain

```

`POST /api/Temperatures`

> Body parameter

```json
{
  "readingKey": 0,
  "readingDateString": "string",
  "readingDateTimeWst": "2019-08-24T14:15:22Z",
  "readingValue": 0
}
```

<h3 id="post__api_temperatures-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[Temperatures](#schematemperatures)|false|none|

> Example responses

> 200 Response

```
{"readingKey":0,"readingDateString":"string","readingDateTimeWst":"2019-08-24T14:15:22Z","readingValue":0}
```

```json
{
  "readingKey": 0,
  "readingDateString": "string",
  "readingDateTimeWst": "2019-08-24T14:15:22Z",
  "readingValue": 0
}
```

<h3 id="post__api_temperatures-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[Temperatures](#schematemperatures)|

<aside class="success">
This operation does not require authentication
</aside>

## get__api_Temperatures_{id}

> Code samples

```http
GET /api/Temperatures/{id} HTTP/1.1

Accept: text/plain

```

`GET /api/Temperatures/{id}`

<h3 id="get__api_temperatures_{id}-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```
{"readingKey":0,"readingDateString":"string","readingDateTimeWst":"2019-08-24T14:15:22Z","readingValue":0}
```

```json
{
  "readingKey": 0,
  "readingDateString": "string",
  "readingDateTimeWst": "2019-08-24T14:15:22Z",
  "readingValue": 0
}
```

<h3 id="get__api_temperatures_{id}-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[Temperatures](#schematemperatures)|

<aside class="success">
This operation does not require authentication
</aside>

## put__api_Temperatures_{id}

> Code samples

```http
PUT /api/Temperatures/{id} HTTP/1.1

Content-Type: application/json

```

`PUT /api/Temperatures/{id}`

> Body parameter

```json
{
  "readingKey": 0,
  "readingDateString": "string",
  "readingDateTimeWst": "2019-08-24T14:15:22Z",
  "readingValue": 0
}
```

<h3 id="put__api_temperatures_{id}-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|body|body|[Temperatures](#schematemperatures)|false|none|

<h3 id="put__api_temperatures_{id}-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="success">
This operation does not require authentication
</aside>

## delete__api_Temperatures_{id}

> Code samples

```http
DELETE /api/Temperatures/{id} HTTP/1.1

Accept: text/plain

```

`DELETE /api/Temperatures/{id}`

<h3 id="delete__api_temperatures_{id}-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```
{"readingKey":0,"readingDateString":"string","readingDateTimeWst":"2019-08-24T14:15:22Z","readingValue":0}
```

```json
{
  "readingKey": 0,
  "readingDateString": "string",
  "readingDateTimeWst": "2019-08-24T14:15:22Z",
  "readingValue": 0
}
```

<h3 id="delete__api_temperatures_{id}-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[Temperatures](#schematemperatures)|

<aside class="success">
This operation does not require authentication
</aside>

## POST: api/Temperatures/Log/YYYYMMDD NEW: Post a temperature to the database

> Code samples

```http
POST /api/Temperatures/Log/{inDateString} HTTP/1.1

Accept: text/plain

```

`POST /api/Temperatures/Log/{inDateString}`

<h3 id="post:-api/temperatures/log/yyyymmdd-new:-post-a-temperature-to-the-database-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|inDateString|path|string|true|none|
|inTemperature|query|number(double)|false|none|

> Example responses

> 200 Response

```
{"readingKey":0,"readingDateString":"string","readingDateTimeWst":"2019-08-24T14:15:22Z","readingValue":0}
```

```json
{
  "readingKey": 0,
  "readingDateString": "string",
  "readingDateTimeWst": "2019-08-24T14:15:22Z",
  "readingValue": 0
}
```

<h3 id="post:-api/temperatures/log/yyyymmdd-new:-post-a-temperature-to-the-database-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[Temperatures](#schematemperatures)|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="turfmanager-token">Token</h1>

## post__api_Token

> Code samples

```http
POST /api/Token HTTP/1.1

Content-Type: application/json

```

`POST /api/Token`

> Body parameter

```json
{
  "userId": 0,
  "firstName": "string",
  "lastName": "string",
  "userName": "string",
  "email": "string",
  "password": "string",
  "createdDate": "2019-08-24T14:15:22Z"
}
```

<h3 id="post__api_token-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[UserInfo](#schemauserinfo)|false|none|

<h3 id="post__api_token-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="success">
This operation does not require authentication
</aside>

# Schemas

<h2 id="tocS_ActionSummary">ActionSummary</h2>
<!-- backwards compatibility -->
<a id="schemaactionsummary"></a>
<a id="schema_ActionSummary"></a>
<a id="tocSactionsummary"></a>
<a id="tocsactionsummary"></a>

```json
{
  "actionID": 0,
  "actionName": "string",
  "actionIcon": "string",
  "actionLastDate": "2019-08-24T14:15:22Z",
  "actionDaysAgo": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|actionID|integer(int32)|false|none|none|
|actionName|string¦null|false|none|none|
|actionIcon|string¦null|false|none|none|
|actionLastDate|string(date-time)¦null|false|none|none|
|actionDaysAgo|integer(int32)¦null|false|none|none|

<h2 id="tocS_ProblemDetails">ProblemDetails</h2>
<!-- backwards compatibility -->
<a id="schemaproblemdetails"></a>
<a id="schema_ProblemDetails"></a>
<a id="tocSproblemdetails"></a>
<a id="tocsproblemdetails"></a>

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|**additionalProperties**|any|false|none|none|
|type|string¦null|false|none|none|
|title|string¦null|false|none|none|
|status|integer(int32)¦null|false|none|none|
|detail|string¦null|false|none|none|
|instance|string¦null|false|none|none|

<h2 id="tocS_Summary">Summary</h2>
<!-- backwards compatibility -->
<a id="schemasummary"></a>
<a id="schema_Summary"></a>
<a id="tocSsummary"></a>
<a id="tocssummary"></a>

```json
{
  "summaryId": 0,
  "summaryDateGenerated": "2019-08-24T14:15:22Z",
  "summaryDateWst": "2019-08-24T14:15:22Z",
  "summaryDateString": "string",
  "summaryMaxTemp": 0,
  "summaryMinTemp": 0,
  "summaryGddtotal": 0,
  "summaryApplication": true,
  "summaryAction": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|summaryId|integer(int32)|false|none|none|
|summaryDateGenerated|string(date-time)|false|none|none|
|summaryDateWst|string(date-time)|false|none|none|
|summaryDateString|string¦null|false|none|none|
|summaryMaxTemp|number(double)¦null|false|none|none|
|summaryMinTemp|number(double)¦null|false|none|none|
|summaryGddtotal|number(double)¦null|false|none|none|
|summaryApplication|boolean¦null|false|none|none|
|summaryAction|integer(int32)¦null|false|none|none|

<h2 id="tocS_Temperatures">Temperatures</h2>
<!-- backwards compatibility -->
<a id="schematemperatures"></a>
<a id="schema_Temperatures"></a>
<a id="tocStemperatures"></a>
<a id="tocstemperatures"></a>

```json
{
  "readingKey": 0,
  "readingDateString": "string",
  "readingDateTimeWst": "2019-08-24T14:15:22Z",
  "readingValue": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|readingKey|integer(int32)|false|none|none|
|readingDateString|string¦null|false|none|none|
|readingDateTimeWst|string(date-time)|false|none|none|
|readingValue|number(double)|false|none|none|

<h2 id="tocS_UserInfo">UserInfo</h2>
<!-- backwards compatibility -->
<a id="schemauserinfo"></a>
<a id="schema_UserInfo"></a>
<a id="tocSuserinfo"></a>
<a id="tocsuserinfo"></a>

```json
{
  "userId": 0,
  "firstName": "string",
  "lastName": "string",
  "userName": "string",
  "email": "string",
  "password": "string",
  "createdDate": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|userId|integer(int32)|false|none|none|
|firstName|string¦null|false|none|none|
|lastName|string¦null|false|none|none|
|userName|string¦null|false|none|none|
|email|string¦null|false|none|none|
|password|string¦null|false|none|none|
|createdDate|string(date-time)|false|none|none|

