using NOA_TRIP.Model;
using NOA_TRIP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NOA_TRIP.View.Registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DigitarCodigo : ContentPage
    {
        public DigitarCodigo(string codigo)
        {
            InitializeComponent();

            BindingContext = new VMdigitarcodigo(Navigation);
        }
    }
}