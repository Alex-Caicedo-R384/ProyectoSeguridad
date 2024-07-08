using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ProyectoSeguridad.Models.DNS;

namespace ProyectoSeguridad.APIS.BuildWIth_Domain_API
{
    public class ApiCaller1
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<DnsServiceResponse> GetDnsData(string domain)
        {
            try
            {
                string url = $"https://networkcalc.com/api/dns/whois/{domain}";
                string json = await GetJsonFromAPI(url);
                DnsServiceResponse response = JsonSerializer.Deserialize<DnsServiceResponse>(json);
                System.Diagnostics.Debug.WriteLine($"Respuesta DNS en JSON: {json}");
                return response;
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetDnsData: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        private async Task<string> GetJsonFromAPI(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
