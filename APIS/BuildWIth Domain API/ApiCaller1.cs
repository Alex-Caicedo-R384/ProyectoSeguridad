using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoSeguridad.Models.DNS;
using ProyectoSeguridad.Models.WebCategorization;

namespace ProyectoSeguridad.APIS.BuildWIth_Domain_API
{
    public class ApiCaller1
    {
        private static readonly HttpClient client = new HttpClient();
        private static string apiKey = "TLaE2ubjCEyo26HzrB/lUw==Gp7r129Z2Yb9qEvX";

        public async Task<DnsServiceResponse> GetDnsServiceData(string domain)
        {
            try
            {
                string url = $"https://api.api-ninjas.com/v1/dnslookup?domain={domain}";
                string json = await GetJsonFromAPI(url);
                Console.WriteLine("JSON Response: " + json);
                DnsServiceResponse response = DeserializeJson<DnsServiceResponse>(json);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetDnsServiceData: {ex.Message}");
                throw;
            }
        }

        private async Task<string> GetJsonFromAPI(string url)
        {
            try
            {
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    requestMessage.Headers.Add("X-Api-Key", apiKey.Trim());

                    using (HttpResponseMessage response = await client.SendAsync(requestMessage))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            return responseBody;
                        }
                        else
                        {
                            string errorMessage = await response.Content.ReadAsStringAsync();
                            Console.WriteLine($"Error: {response.StatusCode}, {errorMessage}");
                            throw new HttpRequestException($"Error: {response.StatusCode}, {errorMessage}");
                        }
                    }
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
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                Console.WriteLine($"JSON: {json}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeserializeJson: {ex.Message}");
                throw;
            }
        }

    }
}
