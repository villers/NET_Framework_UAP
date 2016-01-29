using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using NET_Framework.Model;
using Microsoft.Practices.ServiceLocation;

namespace NET_Framework.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService Navigation { get; set; }

        public RelayCommand ButtonBureau { get; set; }

        public RelayCommand ButtonGamer { get; set; }

        public RelayCommand ButtonProfessionnel { get; set; }

        private ConfigViewModel ConfigViewModel { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        public MainViewModel(INavigationService navigation)
        {
            Navigation = navigation;

            ButtonBureau = new RelayCommand(do_ButtonBureau);
            ButtonGamer = new RelayCommand(do_ButtonGamer);
            ButtonProfessionnel = new RelayCommand(do_Professionnel);

            ConfigViewModel = ServiceLocator.Current.GetInstance<ConfigViewModel>();
        }

        private void do_ButtonBureau()
        {
            ConfigViewModel.ConfigID = "Bureau";
            ConfigViewModel.ComponentType = ComponentType.Graphic;
            this.Navigation.NavigateTo(ViewModelLocator.ConfigPageKey);
        }

        private void do_ButtonGamer()
        {
            ConfigViewModel.ConfigID = "Gamer";
            ConfigViewModel.ComponentType = ComponentType.Graphic;
            this.Navigation.NavigateTo(ViewModelLocator.ConfigPageKey);
        }

        private void do_Professionnel()
        {
            ConfigViewModel.ConfigID = "Professionnel";
            ConfigViewModel.ComponentType = ComponentType.Graphic;
            this.Navigation.NavigateTo(ViewModelLocator.ConfigPageKey);
        }
    }
}