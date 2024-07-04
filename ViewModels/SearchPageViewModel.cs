using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoSeguridad.APIS.BuildWIth_Domain_API;
using ProyectoSeguridad.Models.BuildWIth_Domain_API;

namespace ProyectoSeguridad.ViewModels
{
    public class SearchPageViewModel : ObservableObject
    {
        private readonly ApiCaller1 _apiCaller = new ApiCaller1();
        private string _domain;
        private Api20 _apiData;

        public string Domain
        {
            get => _domain;
            set => SetProperty(ref _domain, value);
        }

        public Api20 ApiData
        {
            get => _apiData;
            set => SetProperty(ref _apiData, value);
        }

        public IAsyncRelayCommand SearchCommand { get; }

        public SearchPageViewModel()
        {
            SearchCommand = new AsyncRelayCommand(SearchDomainAsync);
        }

        private async Task SearchDomainAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(Domain))
                {
                    string url = $"https://api.builtwith.com/v20/api.xml?KEY=32bfb4d6-320c-4d7c-93a3-900779c2c56d&DOMAIN={Domain}";

                    string xmlResponse = await _apiCaller.GetXmlFromAPI(url);

                    XmlSerializer serializer = new XmlSerializer(typeof(Api20));
                    using (StringReader reader = new StringReader(xmlResponse))
                    {
                        ApiData = (Api20)serializer.Deserialize(reader);
                    }
                }
                else
                {
                    Console.WriteLine("Domain is empty");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
            }
        }
    }
}
