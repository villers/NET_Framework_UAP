using GalaSoft.MvvmLight;
using NET_Framework.DataModel;
using NET_Framework.Model;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace NET_Framework.ViewModel
{
    public class ConfigViewModel : ViewModelBase
    {
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

        public ConfigViewModel(IDataSource computersData)
        {
            ComputersData = computersData;            
        }
    }
}
