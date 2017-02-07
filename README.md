# ***ESISharp*** 

C# Library for interacting with the Eve Online ESI API.

[![GitHub release](https://img.shields.io/github/release/wranders/ESISharp.svg)](https://github.com/wranders/ESISharp/releases/latest)

---

To use, utilize the ***ESISharp*** namespace and create one of the following objects:

* *EveSwagger.Public()*
* *EveSwagger.Authenticated(* ***ClientID***, ***SecretKey*** *)*
    * **ClientID** is required for authenticated access.
	* **SecretKey** is optional, but will grant you a Refresh Token for future access.

The Authenticated object has access to both Public and Authenticated paths.

After that, follow the paths and supply the required information.

---

The refresh token can be retrieved using *EveSwagger.SSO.GetRefreshToken()*<br/>
The refresh token can be set using *EveSwagger.SSO.SetRefreshToken(* ***Token*** *)*

ESISharp includes an executable that catches the response from Eve SSO and routes it back to ESISharp.<br/>
It's filename, location, and operating protocol is fully configurable for your application.<br/>
You application will require permissions to write to the Registry to create the forwarding protocol for the AuthRouter.

By default, the router filename is *EveSSOAuthRouter* and must be located in the same directory as the ESISharp library.<br/>
The default protocol is *eveosso*. (Full callback url is ***eveosso://***)<br/>
To create or repair the required registry key, run *EveSwagger.SSO.VerifyCallbackProtocolRegistyKey()*

---

Requires Json.NET

---

EVE Online © 2016 [CCP hf.](https://www.ccpgames.com/)
