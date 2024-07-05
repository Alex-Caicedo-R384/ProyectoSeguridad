using Microsoft.Maui.Controls;
using ProyectoSeguridad.ViewModels;
using ProyectoSeguridad.Models.DNS;
using ProyectoSeguridad.Models.WebCategorization;
using ProyectoSeguridad.APIS.BuildWIth_Domain_API;
using System;

namespace ProyectoSeguridad.Views
{
    public partial class Buscar : ContentPage
    {
        private readonly SearchPageViewModel _viewModel;

        private bool _isSearching = false; // Bandera para controlar el estado de búsqueda

        public Buscar()
        {
            InitializeComponent();
            _viewModel = new SearchPageViewModel();
            BindingContext = _viewModel;
        }

        public async void OnSearchClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Botón 'Buscar' presionado.");

            try
            {
                if (_isSearching)
                {
                    Console.WriteLine("Ya se está realizando una búsqueda.");
                    return; // Evitar que se realice otra búsqueda si ya está en curso una
                }

                _isSearching = true;

                string domain = DomainEntry.Text;

                if (string.IsNullOrWhiteSpace(domain))
                {
                    await DisplayAlert("Error", "Debe ingresar un dominio válido.", "Aceptar");
                    _isSearching = false;
                    return;
                }

                _viewModel.Domain = domain;

                await _viewModel.SearchCommand.ExecuteAsync(null);

                if (_viewModel.DnsData != null || _viewModel.WebCategorizationData != null)
                {
                    Console.WriteLine("Datos API obtenidos correctamente:");

                    if (_viewModel.DnsData != null)
                        Console.WriteLine($"DnsData: {_viewModel.DnsData}");

                    if (_viewModel.WebCategorizationData != null)
                        Console.WriteLine($"WebCategorizationData: {_viewModel.WebCategorizationData}");

                    await Navigation.PushAsync(new Resultados(
                        _viewModel.WebCategorizationData,
                        _viewModel.DnsData,
                        App.GlobalApiCaller1,
                        App.GlobalApiCaller2));
                }
                else
                {
                    Console.WriteLine("No se obtuvieron datos válidos de la API.");
                    await DisplayAlert("Error", "No se pudieron obtener datos del dominio.", "Aceptar");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                await DisplayAlert("Error", $"Error de solicitud HTTP: {ex.Message}", "Aceptar");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la búsqueda: {ex.Message}");
                await DisplayAlert("Error", $"Error en la búsqueda: {ex.Message}", "Aceptar");
            }
            finally
            {
                _isSearching = false;
            }
        }
    }
}
