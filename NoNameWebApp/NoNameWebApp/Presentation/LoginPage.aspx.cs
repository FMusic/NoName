using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;
using System.Web.UI;

namespace NoNameWebApp.Presentation
{
    public partial class LoginPage : Page
    {
        protected async void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxUserName.Text)
                && string.IsNullOrWhiteSpace(TextBoxPassword.Text))
            {
                return;
            }

            UserData userData = new UserData
            {
                UserName = TextBoxUserName.Text,
                Password = TextBoxPassword.Text
            };

            UserData userDataFromDB = await RestClient.CheckLogin(userData);

            if (userDataFromDB == null)
            {
                CommonPresentationStuff.ShowAlert(this, "Krivo korisničko ime i/ili lozinka.");
            }
            else
            {
                Session[CommonBusinessStuff.KEY_USER_DATA] = userDataFromDB;
                Response.Redirect("MainPage.aspx", false);
            }
        }
    }
}