using ProyectoSeguridad.Models.DNS;
using System.Text.Json;

namespace ProyectoSeguridad.APIS.BuildWIth_Domain_API
{
    public class ApiCaller1
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<DnsServiceResponse> GetDnsServiceData(string domain)
        {
            try
            {
                string url = $"https://networkcalc.com/api/dns/whois/{domain}";
                string json = await GetJsonFromAPI(url);
                DnsServiceResponse response = JsonSerializer.Deserialize<DnsServiceResponse>(json);
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
                System.Diagnostics.Debug.WriteLine($"Error en GetDnsServiceData: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        private async Task<string> GetJsonFromAPI(string url)
        {
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetJsonFromAPI: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }
    }
}