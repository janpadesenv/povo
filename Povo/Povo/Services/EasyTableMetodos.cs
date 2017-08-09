using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Povo.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace Povo.Services {
    public class EasyTableMetodos {


        //public MobileServiceClient MobileService { get; set; }
        //IMobileServiceTable<Pessoa> tabela;
        //private string tableName;



        public async Task<List<Pessoa>> GetTabelaInteira() {
            var servico = new AzureService();
            var tabela = servico.cliente.GetTable<Pessoa>();
            return await tabela.ToListAsync();
        }



        public async Task InsereNaTabela(Pessoa p) {
            var servico = new AzureService();
            await servico.tabela.InsertAsync(p);
            //await tabela.InsertAsync(p);
            
        }

    }
}
