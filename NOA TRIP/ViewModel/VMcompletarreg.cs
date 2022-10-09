using NOA_TRIP.Model;
using NOA_TRIP.View.Registro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using NOA_TRIP.View;
using System.Security.Cryptography.X509Certificates;
using NOA_TRIP.Datos;
using Rg.Plugins.Popup.Services;
using NOA_TRIP.View.Reutilizables;

namespace NOA_TRIP.ViewModel
{
    public class VMcompletarreg :BaseViewModel
    {
        #region VARIABLES
        string _txtnumero;
        List<Mpaises> _listapaises;
        Mpaises _selectpaisdesault;
        
        public GoogleUser _googleuserRecibe { get; set; }
        #endregion
        #region CONSTRUCTOR
        
        public VMcompletarreg(INavigation navigation,GoogleUser _googleUserTrae)
        {
            Navigation = navigation;
            _googleuserRecibe = _googleUserTrae;
            ObtenerDataPaisXpais();



        }
        #endregion
        #region OBJETOS
        public string Txtnumero
        {
            get { return _txtnumero; }
            set { SetValue(ref _txtnumero, value); }
        }
        public List<Mpaises> Listapaises
        {
            get { return _listapaises; }
            set { SetValue(ref _listapaises, value); }
        }
        public Mpaises SelectpaisDesault
        {
            get { return _selectpaisdesault; }
            set { SetValue(ref _selectpaisdesault, value); }
        }
        #endregion
        #region PROCESOS
        public async void EnviarSMS()
        {
            #region GENERAR CODIGO ALEATORIO
            #endregion
            Random generador=new Random();
            string ramdonsms = generador.Next(0, 9999).ToString("D4");

            try
            {
               /* string accountSid = Environment.GetEnvironmentVariable("AC95ab591337f74318d0119445ab703f28");
                string authToken = Environment.GetEnvironmentVariable("be0bc73142f1189936cfadd9a4696057");
                TwilioClient.Init(accountSid, authToken);
                var menssage = MessageResource.Create(
                    body: "",
                    from: new Twilio.Types.PhoneNumber("+17179054480"),
                    to: new Twilio.Types.PhoneNumber("+18299643035")
                    );*/
                
            var accountSid = "AC95ab591337f74318d0119445ab703f28";
            var authToken = "be0bc73142f1189936cfadd9a4696057";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(Txtnumero));
            messageOptions.MessagingServiceSid = "MGa305c079d9da352604e3e0b5219634a9";
            messageOptions.Body = "Usa: "+ ramdonsms+" para validar tu cuenta de NOATRIP";

            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);

                await Navigation.PushAsync(new DigitarCodigo(ramdonsms));
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        
        public void MostrarPaises()
        {
            var funcion = new Dpaises();
            Listapaises = funcion.Mostrarpaises();
        }
        private async void Ircrearcuenta()
        {
            await Navigation.PushAsync(new CrearCuenta());
        }
        private void ObtenerDataPaisXpais()
        {
            var funcion = new Dpaises();
            SelectpaisDesault = funcion.MostrarpaisesXpais("Dominican Republic");
        }
        private void Irlistapaises()
        {
            MostrarPaises();
            PopupNavigation.Instance.PushAsync(new Listapaises());
        }
        #endregion
        #region COMANDOS
        public ICommand Irpaisescommand => new Command(Irlistapaises);
        public ICommand Siguientecommand => new Command(EnviarSMS);
        //public ICommand Pmostrarpaisescommand => new Command(MostrarPaises);
        public ICommand Ircrearcuentacommand => new Command(Ircrearcuenta);
        #endregion

    }
}
