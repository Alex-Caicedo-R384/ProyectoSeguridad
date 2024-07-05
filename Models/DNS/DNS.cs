using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProyectoSeguridad.Models.DNS
{
    public class DnsServiceResponse
    {
        public List<string> tags { get; set; }
        public string value { get; set; }
        public string subdomain { get; set; }
        public string type { get; set; }
        public List<int> ports { get; set; }
        public DateTime last_seen { get; set; }
    }

    public class Root
    {
        public string domain { get; set; }
        public List<object> tags { get; set; }
        public List<string> subdomains { get; set; }
        public List<DnsServiceResponse> data { get; set; }
        public bool more { get; set; }
    }

}
