using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoName_Management.Services;
using NoName_Management.Views;

namespace NoName_Management
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
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
