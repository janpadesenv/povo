using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Povo.Models {
    //Adicione o atributo DataTable para a classe Cat para indicar o nome da tabela que será utilizada para obter os dados.
    [DataTable("Pessoas")]
    public class Pessoa {
        //Propriedades públicas(Inicia com letra maiúscula)
        public string Id { get; set; }
        public string Nome { get; set; }


        //Definir a propriedade que permitirá levar o controle de concorrência de cada registro da tabela.
        [Version]
        public string AzureVersion { get; set; }
    }
}
