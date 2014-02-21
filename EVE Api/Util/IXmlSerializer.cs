using eZet.Eve.EolNet.Dto.EveApi;

namespace eZet.Eve.EolNet.Util {
    public interface IXmlSerializer {

        XmlResponse<T> Deserialize<T>(string data) where T : XmlResult;


    }
}
