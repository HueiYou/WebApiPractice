using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetWebApiTest.Models
{
    public class ValuesPostVM
    {
        public string value { get; set; }
        [JsonProperty("VALUE2")]
        public string value2 { get; set; }
    }
}


