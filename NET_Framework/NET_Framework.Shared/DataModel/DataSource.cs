using NET_Framework.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using System.Linq;

namespace NET_Framework.DataModel
{
    public class DataSource : IDataSource
    {
        private IEnumerable<Computer> computers { get; set; } = null;

        private async Task getJson()
        {
            if (computers == null)
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///DataModel/Data.json"));
                string Text = await FileIO.ReadTextAsync(file);
                computers = JsonConvert.DeserializeObject<List<Computer>>(Text);
            }
        }

        public async Task<IEnumerable<Computer>> GetComputers()
        {
            await getJson();
            return computers;
        }

        public async Task<Computer> GetComputer(string UnitID)
        {
            await getJson();
            return computers.Where(x => x.UniqueId == UnitID).FirstOrDefault();
        }

        public async Task<IEnumerable<ComponentsKey>> GetComputerComponents(string UnitID, ComponentType componentType)
        {
            await getJson();
            switch (componentType)
            {
                case ComponentType.Graphic:
                    {
                        return computers.Where(x => x.UniqueId == UnitID).FirstOrDefault().Components.Graphic;
                    }

                case ComponentType.Cpu:
                    {
                        return computers.Where(x => x.UniqueId == UnitID).FirstOrDefault().Components.Cpu;
                    }

                case ComponentType.Memory:
                    {
                        return computers.Where(x => x.UniqueId == UnitID).FirstOrDefault().Components.Memory;
                    }

                case ComponentType.Storage:
                    {
                        return computers.Where(x => x.UniqueId == UnitID).FirstOrDefault().Components.Storage;
                    }

                default:
                    {
                        throw new Exception("ComponentType undefined");
                    }
            }
        }
    }
}
