using NOA_TRIP.View;
using NOA_TRIP.View.MenuPrincipal;
using NOA_TRIP.View.Registro;
using NOA_TRIP.View.Reutilizables;
using NOA_TRIP.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NOA_TRIP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage( new Empezar());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
