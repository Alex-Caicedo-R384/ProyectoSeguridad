namespace ProyectoSeguridad.Models.DNS
{
    public class DnsServiceResponse
    {
        public string address { get; set; }
        public int ttl { get; set; }
    }

    public class MX
    {
        public string exchange { get; set; }
        public int priority { get; set; }
    }

    public class N
    {
        public string nameserver { get; set; }
    }

    public class Records
    {
        public List<DnsServiceResponse> A { get; set; }
        public List<object> CNAME { get; set; }
        public List<MX> MX { get; set; }
        public List<N> NS { get; set; }
        public List<SOA> SOA { get; set; }
        public List<string> TXT { get; set; }
    }

    public class Root
    {
        public string status { get; set; }
        public string hostname { get; set; }
        public Records records { get; set; }
    }

    public class SOA
    {
        public string nameserver { get; set; }
        public string hostmaster { get; set; }
    }



}
