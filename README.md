Eve Online Library.NET
=

Eve Online Library.NET is an open source C# wrapper for CCPs Eve Online API and other popular Eve Online APIs.

Support thread: https://forums.eveonline.com/default.aspx?g=posts&m=4415506

### Features
* Easy to use.
* Threadsafe.
* XML configuration through app.config.
* Access to all popular APIs through one library.
* Adheres to C# and .NET conventions.
* Provides caching for CCP API requests.
* Modular and open source; you can easily change the caching, serialization or any other part of the library.
* A fairly comprehensive set of unit tests, including static xml tests for calls requiring authentication.

### Current Modules
* Eve Online API
* Eve CREST
* Eve Central API
* Eve Marketdata API
* Element43 API
* ZKillboard API

### General information
The project is split into one dll for each api, aswell as one core library. All libraries require the core library, but can otherwise be mixed and matched as you like. The latest stable release also offers one download where all projects are merged into one dll. The libraries can be configured using app.config in your application, see dll.config for possible values.

#### Code Contracts
The library uses Code Contracts, see [code contracts] (http://research.microsoft.com/en-us/projects/contracts/) for more information.

#### Threading
The library is currently not threaded in any way. There's not really room for effective parallelization in the requests, so the only use would be for offloading eg. a GUI thread. This responsibility should be left to the client code.

#### Caching
The EveOnline API module uses the default HttpWebRequest cache (IE Cache), adhering to the CachedUntil values provided by CCP on each request. The cache location can be configured in App.config. You can easily change this for your own implementation if you want. The other libraries do not use caching.

EveOnline API
-
This library exposes all of CCPs Eve API calls through an easy to use API, using C# programming and naming conventions. It uses a structure similar to how the API URIs are structured. See [APIv2] (http://wiki.eve-id.net/APIv2_Page_Index) for a reference. The basic structure is as follows:
* `CharacterKey` and `CorporationKey` exposes requests prefixed with /account/.
* `Character` exposes all requests prefixed with /char/.
* `Corporation` exposes all requests  prefixed with /corp/.
* `Map` exposes all requests prefixed with /map/.
* `Image` exposes all requests to image.eveonline.com.
* `Misc` exposes all other API requests.

#### Requests 
Map, Image and Misc does not require any state, and can be accessed by creating a new object:

    var mapApi = new Map();
    EveApiResponse<Kills> result = map.GetKills();

Character and Corporation require a valid Eve Online API Key, which consist of a key id and a vertification code.
To access these, you need to create a new `CharacterKey` or `CorporationKey` respectively. An example using id '123' and vcode 'qwerty':

    var key = new CharacterKey(123, "qwerty");

Using this key, you can access all /account/* calls (note: Only `CharacterKey` provides `GetAccountInfo()`):

    EveApiResponse<ApiKeyInfo> result = key.GetApiKeyInfo();
	
To get access to Character objects, simply get `key.Characters`, which lazily loads a list of Character objects for all characters this key has access to. You can then pick the character you want, and access the API through it.

    Character character = key.Characters.First();
    EveApiResponse<CharacterSheet> result = character.GetCharacterSheet();

You can also use LINQ and predicates to find a specific character, eg:

    Character character = key.Characters.Single(c => c.CharacterId == 12345);
    Character peter = key.Characters.Single(c => c.CharacterName == "Peter");
    
`CorporationKey` objects work the same way, except it provides access to a single `Corporation` object, rather than a list of `Character` objects.

#### Responses
All API calls return results in the form of `EveApiResponse<T>` objects, where `T` is the specific type of response. These objects reflect the structure of the actual XML responses, with a few exceptions. All properties have been renamed in compliance with C# naming conventions, eg. 'characterID' is converted to CharacterId. Also, some properties have been renamed for clarity and consistency, where most changes are extensions of the original names.

Every XML response has a Version, CachedUntil and Result. Result is of type T, and contains all request specific data. All calls can throw InvalidRequestException if there is an issue with the request. This exception provides access to the error description and error code returned by the CCP Api, aswell as any inner exceptions that may have been thrown.

    try {
        EveApiResponse<ServerStatus> data = new Misc().GetServerStatus();
        int players = data.Result.PlayersOnline;
    } catch (InvalidRequestException e) {
        Logger.log(e.Message, e.ErrorCode);
    }
    
#### Walking    
A few API calls allows "walking" through older data by specifying an ID to start from. This can be done manually by specifying an ID, or you can use a method `getOlder()` available on the result of the calls that support it. See the APIv2 reference linked above for more details.

EveCentral API
-
This module provides access to all calls on the EveCentral api. All api calls can be made through any `EveCentral` object. Most parameters for requests can be set and passed in a `EveCentralOptions` object.

    var options = new EveCentralOptions() { HourLimit = 4, MinQuantity = 5 };
    options.Items.Add(34);
    options.Regoins.Add(10000002);
    var eveCentral = new EveCentral();
    try {
        MarketStat result = eveCentral.GetMarketStat(options);
    } Catch (InvalidRequestException e) {
        // handle
    }

EveMarketData API
-
Requires Newtonsoft.Json.dll.
This module provides access to all calls on the EveMarketData api. All api calls can be made through any `EveMarketData` object. Most parameters for requests can be set and passed in a `EveMarketDataOptions` object. This module also supports both JSON and XML mode, where JSON is the default. You can specify which format you want in the EveMarketData constructor. It is otherwise very similar to the EveCentral module.


