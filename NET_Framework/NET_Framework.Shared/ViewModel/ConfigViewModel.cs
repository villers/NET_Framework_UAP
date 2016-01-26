using GalaSoft.MvvmLight;
using NET_Framework.DataModel;
using NET_Framework.Model;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NET_Framework.ViewModel
{
    public class ConfigViewModel : ViewModelBase
    {
        public string ConfigID { get; set; } = "Gamer";
        public IDataSource ComputersData { get; set; }

        public INotifyTaskCompletion<Computer> Computers
        {
            get { return NotifyTaskCompletion.Create(ComputersData.GetComputers(ConfigID)); }
        }

        public ConfigViewModel(IDataSource computersData)
        {
            ComputersData = computersData;
        }
    }
}
