using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ProyectoSeguridad.Models.WebCategorization;

namespace ProyectoSeguridad.APIS.BuildWIth_Domain_API
{
    public class ApiCaller2
    {
        private static readonly HttpClient client = new HttpClient();
        private static string apiKey = "at_mvdRfgOl7UEnKpvNXOHm75Xx6YcOH";

        public async Task<DomainCategorizationResponse> GetDomainCategorization(string domain)
        {
            try
            {
                string url = $"https://website-categorization.whoisxmlapi.com/api/v3?apiKey={apiKey}&url={domain}";
                string json = await GetJsonFromAPI(url);
                DomainCategorizationResponse response = JsonSerializer.Deserialize<DomainCategorizationResponse>(json);
                System.Diagnostics.Debug.WriteLine($"Respuesta de categorización en JSON: {json}"); // Impresión de respuesta en JSON
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
                System.Diagnostics.Debug.WriteLine($"Error en GetDomainCategorization: {ex.Message}");
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
