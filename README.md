# ***ESISharp***

C# Library for interacting with the Eve Online ESI API.

[![Build status](https://ci.appveyor.com/api/projects/status/i3opy3bvu3vfmmf2/branch/dev-restructure?svg=true)](https://ci.appveyor.com/project/wranders/esisharp)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=wranders%3Aesisharp%3Adev-restructure&metric=alert_status)](https://sonarcloud.io/dashboard?id=wranders%3Aesisharp%3Adev-restructure)
[![Code Coverage](https://sonarcloud.io/api/project_badges/measure?project=wranders%3Aesisharp%3Adev-restructure&metric=coverage)](https://sonarcloud.io/dashboard?id=wranders%3Aesisharp%3Adev-restructure)

---

To use, utilize the ***ESISharp*** namespace and create one of the following objects:

* `ESISharp.Public()`
* `ESISharp.Authenticated( ClientID, SecretKey )`
    * **ClientID** is required for authenticated access.
	* **SecretKey** is optional, but will grant you a Refresh Token for future access.

The Authenticated object has access to both Public and Authenticated paths.

Requests are made with a fluent builder pattern. Requests return the EsiResponse object.

Request examples:
* `ESISharp.Public.Alliance.GetAll().Execute()` - Request, returns **EsiResponse**
* `ESISharp.Public.Alliance.GetAll().ExecuteAsync()` - Request, returns **Task\<EsiResponse>** 
* `ESISharp.Public.Alliance.GetAll().Route("v1").Execute()` - Request a specific route/version
* `ESISharp.Public.Alliance.GetAll().DataSource( DataSource.Singularity ).Execute()` - Request a specific DataSource
* Route and DataSource specifications can be use together and in any order.

Caching is disabled by default but can be enabled using any caching scheme deriving from `System.Runtime.Caching.ObjectCache`:

```csharp
var cache = new System.Runtime.Caching.MemoryCache("esisharp");
var esiconn = new ESISharp.Public();
esiconn.CacheEnable(cache);
```

`EsiResponse` object structure:

| Parameter Name    | Parameter Type            | Description                           |
| ----------------- | ------------------------- | ------------------------------------- |
| `Body`            | String                    | Content of the response               |
| `Code`            | System.Net.HttpStatusCode | HTTP Status Code (ie. 200, 404, etc)  |
| `ContentHeaders`  | EsiContentHeaders         | Content headers                       |
| `ResponseHeaders` | EsiResponseHeaders        | Response headers                      |
| `IsCached`		| Boolean					| Is the response returned from cache	|

`EsiContentHeaders` object structure:

| Parameter Name | Parameter Type  | Description                                             |
| -------------- | --------------- | ------------------------------------------------------- | 
| `ContentType`  | String          | Response body format                                    |
| `Expires`      | System.DateTime | Time the request data will be invalid                   |
| `LastModified` | System.DateTime | Time the request data was last modified by CCP          |

`EsiResponseHeaders` object structure:

| Parameter Name | Parameter Type  | Description                                             |
| -------------- | --------------- | ------------------------------------------------------- | 
| `CacheControl` | String          | Directive for caching mechanism                         |
| `Date`         | System.DateTime | Time the request was made                               |
| `ETag`         | String          | Entity Tag hash of the response                         |
| `Pages`        | Integer (32)    | Number of pages in the response                         |
| `Warning`      | String          | (Optional) Response warning message if one was returned |

---

***<u>This information is subject to change and, for now, should be disregarded as the entire authentication process is being reworked.</u>***

~~The refresh token can be retrieved using `ESISharp.SSO.Client.GetRefreshToken()`<br/>~~
~~The refresh token can be set using `ESISharp.SSO.Client.SetRefreshToken( Token )`~~

~~ESISharp includes an executable that catches the response from Eve SSO and routes it back to ESISharp.<br/>~~
~~It's filename, location, and operating protocol is fully configurable for your application.<br/>~~
~~You application will require permissions to write to the Registry to create the forwarding protocol for the AuthRouter.~~

~~By default, the router filename is *EveSSOAuthRouter* and must be located in the same directory as the ESISharp library.<br/>~~
~~The default protocol is *eveauth-app* and the default path is *callback/*. (Full callback url is <b><i>eveauth-app://callback/</i></b>)<br/>~~
~~To create or repair the required registry key, run `ESISharp.SSO.Registry.EnsureKey()`~~

---

EVE Online © 2018 [CCP hf.](https://www.ccpgames.com/)
