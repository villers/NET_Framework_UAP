using GalaSoft.MvvmLight;
using NET_Framework.DataModel;
using NET_Framework.Model;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace NET_Framework.ViewModel
{
    public class CardViewModel : ViewModelBase
    {
        private INavigationService Navigation { get; set; }

        private ConfigViewModel ConfigViewModel { get; set; }

        public ComponentSelected ComponentSelected
        {
            get {
                return ConfigViewModel.ComponentSelected;
            }
        }

        public CardViewModel()
        {
            ConfigViewModel = ServiceLocator.Current.GetInstance<ConfigViewModel>();
        }
    }
}
