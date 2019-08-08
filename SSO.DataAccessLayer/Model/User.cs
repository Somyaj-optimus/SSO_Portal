using Newtonsoft.Json;

namespace SSO.DataAccessLayer.Model
{
    public class User
    {
        [JsonProperty("sub")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("preferred_username")]
        public string Preferredusername { get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        [JsonProperty("")]
        public string ZoneInfo { get; set; }

        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }
    }
}
