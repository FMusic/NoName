using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;
using System.Linq;

namespace NoNameWebApp.Presentation
{
    public partial class EditCategory : System.Web.UI.Page
    {
        private const string KEY_CATEGORY = "category";
        private Category category;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                category = CommonBusinessStuff.mainData.Categories.Single(c => c.Id == id);
                ViewState[KEY_CATEGORY] = category;
                
                // Text box treba setirati samo u GET requestu (specificno ponasanje).
                TextBoxName.Text = category.Name;
            }
            else
            {
                category = (Category)ViewState[KEY_CATEGORY];
            }
        }

        protected async void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxName.Text))
            {
                return;
            }

            category.Name = TextBoxName.Text;
            bool success = await RestClient.UpdateCategory(category);

            if (success)
            {
                CommonPresentationStuff.ShowAlert(this, "Kategorija uspješno promijenjena!");
            }
            else
            {
                CommonPresentationStuff.ShowGenericErrorMessage(this);
            }
        }
    }
}