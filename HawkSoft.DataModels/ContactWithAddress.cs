using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HawkSoft.DataModels
{
    public class ContactWithAddress
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("UserId")]
        public Guid UserId { get; set; }

        [JsonPropertyName("AddressId")]
        public Guid? AddressId { get; set; }
        [JsonPropertyName("StreetName")]
        public string StreetName { get; set; }

        [JsonPropertyName("City")]
        public string City { get; set; }

        [JsonPropertyName("State")]
        public string State { get; set; }
    }
}
