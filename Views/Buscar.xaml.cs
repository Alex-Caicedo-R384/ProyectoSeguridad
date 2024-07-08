using Microsoft.Maui.Controls;
using ProyectoSeguridad.ViewModels;
using System;

namespace ProyectoSeguridad.Views
{
    public partial class Buscar : ContentPage
    {
        private readonly SearchPageViewModel _viewModel = new SearchPageViewModel();

        public Buscar()
        {
            InitializeComponent();
            BindingContext = _viewModel;
        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            try
            {
                string domain = DomainEntry.Text;

                if (string.IsNullOrWhiteSpace(domain))
                {
                    await DisplayAlert("Error", "Debe ingresar un dominio válido.", "Aceptar");
                    return;
                }

                _viewModel.Domain = domain;

                await _viewModel.SearchCommand.ExecuteAsync(_viewModel.Domain);

                if (_viewModel.DnsData != null || _viewModel.DomainCategorizationData != null)
                {
                    await Navigation.PushAsync(new Resultados(
                        _viewModel.DomainCategorizationData,
                        _viewModel.DnsData));
                }
                else
                {
                    await DisplayAlert("Error", "No se pudieron obtener datos del dominio.", "Aceptar");
                }
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                await DisplayAlert("Error", $"Error de solicitud HTTP: {ex.Message}", "Aceptar");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en la búsqueda: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                await DisplayAlert("Error", $"Error en la búsqueda: {ex.Message}", "Aceptar");
            }
        }

    }
}
