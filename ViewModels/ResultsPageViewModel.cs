using CommunityToolkit.Mvvm.ComponentModel;
using ProyectoSeguridad.Models.BuildWIth_Domain_API;

namespace ProyectoSeguridad.ViewModels
{
    public class ResultsPageViewModel : ObservableObject
    {
        private Api20 _apiResult;

        public Api20 ApiResult
        {
            get => _apiResult;
            set => SetProperty(ref _apiResult, value);
        }

        public ResultsPageViewModel(Api20 apiData)
        {
            ApiResult = apiData;
        }
    }
}
