using NOA_TRIP.Model;
using NOA_TRIP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NOA_TRIP.View.Reutilizables
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listapaises : ContentPage
    {
        public Listapaises()
        {
            var parametros = new GoogleUser();
            parametros.Apellido = "-";
            parametros.Name = "-";
            parametros.Email = "-";
            InitializeComponent();
            BindingContext = new VMcompletarreg(Navigation, parametros);
        }
    }
} 