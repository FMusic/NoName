using ManagementApp.Repo;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterView : ContentPage
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            User u = new User()
            {
                FirstName = fname.Text,
                LastName = lname.Text,
                Email = email.Text,
                Address = addr.Text,
                Username = un.Text,
                Password = pwd.Text,
                UserEnum = UserEnum.User,
                PlaceId = 0
            };
            UserRepo.NewEmpl(u);
            App.Current.MainPage = new LoginView();
        }
    }
}