using Newtonsoft.Json;

namespace Web.Api.Views
{
    public class ProvinciaView
    {
        [JsonProperty("nome")]
        public string nome {get; set;}
        [JsonProperty("capital")]
        public string capital { get; set;}

        public ProvinciaView() { }

        public ProvinciaView( string nome,  string _capital)
        {
            this.nome = nome;
            this.capital = _capital;

        }
    }
}
