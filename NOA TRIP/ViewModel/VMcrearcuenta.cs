using NOA_TRIP.View.Registro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using NOA_TRIP.Model;

namespace NOA_TRIP.ViewModel
{
    public class VMcrearcuenta :BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        private readonly IGoogleManager _googleManager;
        GoogleUser googleuserobtener = new GoogleUser();

        #endregion
        #region CONSTRUCTOR
        public VMcrearcuenta(INavigation navigation)
        { 
            Navigation = navigation;
            _googleManager = DependencyService.Get<IGoogleManager>();
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        
        public void LoguearseConGmail()
        {
            _googleManager.Login(OnLoginComplete);
        }
        public async void OnLoginComplete( GoogleUser googleusertrae,string message)
        {
            if(googleusertrae != null)
            {
                googleuserobtener = googleusertrae;
                string[] cadena=googleuserobtener.Name.Split(' ');
                googleuserobtener.Name=cadena[0];
                googleuserobtener.Apellido = cadena[1];
                await Navigation.PushAsync(new CompletarReg(googleuserobtener));

            }
            else
            {
                await DisplayAlert("Message",message,"OK");
            }
        }
        

        #endregion
        #region COMANDOS
        public ICommand GmailCommand => new Command(LoguearseConGmail);
        
        #endregion
    }
}
