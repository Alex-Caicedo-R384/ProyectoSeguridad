using Microsoft.Maui.Controls;
using ProyectoSeguridad.Models.BuildWIth_Domain_API;
using ProyectoSeguridad.ViewModels;

namespace ProyectoSeguridad.Views
{
    public partial class Resultados : ContentPage
    {
        public Resultados(Api20 apiData)
        {
            InitializeComponent();
            BindingContext = new ResultsPageViewModel(apiData);
        }
    }
}
