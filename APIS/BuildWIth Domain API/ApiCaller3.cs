using ProyectoSeguridad.Models.Domain_Reputation;
using System.Text.Json;


namespace ProyectoSeguridad.APIS.BuildWIth_Domain_API
{
    public class ApiCaller3
    {
        private static readonly HttpClient client = new HttpClient();
        private static string apiKey = "at_mvdRfgOl7UEnKpvNXOHm75Xx6YcOH";

        public async Task<DomainReputationResponse> GetDomainReputationResponse(string domain)
        {
            try
            {
                string url = $"https://domain-reputation.whoisxmlapi.com/api/v2?apiKey={apiKey}&url={domain}";
                string json = await GetJsonFromAPI(url);
                DomainReputationResponse response = JsonSerializer.Deserialize<DomainReputationResponse>(json);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetDomainReputationResponse: {ex.Message}");
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
    }
}
