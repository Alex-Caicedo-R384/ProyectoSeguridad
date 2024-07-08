using CommunityToolkit.Mvvm.ComponentModel;
using ProyectoSeguridad.Models.DNS;
using ProyectoSeguridad.Models.WebCategorization;

namespace ProyectoSeguridad.ViewModels
{
    public class ResultsPageViewModel : ObservableObject
    {
        private DomainCategorizationResponse _domainCategorizationData;
        private DnsServiceResponse _dnsData;
        private bool _isWebCategorizationApiSelected;
        private bool _isDnsApiSelected;



        public ResultsPageViewModel()
        {
            _domainCategorizationData = new DomainCategorizationResponse();
            _dnsData = new DnsServiceResponse();
        }

        public ResultsPageViewModel(
            DomainCategorizationResponse domainCategorizationData,
            DnsServiceResponse dnsData)
        {
            _domainCategorizationData = domainCategorizationData;
            _dnsData = dnsData;
        }

        public DomainCategorizationResponse DomainCategorizationData
        {
            get => _domainCategorizationData;
            set => SetProperty(ref _domainCategorizationData, value);
        }

        public DnsServiceResponse DnsData
        {
            get => _dnsData;
            set => SetProperty(ref _dnsData, value);
        }
        public bool IsWebCategorizationApiSelected
        {
            get => _isWebCategorizationApiSelected;
            set => SetProperty(ref _isWebCategorizationApiSelected, value);
        } 
        public bool IsDnsApiSelected
        {
            get => _isDnsApiSelected;
            set => SetProperty(ref _isDnsApiSelected, value);
        }
    }
}
