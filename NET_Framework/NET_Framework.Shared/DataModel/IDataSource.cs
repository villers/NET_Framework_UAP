using NET_Framework.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NET_Framework.DataModel
{
    public interface IDataSource
    {
        Task<IEnumerable<Computer>> GetComputers();

        Task<Computer> GetComputer(string uniqueID);

        Task<IEnumerable<ComponentsKey>> GetComputerComponents(string configID, ComponentType componentType);
    }
}
