﻿using NOA_TRIP.View.MenuPrincipal;
using NOA_TRIP.View.Registro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NOA_TRIP.ViewModel
{
    public class VMdigitarcodigo:BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        #endregion
        #region CONSTRUCTOR
        public VMdigitarcodigo(INavigation navigation)
        {
            Navigation = navigation;
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
        public async void IraInicio()
        {
            await Navigation.PushAsync(new Vmenuprincipal());
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand Siguientecommand => new Command(IraInicio);
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
