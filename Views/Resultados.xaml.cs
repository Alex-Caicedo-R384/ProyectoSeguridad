using Microsoft.Maui.Controls;
using ProyectoSeguridad.ViewModels;
using ProyectoSeguridad.Models.DNS;
using ProyectoSeguridad.Models.WebCategorization;
using ProyectoSeguridad.APIS.BuildWIth_Domain_API;
using System;
using System.Threading.Tasks;

namespace ProyectoSeguridad.Views
{
    public partial class Resultados : ContentPage
    {
        private readonly ResultsPageViewModel _viewModel;

        public Resultados(
            DomainCategorizationResponse webCategorizationData,
            DnsServiceResponse dnsData)
        {
            InitializeComponent();
            _viewModel = new ResultsPageViewModel(webCategorizationData, dnsData);
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
