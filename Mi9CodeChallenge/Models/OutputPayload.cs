using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace Mi9CodeChallenge.Models
{
    public class PayloadInfo
    {
        [JsonProperty(PropertyName = "image")]
        public string image { get; set; }

        [JsonProperty(PropertyName = "slug")]
        public string slug { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string title { get; set; }

    }

    public class OutputPayload
    {
        [JsonProperty(PropertyName = "response")]
        public List<PayloadInfo> payloadInfo { get; set; }
    }
}