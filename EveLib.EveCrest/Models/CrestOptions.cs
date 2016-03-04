using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models {

    [DataContract]
    public sealed class CrestOptions : CrestResource<CrestOptions> {

        public enum HttpVerb {
            [EnumMember(Value = "GET")] Get, 
            [EnumMember(Value = "OPTIONS")] Options, 
            [EnumMember(Value = "HEAD")] Head, 
            [EnumMember(Value = "POST")] Post,
            [EnumMember(Value = "PUT")] Put,
            [EnumMember(Value = "DELETE")] Delete, 
        }

        public CrestOptions() {
            ContentType = "application/vnd.ccp.eve.Options-v1+json";
        }

        [DataMember(Name = "representations")]
        public IReadOnlyCollection<CrestRepresentations> Representations { get; set; }


        [DataContract]
        public class CrestRepresentations {
            [DataMember(Name = "acceptType")]
            public Jsonstructure AcceptType { get; set; }

            [DataMember(Name = "verb")]
            public HttpVerb Verb { get; set; }

            [DataMember(Name = "version")]
            public int Version { get; set; }
        }

        [DataContract]
        public class Jsonstructure {

            [DataMember(Name = "jsonDumpOfStructure")]
            public string jsonDumpOfStructure { get; set; }

            [DataMember(Name = "name")]
            public string Name { get; set; }
            
        }


         
    }
}