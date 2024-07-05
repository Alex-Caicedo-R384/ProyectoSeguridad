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
            DnsServiceResponse dnsData,
            ApiCaller1 apiCaller1,
            ApiCaller2 apiCaller2)
        {
            InitializeComponent();
            _viewModel = new ResultsPageViewModel(webCategorizationData, dnsData, apiCaller1, apiCaller2);
            BindingContext = _viewModel;
        }

        public Resultados(DomainCategorizationResponse webCategorizationData, DnsServiceResponse dnsData, ApiCaller1 apiCaller1, ApiCaller2 apiCaller2, bool useApi1)
        {
            InitializeComponent();
            _viewModel = new ResultsPageViewModel(webCategorizationData, dnsData, apiCaller1, apiCaller2);
            BindingContext = _viewModel;
        }
    }
}
