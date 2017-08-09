using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Povo.Models;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace Povo.Services {
    public class AzureService {

        MobileServiceClient cliente;
        IMobileServiceTable<Pessoa> tabela;




        public AzureService() {
            string MyAppServiceURL = "http://pessoas.azurewebsites.net";
            cliente = new MobileServiceClient(MyAppServiceURL);
            tabela = cliente.GetTable<Pessoa>();
        }

        //public Task<IEnumerable<T>> PegaTabela() {
        //    return tabela.ToEnumerableAsync();
        //}

        public async Task<ObservableCollection<Pessoa>> GetTabelaInteira() {
            IEnumerable<Pessoa> itens = await tabela.ToEnumerableAsync();
            return new ObservableCollection<Pessoa>(itens);
        }

        public async Task InsereNaTabela(Pessoa p) {
            await tabela.InsertAsync(p);

        }

        public async Task SaveTaskAsync(Pessoa p) {
            await tabela.UpdateAsync(p);
        }

        public async Task DeleteTaskAsync(Pessoa p) {
            await tabela.DeleteAsync(p);
        }


        //public async Task<List<Pessoa>> GetTabelaInteira() {
        //    IEnumerable<Pessoa> t = await tabela.ToEnumerableAsync();
        //    return t.ToList<Pessoa>();
        //    //return t.ToListAsync<Pessoa>();
        //}




    }
}
