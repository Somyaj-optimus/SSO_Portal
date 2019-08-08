using Newtonsoft.Json;

namespace SSO.DataAccessLayer.Model
{
    public class UserDetailsModel
    {
        [ JsonProperty("id") ] 
        public string ApplicationId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("linkUrl")]
        public string LinkUrl { get; set; }

        [JsonProperty("logoUrl")]
        public string logoUrl { get; set; }

        [JsonProperty("appName")]
        public string AppName { get; set; }

    }
}
