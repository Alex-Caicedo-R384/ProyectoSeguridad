using Microsoft.Maui.Controls;
using ProyectoSeguridad.ViewModels;
using System;

namespace ProyectoSeguridad.Views
{
    public partial class Buscar : ContentPage
    {
        private readonly SearchPageViewModel _viewModel;

        public Buscar()
        {
            InitializeComponent();
            _viewModel = new SearchPageViewModel();
            BindingContext = _viewModel;
        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Botón 'Buscar' presionado.");

            try
            {
                string domain = DomainEntry.Text;

                if (string.IsNullOrWhiteSpace(domain))
                {
                    await DisplayAlert("Error", "Debe ingresar un dominio válido.", "Aceptar");
                    return;
                }

                Console.WriteLine($"Dominio ingresado: {domain}");

                _viewModel.Domain = domain;
                await _viewModel.SearchCommand.ExecuteAsync(null);

                if (_viewModel.ApiData != null)
                {
                    Console.WriteLine("Datos API obtenidos correctamente.");
                    await Navigation.PushAsync(new Resultados(_viewModel.ApiData));
                }
                else
                {
                    Console.WriteLine("No se obtuvieron datos válidos de la API.");
                    await DisplayAlert("Error", "No se pudieron obtener datos del dominio.", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la búsqueda: {ex.Message}");
                await DisplayAlert("Error", $"Error en la búsqueda: {ex.Message}", "Aceptar");
            }
        }
    }
}
