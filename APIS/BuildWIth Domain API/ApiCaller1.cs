using System;
using System.Net.Http;
using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;
using ProyectoSeguridad.Models.BuildWIth_Domain_API;

namespace ProyectoSeguridad.APIS.BuildWIth_Domain_API
{
    public class ApiCaller1
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<Api20> GetDomainData(string domain)
        {
            string apiKey = "32bfb4d6-320c-4d7c-93a3-900779c2c56d";
            string url = $"https://api.builtwith.com/v20/api.xml?KEY={apiKey}&LOOKUP={domain}";
            string xml = await GetXmlFromAPI(url);
            Api20 apiResult = DeserializeXml<Api20>(xml);
            return apiResult;
        }

        public async Task<string> GetXmlFromAPI(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public T DeserializeXml<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
