using ManagementApp.Model;
using ManagementApp.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WaiterApp.Views;
using Xamarin.Forms;

namespace WaiterApp.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }

        public void OnSubmit()
        {
            try
            {
                var u = UserRepo.CheckLogin(new LoginInfo(username, password));
                App.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                DisplayInvalidLoginPrompt();
            }
        }
    }
}
