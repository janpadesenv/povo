using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Povo.Models;
using Xamarin.Forms;

namespace Povo.ViewModels {
    public class PessoasViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        private bool Busy;
        public bool IsBusy {
            get { return Busy; }
            set { Busy = value; OnPropertyChanged(); GetPessoasComando.ChangeCanExecute(); }

        }

        private string teste;
        public string Teste {
            get { return teste; }
            set { teste = value; }
        }

        public List<Pessoa> ListaDePessoas { get; set; }

        public PessoasViewModel() {
            teste = "teste";
            ListaDePessoas = new List<Pessoa>();
            GetPessoasComando = new Command(async () => await GetPessoas(), () => !IsBusy);
        }

        async Task GetPessoas() {
            //detectar se atualmente o ViewModel se encontra ocupado obtendo os dados
            if (!IsBusy) {
                Exception Error = null;
                //estabelecendo IsBusy a true e posteriormente a false quando iniciamos a recuperação da informação
                //a partir do repositório e quando terminamos de obter os dados.
                try {
                    //Obtendo os dados do repositório
                    IsBusy = true;
                    var Repository = new Repository();
                    var Items = await Repository.GetPessoasDoRepositorio();

                    //limpar a lista atual de objetos "Cat" e carregá-los a partir da coleção Items
                    ListaDePessoas.Clear();
                    foreach (var pessoa in Items) {
                        ListaDePessoas.Add(pessoa);
                    }
                }

                //Se algo der errado, o bloco catch guardará a exceção e depois do bloco finally poderemos mostrar uma mensagem emergente.
                catch (Exception ex) {
                    Error = ex;
                }
                finally {
                    IsBusy = false;
                }

                //mostrar uma mensagem em caso de que se tenha gerado uma exceção
                if (Error != null) {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error!", Error.Message, "OK");
                }
            }
            return;
        }

        //criar um novo comando chamado "GetCatsCommand". Ele é inicializado no construtor
        //Um objeto Command tem uma interface que sabe qual método invocar e tem uma forma opcional de descrever se o Command está habilitado.
        public Command GetPessoasComando { get; set; }




    }
}
