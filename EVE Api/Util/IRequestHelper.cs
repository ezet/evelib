using eZet.Eve.EolNet.Entity;

namespace eZet.Eve.EolNet.Util {
    public interface IRequestHelper {

        string Request(string uri, string postString);

        string GeneratePostString(params object[] args);

        string GeneratePostString(ApiKey apiKey, params object[] args);
    }
}
