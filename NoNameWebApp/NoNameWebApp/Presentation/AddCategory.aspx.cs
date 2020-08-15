using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;

namespace NoNameWebApp.Presentation
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected async void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxName.Text))
            {
                return;
            }

            Category category = new Category
            {
                Name = TextBoxName.Text
            };

            bool success = await RestClient.AddCategory(category);

            if (success)
            {
                CommonPresentationStuff.ShowAlert(this, "Kategorija uspješno dodana!");
                Response.Redirect("Supply.aspx", false);
            }
            else
            {
                CommonPresentationStuff.ShowGenericErrorMessage(this);
            }
        }
    }
}