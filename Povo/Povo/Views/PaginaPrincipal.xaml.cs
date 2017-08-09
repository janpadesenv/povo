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

        }

    }
}