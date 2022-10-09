using NOA_TRIP.View.Registro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NOA_TRIP.ViewModel
{
    public class VMempezar: BaseViewModel
    {
        #region VARIABLES
        
        #endregion
        #region CONSTRUCTOR
        public VMempezar(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        
        #endregion
        #region PROCESOS
        private async void Ircrearcuenta()
        { 
        await Navigation.PushAsync(new CrearCuenta());
        }
        #endregion
        #region COMANDOS
        public ICommand Ircrearcuentacommand => new Command(Ircrearcuenta);
        #endregion

    }
}
