using eZet.Eve.EoLib.Dto.EveApi;

namespace eZet.Eve.EoLib.Util {
    public interface IXmlSerializer {

        XmlResponse<T> Deserialize<T>(string data) where T : XmlElement;


    }
}
