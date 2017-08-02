using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Povo.Models {
    public class Repository {
        public async Task<List<Pessoa>> GetPessoasDoRepositorio() {
            var Service = new Services.AzureService<Pessoa>();
            var Items = await Service.PegaTabela();
            return Items.ToList();
        }
    }
}
