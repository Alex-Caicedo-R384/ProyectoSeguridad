using System;
using System.Net.Http;
using ProyectoSeguridad.Models.WebCategorization;
using System.Text.Json;


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
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetDomainCategorization: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
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
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetJsonFromAPI: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }
    }
}