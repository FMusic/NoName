using ManagementApp.Model;
using ManagementApp.Repo;
using ManagementApp.View;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ManagementApp.ViewModel
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
            try { 
                var u = UserRepo.CheckLogin(new LoginInfo(username, password));
                App.Current.MainPage = new MainNav(u);
            } catch(Exception ex)
            {
                DisplayInvalidLoginPrompt();
            }
        }
    }
}
