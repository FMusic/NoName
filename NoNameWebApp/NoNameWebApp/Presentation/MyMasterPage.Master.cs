using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;
using System.Linq;

namespace NoNameWebApp.Presentation
{
    public partial class MyMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string uri = Request.Url.AbsoluteUri;

            string relativePath = uri.Substring(uri.LastIndexOf('/') + 1);

            bool isLoginPage = relativePath.Contains("Login");

            PanelNavigation.Visible = !isLoginPage;

            if (isLoginPage)
            {
                CommonPresentationStuff.ClearNavigationStack();
                return;
            }

            if (!IsPostBack)
            {
                CommonPresentationStuff.AddPageToNavigationStack(uri);
            }

            LabelPageTitle.Text = CommonPresentationStuff.GetPageTitle(relativePath);
            ButtonBack.Visible = CommonPresentationStuff.DoesPreviousPageExist();

            UserData userData = GetUserData();

            if (userData == null)
            {
                Response.Redirect("LoginPage.aspx", false);
                return;
            }

            LabelFullName.Text = string.Format(
                "{0} ",
                userData.FirstName + " " + userData.LastName);
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

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            string previousPage = CommonPresentationStuff.GetPreviousPage();

            if (previousPage != null)
            {
                Response.Redirect(previousPage, false);
            }
        }
    }
}