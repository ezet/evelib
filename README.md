EveLib.NET
=

EveLib.NET is a open source library for accessing the Eve Online API, CREST, and many other popular APIs.

### Links
* NuGet Package: https://www.nuget.org/packages/eZet.EveLib
* Symbols: http://www.symbolsource.org/Public/Metadata/NuGet/Project/eZet.EveLib
* Support Thread: https://forums.eveonline.com/default.aspx?g=posts&m=4415506

### Features
* Fully asynchronous using TAP.
* XML configuration through app.config.
* Threadsafe.
* Access to all popular APIs through one library.
* Provides caching for CCP API requests.
* Modular and open source; you can easily change the caching, serialization or any other part of the library.
* A fairly comprehensive set of unit tests, including static xml tests for calls requiring authentication.

### Current Modules
* Eve Online API `EveOnlineApi`
* Eve CREST `EveCrest`
* Eve Central API `EveCentral`
* Eve Marketdata API `EveMarketData`
* Element43 API `Element43`
* ZKillboard API `ZKillBoard`
* EveWho `EveWho`
* Eve Static Data (Element43) `EveStaticData` [partial]

### General information
The project is split into one dll for each api, aswell as one core library. All libraries require the core library, but can otherwise be mixed and matched as you like.

#### Code Contracts
The library implements Code Contracts, but this feature is completely optional and is disabled by default.
Code Contracts enables static and runtime checks to ensure you are using the EveLib API correctly.
If you want to utilize this, you should install http://visualstudiogallery.msdn.microsoft.com/1ec7db13-3363-46c9-851f-1ce455f66970 and read the documentation.
The Code Contract reference assemblies are available in the NuGet package. 
See http://research.microsoft.com/en-us/projects/contracts/ for more information.

#### Debugging and Tracing
The library uses `TraceSource` from the `System.Diagnostics` namespace. The TraceSource is named "EveLib".
To add the Default listener to EveLibs `TraceSource`, add this to your application configuration (usually app.config):

    <configuration>
      <system.diagnostics>
        <sources>
          <source name="EveLib" switchValue="All"/>
        </sources>
      </system.diagnostics>
    </configuration>

This adds the Default listener, which usually outputs to the VS output window.
For more information on using `TraceSource`, visit http://msdn.microsoft.com/en-us/library/ms228993(v=vs.110).aspx


#### Caching
The EveOnline API module caches XML files to disk, adhering to the CachedUntil values provided by CCP on each request. The cache location can be configured in App.config. You can easily change this for your own implementation if you want. The other libraries do not use caching.

#### Async/Await
All methods that access an API provide both a synchronous and an asynchronous. Asynchronous methods are postfixed with `Async`. Some classes provide lazily loaded properties, which will always be loaded synchronously if a new request has to be made. To load such properties asynchronously, call `InitAsync()` on the respective objects, before accessing it's properties. All such properties are documented as such in it's comments.

#### Exception Handling
The exception handling is slightly different between the synchronous and asynchronous methods.
For examples of handling AggregateException, see http://msdn.microsoft.com/en-us/library/dd537614(v=vs.110).aspx

##### General information
The actual exceptions thrown (directly or inside `AggregateException`) should always inherit from `EveLibException`. If any other exception is throw, that is a bug and should be reported. Most exceptions will inherit from `EveLibWebException`, which indicates there was an error when performing the web request. All EveLibWebExceptions have a property `WebException`, which contains the responsible `WebException`. Most modules throw `EveLibWebException` directly, unless otherwise is stated. (Currently EveOnline and EveCrest throw more specific exceptions).

##### Synchronous
Because the synchronous methods use sync over async, they can throw multiple exceptions. This is handled by wrapping all exceptions in an `AggregateException`, which has a list, `InnerExceptions`, of all Exceptions that has been thrown. When using the synchronous methods, you catch `AggregateException`. 

##### Asynchronous
When using async/await, the `AggregateException` is unwrapped and only the FIRST inner exception is thrown. The `AggregateException` is available through the Exception property on the Task that is awaited. Catch `InvalidRequestException` or any other specific exception, like normal, and check the `Exception` on the Task if you need to handle more than the first.

EveOnline API
-
This library exposes all of CCPs Eve API calls through an easy to use API, using common .NEt an C# conventions. It uses a structure similar to how the API URIs are structured. See [APIv2] (http://wiki.eve-id.net/APIv2_Page_Index) for a reference. The basic structure is as follows:
* `CharacterKey`, `CorporationKey` and `ApiKey` exposes requests prefixed with /account/.
* `Character` exposes all requests prefixed with /char/.
* `Corporation` exposes all requests  prefixed with /corp/.
* `Map` exposes all requests prefixed with /map/.
* `Image` exposes all requests to image.eveonline.com.
* `Eve` exposes all other API requests.

#### Requests 
All basic functionality can be reached through a static facade class, EveOnlineApi. However, all methods and properties available in this class, can also be accessed by instantiating the respective classes using the new operator.

##### Basic
Eve, Map and Image do not require authentication, and can be accessed directly.

    var result = EveOnlineApi.Map.GetFactionWarSystems();

