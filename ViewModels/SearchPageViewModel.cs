using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoSeguridad.Models.DNS;
using ProyectoSeguridad.Models.WebCategorization;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using ProyectoSeguridad.Views;
using ProyectoSeguridad.APIS.BuildWIth_Domain_API;

namespace ProyectoSeguridad.ViewModels
{
    public class SearchPageViewModel : ObservableObject
    {
        private string _domain;
        private DnsServiceResponse _dnsData;
        private DomainCategorizationResponse _domainCategorizationData;
        private string _selectedApi;
        private readonly ApiCaller1 _apiCaller1 = new ApiCaller1();
        private readonly ApiCaller2 _apiCaller2 = new ApiCaller2();


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

        public DomainCategorizationResponse DomainCategorizationData
        {
            get => _domainCategorizationData;
            set => SetProperty(ref _domainCategorizationData, value);
        }

        public IAsyncRelayCommand SearchCommand { get; }


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
                OnPropertyChanged(nameof(IsDomainCategorizationApiSelected));
                OnPropertyChanged(nameof(IsDnsApiSelected));
            }
        }

        public bool IsDomainCategorizationApiSelected => SelectedApi == "Web Categorization API";
        public bool IsDnsApiSelected => SelectedApi == "DNS API";

        private async Task SearchDomainAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Domain))
                {
                    await HandleApiError("Debe ingresar un dominio válido.");
                    return;
                }

                if (SelectedApi == "DNS API")
                {
                    var dnsData = await _apiCaller1.GetDnsData(Domain);
                    if (dnsData != null)
                    {
                        DnsData = dnsData;
                        System.Diagnostics.Debug.WriteLine($"Datos DNS pasados a ResultsPage: {System.Text.Json.JsonSerializer.Serialize(dnsData)}");
                    }
                    else
                    {
                        await HandleApiError("No se encontraron datos DNS para el dominio.");
                    }
                }
                else if (SelectedApi == "Web Categorization API")
                {
                    var domainCategorizationData = await _apiCaller2.GetDomainCategorization(Domain);
                    if (domainCategorizationData != null)
                    {
                        DomainCategorizationData = domainCategorizationData;
                        System.Diagnostics.Debug.WriteLine($"Datos de categorización web pasados a ResultsPage: {System.Text.Json.JsonSerializer.Serialize(domainCategorizationData)}");
                    }
                    else
                    {
                        await HandleApiError("No se encontraron datos de categorización web para el dominio.");
                    }
                }

                if (DnsData != null || DomainCategorizationData != null)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new Resultados(DomainCategorizationData, DnsData));
                }
                else
                {
                    await HandleApiError("No se pudieron obtener datos del dominio.");
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
