using Povo.Models;
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
    public partial class PessoaView : ContentPage {
        public PessoaView(List<Pessoa> l) {
            InitializeComponent();
            var _l = l;
            BindingContext = _l;
        }
    }
}