##### Keys
The library has 3 different key classes, `CharacterKey`, `CorporationKey` and `ApiKey`. These represent "physical" Eve Online API keys, and are required to access any part of the API that requires authentication. The `ApiKey` can be used as a general key to access endpoints in the /account/ path, if you do not know which type of KeyID you have in advance.

    ApiKey key = EveOnlineApi.CreateApiKey(id, vcode);
    CharacterKey charKey = EveOnlineApi.CreateCharacterKey(id, vcode);
    CorporationKey corpKey = EveOnlineApi.CreateCorporationKey(id, vcode);
    
All keys have a few properties in common, such as `KeyType`, `ExpiryDate` and `AccessMask`. These properties will be lazily loaded, synchronously, the first time they are accessed. After one of them have been accessed once, they will be stored in the object. You can also load them explicitly by calling `Init()`, or asynchronously by calling `InitAsync()`.
`CharacterKey` and `CorporationKey` also have additinal properties, `Characters` and `Corporation`, that are also lazily loaded in the same fashion. You can safely call `Init()` or `InitAsync()` repeatedly, if the object is already initialized it will return immediately.

    key.Init(); // loads all properties, sync
    key.Init(); // since it's already initialized, returns immediately.
    await charKey.InitAsync(); // loads all properties, async
    int mask = corpKey.AccessMask(); // internally uses Init() to load all properties
    var newkey = EveOnlineApi.CreateApiKey(id, vcode).Init(); // Init() and InitAsync() returns this, so it can be chained.

You can delete the stored data from keys by calling `Reset()`, which will remove any stored data, and any calls to `Init()`, `InitAsync()` or a lazily loaded property will cause a new request for the data, from the API or cache.

    key.Reset(); // resets all properties, and IsInitialized is set to false

EveLib also provides a method to detect and return the actual type of key, which you can then cast to the real type. This method preserves any initialization data within the key.

    var key = new ApiKey(keyId, vCode); // A user gave me some key info, and I have no idea if its for a char or corp
    if (key.KeyType == ApiKeyType.Character) { // This lazily loads the KeyType and all other properties, from the API
        CharacterKey cKey = (CharacterKey)key.GetActualKey();
        // do work with your character key.
    }

Using any key, you can access all /account/* paths (note: Only `CharacterKey` provides `GetAccountInfo()`):

    EveApiResponse<ApiKeyInfo> result = key.GetApiKeyInfo();
    
##### Character and Corporation
Character and Corporation classes provide access to endpoints in the /char/ and /corp/ paths respectively.
There are mainly two ways to instantiate the Character and Corporation classes.

You can create a new object directly

    Character character = EveOnlineApi.CreateNewCharacter(keyId, vCode, characterId); // using the static class
    Corporation corporation = new Corporation(keyId, vCode, corporationId); // or using new
    
Or you can get them from an existing key

    Character character = characterKey.Characters.Single(c => c.CharacterId == characterId); // key.Characters is a list of all characters this key can access
    Character character = characterKey.Characters.Single(c => c.CharacterName == "MyName"); // find by name, or any other property
    Corporation corporation = corporationKey.Corporation; // corp keys can only access a single corporation
    
The difference is, when creating an object directly, you will not know for sure whether the KeyID, vCode, and entityID is valid until you try to request data from API. Secondly, when creating it directly, it's properties will not be initialized. If you access objects through a key, all properties in both Character and Corporation objects will be pre-initialized with data from the key, at the cost of one call to the ApiKeyInfo endpoint.

`Character` and `Corporation` objects are initialized the same ways keys are, using `Init()`, `InitAsync()` or by accessing a property. You can also call `Reset()` to reset all data. 

#### Responses
All API calls return results in the form of `EveApiResponse<T>` objects, where `T` is the specific type of response. These objects reflect the structure of the actual XML responses, with a few exceptions. All properties have been renamed in compliance with C# naming conventions, eg. 'characterID' is converted to CharacterId. Also, some properties have been renamed for clarity and consistency, where most changes are extensions of the original names.

Every XML response has a Version, CachedUntil and Result. Result is of type T, and contains all request specific data. 

        EveApiResponse<ServerStatus> data = EveOnlineAPi.Eve.GetServerStatus();
        int players = data.Result.PlayersOnline;
        
#### Exceptions
All calls to the Eve Online API can throw `EveOnlineException`, which inherits from `EveLibWebException`. This additionaly exposes `Message` and `ErrorCode`, as returned by the API.

    
Eve CREST
-
Eve CREST endpoints can be called by instantating a new EveCrest object, and using it's methods.

    var crest = new EveCrest();
    var result = crest.GetWar(1);

#### Exceptions
All calls to the CREST API can throw `EveCrestException`, which inherits from `EveLibWebException`.  This additionaly exposes `Message`, `Key`, `ExceptionType` and `RefId` as returned by the API.
    
EveCentral API
-
This module provides access to all calls on the EveCentral api. All api calls can be made through any `EveCentral` object. Most parameters for requests can be set and passed in a `EveCentralOptions` object.

    var options = new EveCentralOptions() { HourLimit = 4, MinQuantity = 5 };
    options.Items.Add(34);
    options.Regoins.Add(10000002);
    var eveCentral = new EveCentral();
    MarketStat result = eveCentral.GetMarketStat(options);


Element43
-
Similar to EveCentral API. Uses `Element43Options`.

EveMarketData API
-
Similar to EveCentral API. Uses `EveMarketDataOptions`.

Zkillbord
-
Work in progress.

EveWho
-
Work in progress.
