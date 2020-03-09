using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Consultar_CEP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new consulta()) {
                BarBackgroundColor = Color.FromRgb(255, 191,0)};
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
