using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Povo.Models;
using Povo.Services;
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

        public Command GetPessoasComando { get; set; }
        public Command PushPessoaComando { get; set; }
        public ObservableCollection<Pessoa> ListaDePessoas { get; set; }

        public PessoasViewModel() {
            ListaDePessoas = new ObservableCollection<Pessoa>();
            GetPessoasComando = new Command(async () => await GetPessoas(), () => !IsBusy);
            PushPessoaComando = new Command(async () => await PushPessoa(), () => !IsBusy);
        }

        async Task PushPessoa() {
            Pessoa p = new Pessoa();
            p.Nome = "pierre3";
            p.Id = "300";

            if (!IsBusy) {
                Exception Error = null;
                try {
                    IsBusy = true;
                    var repositorio = new AzureService();
                    await repositorio.InsereNaTabela(p);
                }

                catch (Exception ex) {
                    Error = ex;
                }
                finally {
                    IsBusy = false;
                }

                if (Error != null) {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error de Post", Error.Message, "OK");
                }
            }
            await this.GetPessoas();
            return;
        }


        async Task GetPessoas() {

            if (!IsBusy) {
                Exception Error = null;
                try {
                    IsBusy = true;
                    var repositorio = new AzureService();
                    var tabelaInteira = await repositorio.GetTabelaInteira();

                    ListaDePessoas.Clear();
                    foreach (var pessoa in tabelaInteira) {
                        ListaDePessoas.Add(pessoa);
                    }
                }

                catch (Exception ex) {
                    Error = ex;
                }
                finally {
                    IsBusy = false;
                }

                if (Error != null) {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error de Get", Error.Message, "OK");
                }
            }
            return;
        }

        //criar um novo comando chamado "GetCatsCommand". Ele é inicializado no construtor
        //Um objeto Command tem uma interface que sabe qual método invocar e tem uma forma opcional de descrever se o Command está habilitado.
    }
}
