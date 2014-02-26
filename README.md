Eve Online Library.NET
=

Eve Online Library.NET is a C# wrapper for CCPs Eve Online API and other popular Eve Online APIs.

#### CCP API Requests
The library exposes all CCPs Eve API functions through an easy to use API, using C# programming and naming conventions. It uses a structure similar to how the API URIs are structured. See [APIv2] (http://wiki.eve-id.net/APIv2_Page_Index) for a reference.

The basic structure is as follows:
- `CharacterKey` and `CorporationKey` exposes requests prefixed with /account/.
- `Character` exposes all requests prefixed with /char/.
- `Corporation` exposes all requests  prefixed with /corp/.
- `Map` exposes all requests prefixed with /map/.
- `Image` exposes all requests to image.eveonline.com.
- `Core` exposes all other API requests.

Map, Image and Core does not require any state, and are accessible through any EoLib instance, eg:
    
    var lib = new EoLib();
    lib.Core.GetStuffFromApi();
	
Character and Corporation require a valid Eve Online API Key, which consist of a key id and a vertification code.
To access these, you need to create a new CharacterKey or CorporationKey. An example using id '123' and vcode 'qwerty':

    var key = EoLib.GetCharacterKey(123, qwerty);

Using this key, you can access all /account/ calls (note: Only CharacterKey provides GetAccountInfo()):

    key.GetApiKeyInfo();
	
To get access to Character objects, simply access key.Characters, which lazily loads a list of Character objects for all characters this key has access to. You can then pick the character you want, and access the API through it.

    var character = key.Characters.First();
    character.GetCharacterSheet();

You can also use LINQ to find a specific character, eg:

    var character = key.Characters.First(c => c.CharacterId = 12345);
    var Test = key.Characters.First(c => c.CharacterName = "Test);
    
CorporationKey objects work the same way, except it provides access to a single Corporation object, rather than a list of Character objects.

#### CCP API Responses
All API calls return results in the form of XmlResponse<T> objects, where T is the specific type of response. These objects reflect the structure of the actual XML responses, with a few exceptions. All properties have been renamed in compliance with C# naming conventions, eg. 'characterID' is converted to CharacterId. Also, some properties have been renamed for clarity and consistency, where most changes are extensions of the original names.

Every XML response has a Version, CachedUntil, Result and Error property. Result is of type T, and contains all request specific data. Error is null unless the API returned an error, in which case it provides access to the error code and description.

#### CCP API Caching
The library uses the default HttpWebRequest cache (IE Cache) by default, adhering to the CachedUntil values provided by CCP on each request. 

#### CCP API Async
-
The library is currently not threaded in any way. There's not really room for parallelism in the requests, so the only use would be for offloading eg. a GUI thread. I've left this responsibility to the client code, but this can easily be changed if needed.





Eve Central API
-




