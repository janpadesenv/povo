using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Povo.Services {
    public class AzureService<T> {
        IMobileServiceClient Client;

        IMobileServiceTable<T> Table;


        public AzureService() {
            string MyAppServiceURL = "http://janpav2.azurewebsites.net";
            Client = new MobileServiceClient(MyAppServiceURL);
            Table = Client.GetTable<T>();
        }

        public Task<IEnumerable<T>> PegaTabela() {
            return Table.ToEnumerableAsync();
        }

    }
}
