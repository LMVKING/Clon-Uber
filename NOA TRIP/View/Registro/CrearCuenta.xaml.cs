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
    public partial class CrearCuenta : ContentPage
    {
        public CrearCuenta()
        {
            InitializeComponent();
            BindingContext = new VMcrearcuenta(Navigation);
        }
    }
}