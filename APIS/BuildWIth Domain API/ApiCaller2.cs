using System;
using System.Net.Http;
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
                DomainCategorizationResponse response = DeserializeJson<DomainCategorizationResponse>(json);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetDomainCategorization: {ex.Message}");
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
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetJsonFromAPI: {ex.Message}");
                throw;
            }
        }

        private T DeserializeJson<T>(string json)
        {
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeserializeJson: {ex.Message}");
                throw;
            }
        }
    }
}
