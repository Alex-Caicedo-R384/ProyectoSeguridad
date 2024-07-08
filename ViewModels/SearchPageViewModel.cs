using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoSeguridad.Models.DNS;
using ProyectoSeguridad.Models.WebCategorization;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoSeguridad.ViewModels
{
    public class SearchPageViewModel : ObservableObject
    {
        private string _domain;
        private DnsServiceResponse _dnsData;
        private DomainCategorizationResponse _webCategorizationData;
        private string _selectedApi;

        public SearchPageViewModel()
        {
            SearchCommand = new AsyncRelayCommand(SearchDomainAsync);
        }

        public ObservableCollection<string> ApiOptions { get; } = new ObservableCollection<string>
        {
            "DNS API",
            "Web Categorization API"
        };

        public string SelectedApi
        {
            get => _selectedApi;
            set
            {
                SetProperty(ref _selectedApi, value);
                OnPropertyChanged(nameof(IsWebCategorizationApiSelected));
                OnPropertyChanged(nameof(IsDnsApiSelected));
            }
        }
        public bool IsWebCategorizationApiSelected => SelectedApi == "Web Categorization API";
        public bool IsDnsApiSelected => SelectedApi == "DNS API";

        public string Domain
        {
            get => _domain;
            set => SetProperty(ref _domain, value);
        }

        public DnsServiceResponse DnsData
        {
            get => _dnsData;
            set => SetProperty(ref _dnsData, value);
        }

        public DomainCategorizationResponse WebCategorizationData
        {
            get => _webCategorizationData;
            set => SetProperty(ref _webCategorizationData, value);
        }

        public IAsyncRelayCommand SearchCommand { get; }

        private async Task SearchDomainAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(Domain))
                {
                    if (SelectedApi == "DNS API")
                    {
                        DnsData = await App.GlobalApiCaller1.GetDnsServiceData(Domain);
                    }
                    else if (SelectedApi == "Web Categorization API")
                    {
                        WebCategorizationData = await App.GlobalApiCaller2.GetDomainCategorization(Domain);
                    }
                }
                else
                {
                    await HandleApiError("El dominio está vacío");
                }
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                await HandleApiError($"Error de solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al obtener datos: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                await HandleApiError($"Error al obtener datos: {ex.Message}");
            }
        }

        private async Task HandleApiError(string errorMessage)
        {
            await App.Current.MainPage.DisplayAlert("Error", errorMessage, "Aceptar");
        }
    }
}
