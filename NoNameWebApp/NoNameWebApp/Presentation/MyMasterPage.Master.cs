using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;
using System.Linq;
using System.Web.UI.WebControls;

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

            bool isAdmin = userData.userType.Name.Equals("Admin");

            // Ogranicenje pristupa.
            if (!isAdmin)
            {
                if (CommonBusinessStuff.pagesHiddenFromNonAdminUser.Any(p => Request.Url.AbsoluteUri.Contains(p)))
                {
                    Response.Redirect("MainPage.aspx", false);
                    return;
                }

                // Remove some links from navigation menu.
                string[] hiddenPages = new string[] { "Supply.aspx", "Reports.aspx" };

                foreach (string page in hiddenPages)
                {
                    string path = string.Format("~/Presentation/{0}", page);

                    for (int i = NavigationMenu.Items.Count - 1; i >= 0; --i)
                    {
                        MenuItem item = NavigationMenu.Items[i];

                        if (hiddenPages.Any(p => item.NavigateUrl.Contains(p)))
                        {
                            NavigationMenu.Items.RemoveAt(i);
                        }
                    }
                }
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