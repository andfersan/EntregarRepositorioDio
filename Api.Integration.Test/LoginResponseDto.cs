using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Integration.Test
{
    public class LoginResponseDto
    {
        [JsonProperty("Authenticated")]
        public bool authenticated { get; set; }

        [JsonProperty("create")]
        public DateTime create { get; set; }

        [JsonProperty("expiration")]
        public DateTime expiration { get; set; }

        [JsonProperty("accessToken")]
        public string accessToken { get; set; }

        [JsonProperty("userName")]
        public string userName { get; set; }

        [JsonProperty("name")]
        public DateTime name { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
