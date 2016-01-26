using NET_Framework.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using System.IO;
using System.Linq;

namespace NET_Framework.DataModel
{
    public class DataSource : IDataSource
    {
        private IEnumerable<Computer> computers { get; set; } = null;
        public async Task<Computer> GetComputers(string UnitID)
        {
            if (computers == null)
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///DataModel/Data.json"));
                string Text = await FileIO.ReadTextAsync(file);
                computers = JsonConvert.DeserializeObject<List<Computer>>(Text);
            }
            return computers.Where(x => x.UniqueId == UnitID).FirstOrDefault();
        }
    }
}
