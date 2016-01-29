using GalaSoft.MvvmLight;
using NET_Framework.DataModel;
using NET_Framework.Model;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Views;

namespace NET_Framework.ViewModel
{
    public class ConfigViewModel : ViewModelBase
    {
        private INavigationService Navigation { get; set; }

        public ComponentSelected ComponentSelected { get; set; }

        private ComponentsKey _selectedFeedItem;
        public ComponentsKey SelectedFeedItem //Valeur du mot sélectionné dans la liste
        {
            get
            {
                return _selectedFeedItem;
            }

            set
            {
                if (_selectedFeedItem != value)
                {
                    _selectedFeedItem = value;
                    SetComponentSelectedAndComponentType();
                }
            }
        }

        public string ConfigID { get; set; }

        public ComponentType ComponentType { get; set; }

        public string ComponentTypeName
        {
            get
            {
                switch (ComponentType)
                {
                    case ComponentType.Graphic:
                        {
                            return "Graphic Card";
                        }

                    case ComponentType.Cpu:
                        {
                            return "Processor";
                        }

                    case ComponentType.Memory:
                        {
                            return "Memory";
                        }

                    case ComponentType.Storage:
                        {
                            return "Storage";
                        }

                    default:
                        {
                            throw new Exception("ComponentType undefined");
                        }
                }
            }
        }

        public IDataSource ComputersData { get; set; }

        public INotifyTaskCompletion<Computer> Computers
        {
            get { return NotifyTaskCompletion.Create(ComputersData.GetComputer(ConfigID)); }
        }

        public INotifyTaskCompletion<IEnumerable<ComponentsKey>> ComponentsItems
        {
            get { return NotifyTaskCompletion.Create(ComputersData.GetComputerComponents(ConfigID, ComponentType)); }
        }

        public ConfigViewModel(IDataSource computersData, INavigationService navigation)
        {
            Navigation = navigation;
            ComputersData = computersData;
            ComponentSelected = new ComponentSelected();
        }

        private void SetComponentSelectedAndComponentType()
        {
            switch (ComponentType)
            {
                case ComponentType.Graphic:
                    {
                        ComponentSelected.Graphic = SelectedFeedItem;
                        ComponentType = ComponentType.Cpu;
                        break;
                    }

                case ComponentType.Cpu:
                    {
                        ComponentSelected.Cpu = SelectedFeedItem;
                        ComponentType = ComponentType.Memory;
                        break;
                    }

                case ComponentType.Memory:
                    {
                        ComponentSelected.Memory = SelectedFeedItem;
                        ComponentType = ComponentType.Storage;
                        break;
                    }

                case ComponentType.Storage:
                    {
                        ComponentSelected.Storage = SelectedFeedItem;
                        Navigation.NavigateTo(ViewModelLocator.CardPageKey);
                        return;
                    }

                default:
                    {
                        throw new Exception("ComponentType undefined");
                    }
            }
            Navigation.NavigateTo(ViewModelLocator.ConfigPageKey);
        }
    }
}
