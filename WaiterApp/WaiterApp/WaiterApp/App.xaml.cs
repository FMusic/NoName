using System;
using Xamarin.Forms;
using WaiterApp.Views;
using Model;

namespace WaiterApp
{
    public partial class App : Application
    {
        public static User user { get; set; }
        bool debug = false;
        public App()
        {
            if (!debug)
            {
                MainPage = new LoginView();
            }
            else
            {
                
                user = new User()
                {
                    Id = 38,
                    FirstName = "Frane",
                    LastName = "Music",
                    PlaceId = 19,
                    Username = "fmusic",
                    Password = "fmusic"
                };
                MainPage = new MainPage();
            }
            InitializeComponent();
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
