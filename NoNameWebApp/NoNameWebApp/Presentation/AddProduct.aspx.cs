using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;

namespace NoNameWebApp.Presentation
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowCategories();
            }
        }

        private void ShowCategories()
        {
            DropDownListCategories.DataSource = CommonBusinessStuff.mainData.Categories;
            DropDownListCategories.DataValueField = "Id";
            DropDownListCategories.DataTextField = "Name";
            DropDownListCategories.DataBind();
        }

        protected async void ButtonAdd_Click(object sender, EventArgs e)
        {
            bool nameEntered = !string.IsNullOrWhiteSpace(TextBoxName.Text);
            int quantity = Convert.ToInt32(TextBoxAvailableQuantity.Text);
            bool priceParsedSuccessfully = float.TryParse(TextBoxPrice.Text, out float price);

            if (!nameEntered || quantity < 0 || !priceParsedSuccessfully)
            {
                CommonPresentationStuff.ShowAlert(this, "Neispravni podatci!");
                return;
            }

            Product product = new Product
            {
                Name = TextBoxName.Text,
                Quantity = quantity,
                Price = price,
                CategoryId = Convert.ToInt32(DropDownListCategories.SelectedValue)
            };

            bool success = await RestClient.AddProduct(product);

            if (success)
            {
                Response.Redirect("Supply.aspx", false);
            }
            else
            {
                CommonPresentationStuff.ShowGenericErrorMessage(this);
            }
        }
    }
}