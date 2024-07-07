using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProyectoSeguridad.Models.DNS
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class DnsServiceResponse
    {
        public string record_type { get; set; }
        public string value { get; set; }
        public string mname { get; set; }
        public string rname { get; set; }
        public int? serial { get; set; }
        public int? refresh { get; set; }
        public int? retry { get; set; }
        public int? expire { get; set; }
        public int? ttl { get; set; }
        public int? flags { get; set; }
        public string tag { get; set; }
    }


}
