using eZet.Eve.EveApi.Dto.EveApi;

namespace eZet.Eve.EveApi {
    public interface IXmlSerializer {

        XmlResponse<T> Deserialize<T>(string data) where T : XmlResult;


    }
}
