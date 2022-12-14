using LabSemana16.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LabSemana16
{
    public partial class App : Application
    {
        public static PersonManager PersonManager { get; set; }
        public App()
        {
            InitializeComponent();

            PersonManager = new PersonManager(new RestService());
            MainPage = new NavigationPage(new Views.PersonListPage());
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
