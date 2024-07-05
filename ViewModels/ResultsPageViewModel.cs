using CommunityToolkit.Mvvm.ComponentModel;
using ProyectoSeguridad.APIS.BuildWIth_Domain_API;
using ProyectoSeguridad.Models.DNS;
using ProyectoSeguridad.Models.WebCategorization;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoSeguridad.ViewModels
{
    public class ResultsPageViewModel : ObservableObject
    {
        private DomainCategorizationResponse _domainCategorizationData;
        private DnsServiceResponse _dnsData;
        private ApiCaller1 _apiCaller1;
        private ApiCaller2 _apiCaller2;

        public ResultsPageViewModel()
        {
        }

        public ResultsPageViewModel(
            DomainCategorizationResponse domainCategorizationData,
            DnsServiceResponse dnsData,
            ApiCaller1 apiCaller1,
            ApiCaller2 apiCaller2)
        {
            _domainCategorizationData = domainCategorizationData;
            _dnsData = dnsData;
            _apiCaller1 = apiCaller1;
            _apiCaller2 = apiCaller2;
        }

        public DomainCategorizationResponse DomainCategorizationData
        {
            get => _domainCategorizationData;
            set => SetProperty(ref _domainCategorizationData, value);
        }

        public DnsServiceResponse DnsData
        {
            get => _dnsData;
            set => SetProperty(ref _dnsData, value);
        }

        public async Task PerformApiCall(string domain, bool useApi1)
        {
            try
            {
                if (useApi1)
                {
                    DnsData = await App.GlobalApiCaller1.GetDnsServiceData(domain);
                }
                else
                {
                    DomainCategorizationData = await App.GlobalApiCaller2.GetDomainCategorization(domain);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                await HandleApiError("Error de solicitud HTTP");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                await HandleApiError($"Error fetching data: {ex.Message}");
            }
        }

        private async Task HandleApiError(string errorMessage)
        {
            await App.Current.MainPage.DisplayAlert("Error", errorMessage, "Aceptar");
        }
    }
}
