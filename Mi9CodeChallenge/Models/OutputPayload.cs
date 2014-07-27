using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mi9CodeChallenge.Models
{
    public class PayloadInfo
    {
        public string image { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
    }

    public class OutputPayload
    {
        public List<PayloadInfo> payloadInfo { get; set; }
    }
}