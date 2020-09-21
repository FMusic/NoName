using ManagementApp.View;
using Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManagementApp
{
    public partial class App : Application
    {
        bool debug = true;
        public App()
        {
            InitializeComponent();
            if (!debug)
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new MainNav(new User()
                {
                    FirstName = "Frane",
                    LastName = "Music",
                    PlaceId = 19,
                    Username = "fmusic",
                    Password = "fmusic"
                });
            }
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
