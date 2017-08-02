using Povo.Models;
using Povo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Povo.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal : ContentPage {
        public PaginaPrincipal() {
            InitializeComponent();
            BindingContext = new Povo.ViewModels.PessoasViewModel();

            BtnSincronizar.Clicked += BtnSincronizar_Clicked;




        }

        public void BtnSincronizar_Clicked(object sender, EventArgs e) {
            //////var lista = new ObservableCollection<Pessoa>();
            ////List<Pessoa> lista = new List<Pessoa>();
            //ObservableCollection<Pessoa> lista = ListViewPessoas;
            //var lista = sender;
            var l = new Povo.ViewModels.PessoasViewModel();
            var lista = l.ListaDePessoas;
             Navigation.PushAsync(new PessoaView(lista));
        }
    }
}