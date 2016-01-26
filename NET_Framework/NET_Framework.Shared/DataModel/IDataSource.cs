using NET_Framework.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NET_Framework.DataModel
{
    public interface IDataSource
    {
        Task<Computer> GetComputers(string uniqueID);
    }
}
