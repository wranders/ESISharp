# ***ESISharp***

A C# Library for interacting with the Eve Online ESI API.

[![Build status](https://ci.appveyor.com/api/projects/status/i3opy3bvu3vfmmf2/branch/dev-restructure?svg=true)](https://ci.appveyor.com/project/wranders/esisharp)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=wranders%3Aesisharp%3Adev-restructure&metric=alert_status)](https://sonarcloud.io/dashboard?id=wranders%3Aesisharp%3Adev-restructure)
[![Code Coverage](https://sonarcloud.io/api/project_badges/measure?project=wranders%3Aesisharp%3Adev-restructure&metric=coverage)](https://sonarcloud.io/dashboard?id=wranders%3Aesisharp%3Adev-restructure)

---

- [Getting Started](#getting-started)
- [Response Structure](#response-structure)
- [Authenticated Requests](#authenticated-requests)
  - [Client](#client)
  - [Callback](#callback)
  - [Refresh Tokens](#refresh-tokens)
  - [Scopes](#scopes)

---

## Getting Started

Use the **ESISharp** namespace and create one of the following objects:

- `ESISharp.Public()`
- `ESISharp.Authenticated( ClientID, SecretKey )`
  - **ClientID** is required for authenticated access.
  - **SecretKey** is optional, but will grant you a Refresh Token for future access.

The Authenticated object has access to both Public and Authenticated paths.

Requests are made with a fluent builder pattern. Requests return the EsiResponse object.

Request examples:

- Request from `tranquility` server and `latest` ESI route

  ```csharp
  ESISharp.Public.Alliance.GetAll();
  ```

- Request a specific route/version

  ```csharp
  ESISharp.Public.Alliance.GetAll().Route("v1");
  ```

- Request a specific DataSource

  ```csharp
  ESISharp.Public.Alliance.GetAll().DataSource( ESISharp.Enumeration.DataSource.Singularity );
  ```

Route and DataSource specifications can be use together and in any order.

Route and DataSource can also be set globally on the client:

```csharp
ESISharp.Public.SetRoute("v1");
ESISharp.Public.SetDataSource( ESISharp.Enumeration.DataSource.Singularity );
```

All the above path examples return the **ESIRequest** object, which is then used to send the request.

- Blocking, returns **EsiResponse**

  ```csharp
  ESISharp.Public.Alliance.GetAll().Execute();
  ```

- Non-Blocking, returns **Task\<EsiResponse>**
  
  ```csharp
  ESISharp.Public.Alliance.GetAll().ExecuteAsync();
  ```

Caching is disabled by default but can be enabled using any caching scheme deriving from `System.Runtime.Caching.ObjectCache`:

```csharp
var cache = new System.Runtime.Caching.MemoryCache("esisharp");
var esiconn = new ESISharp.Public();
esiconn.CacheEnable(cache);
```

---

## Response Structure

`ESISharp.Model.Object.EsiResponse` structure:

| Parameter Name    | Parameter Type                           | Description                          |
| ----------------- | ---------------------------------------- | ------------------------------------ |
| `Body`            | System.String                            | Content of the response              |
| `Code`            | System.Net.HttpStatusCode                | HTTP Status Code (ie. 200, 404, etc) |
| `ContentHeaders`  | ESISharp.Model.Object.EsiContentHeaders  | Content headers                      |
| `ResponseHeaders` | ESISharp.Model.Object.EsiResponseHeaders | Response headers                     |
| `IsCached`        | System.Boolean                           | Is the response returned from cache  |

`ESISharp.Model.Object.EsiContentHeaders` structure:

| Parameter Name | Parameter Type  | Description                                             |
| -------------- | --------------- | ------------------------------------------------------- |
| `ContentType`  | System.String   | Response body format                                    |
| `Expires`      | System.DateTime | Time the request data will be invalid                   |
| `LastModified` | System.DateTime | Time the request data was last modified by CCP          |

`ESISharp.Model.Object.EsiResponseHeaders` structure:

| Parameter Name | Parameter Type  | Description                                             |
| -------------- | --------------- | ------------------------------------------------------- |
| `CacheControl` | System.String   | Directive for caching mechanism                         |
| `Date`         | System.DateTime | Time the request was made                               |
| `ETag`         | System.String   | Entity Tag hash of the response                         |
| `Pages`        | System.Int32    | Number of pages in the response                         |
| `Warning`      | System.String   | (Optional) Response warning message if one was returned |

---

## Authenticated Requests

### Client

```csharp
var esiconn = new ESISharp.Authenticated("[client id]","[secret key]");
esiconn.SetUserAgent("My ESI App");
```

### Callback

The authenticated client uses the `ESISharp.AuthRelay` to capture the ESI callback and complete the authentication process.

The default callback is `eveauth-app://callback/`. This can be changed by setting the callback protocol and path:

```csharp
esiconn.Sso.Client.SetCallbackProtocol("myesiapp");
esiconn.Sso.Client.SetCallbackPath("root/");
esiconn.Sso.Client.Registry.EnsureKey();
```

This will set the AuthRelay to respond to `myesiapp://root/`. Callback paths must include the trailing slash.

If the AuthRelay is moved to a different directory than the one containing the `ESISharp.dll`, and/or renamed, the following should be used to set the new path:

```csharp
esiconn.Sso.Client.SetAuthorizerFileDirectory(@"C:\esi\");
esiconn.Sso.Client.SetAuthorizerFileName("myappauth");
esiconn.Sso.Client.Registry.EnsureKey();
```

This will set the callback to be opened with the AuthRelay located at `C:\esi\myappauth.exe`.

> **Note:** Any changes to the callback URL or the AuthRelay filename or path requires an `ESISharp.Authenticated.Sso.Client.Registry.EnsureKey()` call for the authentication process to work.

### Refresh Tokens

By default, the authenticated client uses an `implicit` grant. If an `authorization` grant is required (for refresh tokens):

```csharp
esiconn.Sso.Client.SetGrantType(ESISharp.Enumeration.OAuthGrant.Authorization);
```

If the refresh token needs to be immediately available without sending a request:

```csharp
esiconn.Sso.ForceAuthentication();
```

Once authenticated, refresh tokens can be retrieved by:

```csharp
string token = esiconn.Sso.Client.GetRefreshToken();
```

Stored refresh tokens can be set on the client using:

```csharp
esiconn.Sso.Client.SetRefreshToken("[refreshtoken]");
```

### Scopes

Scopes are added using the `ESISharp.Sso.Scopes.Scope` enumeration, either one at a time or in any list that implements `IEnumerable`.

```csharp
esiconn.Sso.Client.AddScope(ESISharp.Sso.Scopes.Scope.Assets.ReadAssets);

var skillScope = new List()
{
    ESISharp.Sso.Scopes.Scope.Skills.ReadSkillQueue,
    ESISharp.Sso.Scopes.Scope.Skills.ReadSkills
};
esiconn.Sso.Client.AddScope(skillScope);
```

Scopes can also be removed individually or by any list that implements `IEnumerable`.

```csharp
esiconn.Sso.Client.RemoveScope(ESISharp.Sso.Scopes.Scope.Skills.ReadSkillQueue);

var remScopes = new List()
{
    ESISharp.Sso.Scopes.Scope.Assets.ReadAssets,
    ESISharp.Sso.Scopes.Scope.Skills.ReadSkills
};
esiconn.Sso.Client.RemoveScope(remScopes);
```

All scopes, requested and authorized, can be removed using:

```csharp
esiconn.Sso.Client.RemoveAllScopes();
```

If only new requested scopes need to be removed, use:

```csharp
esiconn.Sso.Client.ClearRequestedScopes();
```

Lists of requested and authorized scopes can be retrieved using:

```csharp
List<ESISharp.Sso.Scopes.Scope> requested = esiconn.Sso.Client.GetRequestedScopes();
List<ESISharp.Sso.Scopes.Scope> authorized = esiconn.Sso.Client.GetAuthorizedScopes();
```

Requests with scopes different (removed or added) than what were previously authorized will automatically require reauthentication. Reauthentication can be done on-the-fly if your application allows users to change requests:

```csharp
esiconn.Sso.ForceAuthentication();
```

---

EVE Online © 2019 [CCP hf.](https://www.ccpgames.com/)
