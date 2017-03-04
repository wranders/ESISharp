# ***ESISharp***

C# Library for interacting with the Eve Online ESI API.

[![GitHub release](https://img.shields.io/github/release/wranders/ESISharp.svg)](https://github.com/wranders/ESISharp/releases/latest)

---

To use, utilize the ***ESISharp*** namespace and create one of the following objects:

* `ESIEve.Public()`
* `ESIEve.Authenticated( ClientID, SecretKey )`
    * **ClientID** is required for authenticated access.
	* **SecretKey** is optional, but will grant you a Refresh Token for future access.

The Authenticated object has access to both Public and Authenticated paths.

Requests are made with a fluent builder pattern. Requests return the EsiResponse object.

Request examples:
* To make a request, returning **EsiResponse**: `ESIEve.Alliance.GetAll().Execute()`
* To make a request, returning **Task\<EsiResponse>**: `ESIEve.Alliance.GetAll().ExecuteAsync()`
* To make a request from a specified route/version: `ESIEve.Alliance.GetAll().Route("v1").Execute()`
* To make a request to a different server: `ESIEve.Alliance.GetAll().DataSource( DataSource.Singularity ).Execute()`
* Route and DataSource specifications can be use together and in any order.

`EsiResponse` object structure:
| Parameter Name | Parameter Type            |
| -------------- | :-----------------------: |
| `Body`         | String                    |
| `Code`         | System.Net.HttpStatusCode |
| `Headers`      | EsiResponseHeaders        |

`EsiResponseHeaders` object structure:
| Parameter Name | Parameter Type | Description                                             |
| -------------- | :------------: | ------------------------------------------------------- | 
| `ContentType`  | String         | Response body format                                    |
| `Date`         | DateTime       | Time the request was made                               |
| `Expires`      | DateTime       | Time the request data will be invalid                   |
| `LastModified` | DateTime       | Time the request data was last modified by CCP          |
| `Warning`      | String         | (Optional) Response warning message if one was returned |

---

The refresh token can be retrieved using `ESIEve.SSO.GetRefreshToken()`<br/>
The refresh token can be set using `ESIEve.SSO.SetRefreshToken( Token )`

ESISharp includes an executable that catches the response from Eve SSO and routes it back to ESISharp.<br/>
It's filename, location, and operating protocol is fully configurable for your application.<br/>
You application will require permissions to write to the Registry to create the forwarding protocol for the AuthRouter.

By default, the router filename is *EveSSOAuthRouter* and must be located in the same directory as the ESISharp library.<br/>
The default protocol is *eveosso*. (Full callback url is ***eveosso://***)<br/>
To create or repair the required registry key, run `ESIEve.SSO.VerifyCallbackProtocolRegistyKey()`

---

Requires Json.NET

---

EVE Online © 2016 [CCP hf.](https://www.ccpgames.com/)