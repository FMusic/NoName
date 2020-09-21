using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;
using System.Linq;

namespace NoNameWebApp.Presentation
{
    public partial class EditProduct : System.Web.UI.Page
    {
        private const string KEY_PRODUCT = "product";
        private Product product;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                product = CommonBusinessStuff.mainData.Products.Single(p => p.Id == id);
                ViewState[KEY_PRODUCT] = product;

                TextBoxAvailableQuantity.Text = product.Quantity.ToString();
                TextBoxPrice.Text = product.Price.ToString();
            }
            else
            {
                product = (Product)ViewState[KEY_PRODUCT];
            }

            ShowProduct();
        }

        private void ShowProduct()
        {
            LabelName.Text = product.Name;
            
            int selectedIndex = DropDownListCategories.SelectedIndex;
            DropDownListCategories.DataSource = CommonBusinessStuff.mainData.Categories;
            DropDownListCategories.DataValueField = "Id";
            DropDownListCategories.DataTextField = "Name";
            DropDownListCategories.DataBind();

            if (selectedIndex == -1)
            {
                for (int i = 0; i < DropDownListCategories.Items.Count; i++)
                {
                    if (Convert.ToInt32(DropDownListCategories.Items[i].Value) == product.CategoryId)
                    {
                        DropDownListCategories.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                DropDownListCategories.SelectedIndex = selectedIndex;
            }
        }

        protected async void ButtonSave_Click(object sender, EventArgs e)
        {
            int availableQuantity = Convert.ToInt32(TextBoxAvailableQuantity.Text);
            bool priceParsedSuccessfully = float.TryParse(TextBoxPrice.Text, out float price);

            if (availableQuantity < 0 || !priceParsedSuccessfully)
            {
                CommonPresentationStuff.ShowAlert(this, "Neispravni podatci!");
                return;
            }

            product.Quantity = availableQuantity;
            product.Price = price;
            product.CategoryId = Convert.ToInt32(DropDownListCategories.SelectedValue);
            bool success = await RestClient.UpdateProduct(product);

            if (success)
            {
                CommonPresentationStuff.ShowAlert(this, "Proizvod uspješno promijenjen!");
                ViewState[KEY_PRODUCT] = product;
                ShowProduct();
            }
            else
            {
                CommonPresentationStuff.ShowGenericErrorMessage(this);
            }
        }
    }
}
