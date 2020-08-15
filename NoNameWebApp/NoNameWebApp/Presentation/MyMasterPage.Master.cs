using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;

namespace NoNameWebApp.Presentation
{
    public partial class MyMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLoginPage = Request.Url.AbsoluteUri.Contains("Login");
            NavigationMenu.Visible = !isLoginPage;
            ButtonLogout.Visible = !isLoginPage;

            if (isLoginPage)
            {
                return;
            }

            UserData userData = GetUserData();

            if (userData == null)
            {
                Response.Redirect("LoginPage.aspx", false);
                return;
            }

            if (Request.Url.AbsoluteUri.Contains("Supply") && userData.userType.Name.Equals("Waiter"))
            {
                Response.Redirect("LoginPage.aspx", false);
                return;
            }
        }

        public UserData GetUserData()
        {
            UserData userData = (UserData)Session[CommonBusinessStuff.KEY_USER_DATA];
            return userData;
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Remove(CommonBusinessStuff.KEY_USER_DATA);
            Response.Redirect("LoginPage.aspx", false);
        }
    }
}