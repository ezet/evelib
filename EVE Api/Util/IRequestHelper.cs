using eZet.Eve.EoLib.Entity;

namespace eZet.Eve.EoLib.Util {
    public interface IRequestHelper {

        string Request(string uri, string postString);

        string GeneratePostString(params object[] args);

        string GeneratePostString(ApiKey apiKey, params object[] args);
    }
}
