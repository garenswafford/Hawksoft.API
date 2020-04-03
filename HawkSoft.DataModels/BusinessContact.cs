using System;
using System.Text.Json.Serialization;

namespace HawkSoft.DataModels
{
    public class BusinessContact
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }

        [JsonPropertyName("Email")]
        public string Eamil { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("UserId")]
        public Guid UserId { get; set; }

        [JsonPropertyName("AddressId")]
        public Guid? AddressId { get; set; }
    }
}
