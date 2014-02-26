Eve Online Library.NET
=

Eve Online Library.NET is an open source C# wrapper for CCPs Eve Online API and other popular Eve Online APIs.

## Features
- Easy to use.
- XML configuration through app.config.
- Access to all popular APIs through one library.
- Adheres to C# and .NET conventions.
- Provides caching for CCP API requests.
- Modular and open source; you can easily change the caching, serialization or any other part of the library.

## CCP API
The library exposes all CCPs Eve API functions through an easy to use API, using C# programming and naming conventions. It uses a structure similar to how the API URIs are structured. See [APIv2] (http://wiki.eve-id.net/APIv2_Page_Index) for a reference. The basic structure is as follows:
- `CharacterKey` and `CorporationKey` exposes requests prefixed with /account/.
- `Character` exposes all requests prefixed with /char/.
- `Corporation` exposes all requests  prefixed with /corp/.
- `Map` exposes all requests prefixed with /map/.
- `Image` exposes all requests to image.eveonline.com.
- `Core` exposes all other API requests.

#### Requests 
Map, Image and Core does not require any state, and are accessible through any EoLib instance, eg:

    var lib = new EoLib();
    var data =lib.Core.GetStuffFromApi();
	
Character and Corporation require a valid Eve Online API Key, which consist of a key id and a vertification code.
To access these, you need to create a new `CharacterKey` or `CorporationKey`. An example using id '123' and vcode 'qwerty':

    var key = EoLib.GetCharacterKey(123, qwerty);

Using this key, you can access all /account/ calls (note: Only `CharacterKey` provides `GetAccountInfo()`):

    var data = key.GetApiKeyInfo();
	
To get access to Character objects, simply access key.Characters, which lazily loads a list of Character objects for all characters this key has access to. You can then pick the character you want, and access the API through it.

    var character = key.Characters.First();
    var data = character.GetCharacterSheet();

You can also use LINQ to find a specific character, eg:

    var character = key.Characters.First(c => c.CharacterId == 12345);
    var peter = key.Characters.First(c => c.CharacterName == "Peter");
    
`CorporationKey` objects work the same way, except it provides access to a single `Corporation` object, rather than a list of `Character` objects.

#### Responses
All API calls return results in the form of `XmlResponse<T>` objects, where `T` is the specific type of response. These objects reflect the structure of the actual XML responses, with a few exceptions. All properties have been renamed in compliance with C# naming conventions, eg. 'characterID' is converted to CharacterId. Also, some properties have been renamed for clarity and consistency, where most changes are extensions of the original names.

Every XML response has a Version, CachedUntil, Result and Error property. Result is of type T, and contains all request specific data. Error is null unless the API returned an error, in which case it provides access to the error code and description. A later version will possibly use exceptions instead.

    var data = api.Core.GetServerStatus();
    if (data.Result.Error != null) {
        // handle the error
        Logger.Log(data.Result.Error.Code + data.Result.Error.Description);
    } else {
        var players = data.Result.PlayersOnline;
    }

#### Caching
The library uses the default HttpWebRequest cache (IE Cache) by default, adhering to the CachedUntil values provided by CCP on each request.

#### Threading
The library is currently not threaded in any way. There's not really room for parallelisation in the requests, so the only use would be for offloading eg. a GUI thread. I've left this responsibility to the client code, but this may change.

Eve Central API
-
Work in progress.

EveMarketData API
-
Work in progress.



