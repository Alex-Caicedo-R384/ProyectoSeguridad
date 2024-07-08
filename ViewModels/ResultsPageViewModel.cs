using CommunityToolkit.Mvvm.ComponentModel;
using ProyectoSeguridad.Models.DNS;
using ProyectoSeguridad.Models.Domain_Reputation;
using ProyectoSeguridad.Models.WebCategorization;

namespace ProyectoSeguridad.ViewModels
{
    public class ResultsPageViewModel : ObservableObject
    {
        private DnsServiceResponse _dnsData;
        private DomainCategorizationResponse _domainCategorizationData;

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
    }
}
