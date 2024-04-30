using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Web.Api.Views
{
    [Serializable]
    [DataContract(Name = "customer")]
    public class AngolaView
    {
            [JsonProperty("Provincias")]
            public List<ProvinciaView> Provincias { get; set; }
    }
}
