using Microsoft.Maui.Controls;
using ProyectoSeguridad.Models.DNS;
using ProyectoSeguridad.Models.WebCategorization;
using ProyectoSeguridad.ViewModels;
using System;

namespace ProyectoSeguridad.Views
{
    public partial class Resultados : ContentPage
    {
        public Resultados(DomainCategorizationResponse domaincategorizationData, DnsServiceResponse dnsData)
        {
            InitializeComponent();

            if (domaincategorizationData != null)
            {
                System.Diagnostics.Debug.WriteLine($"Datos de categorización recibidos en Resultados: {System.Text.Json.JsonSerializer.Serialize(domaincategorizationData)}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No se recibieron datos de categorización en Resultados");
            }

            if (dnsData != null)
            {
                System.Diagnostics.Debug.WriteLine($"Datos de DNS recibidos en Resultados: {System.Text.Json.JsonSerializer.Serialize(dnsData)}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No se recibieron datos de DNS en Resultados");
            }

            BindingContext = new ResultsPageViewModel { DomainCategorizationData = domaincategorizationData, DnsData = dnsData };
        }
    }
}
