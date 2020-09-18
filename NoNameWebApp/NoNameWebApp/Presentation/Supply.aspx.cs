using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace NoNameWebApp.Presentation
{
    public partial class Supply : System.Web.UI.Page
    {
        private const string KEY_MAIN_DATA = "mainData";

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonBusinessStuff.mainData = await RestClient.GetMainData();
                ViewState[KEY_MAIN_DATA] = CommonBusinessStuff.mainData;
            }
            else
            {
                CommonBusinessStuff.mainData = (MainData)ViewState[KEY_MAIN_DATA];
            }

            ShowCategories();
            ShowProducts();
        }

        private void ShowCategories()
        {
            int selectedIndex = DropDownListCategories.SelectedIndex;
            DropDownListCategories.DataSource = CommonBusinessStuff.mainData.Categories;
            DropDownListCategories.DataValueField = "Id";
            DropDownListCategories.DataTextField = "Name";

            if (selectedIndex != -1 && selectedIndex < CommonBusinessStuff.mainData.Categories.Count)
            {
                DropDownListCategories.SelectedIndex = selectedIndex;
            }

            DropDownListCategories.DataBind();
        }

        private void ShowProducts()
        {
            int selectedCategoryId = Convert.ToInt32(DropDownListCategories.SelectedValue);
            List<Product> visibleProducts = CommonBusinessStuff.mainData
                .Products
                .Where(p => p.CategoryId == selectedCategoryId)
                .ToList();

            GridViewProducts.DataSource = visibleProducts;
            GridViewProducts.DataBind();
        }

        protected void ButtonEditCategory_Click(object sender, EventArgs e)
        {
            int selectedCategoryId = Convert.ToInt32(DropDownListCategories.SelectedValue);
            string url = string.Format("EditCategory.aspx?id={0}", selectedCategoryId);
            Response.Redirect(url, false);
        }

        protected async void ButtonDeleteCategory_Click(object sender, EventArgs e)
        {
            int selectedCategoryId = Convert.ToInt32(DropDownListCategories.SelectedValue);
            bool success = await RestClient.DeleteCategory(selectedCategoryId);

            if (success)
            {
                CommonPresentationStuff.ShowAlert(this, "Kategorija uspješno obrisana!");
                CommonBusinessStuff.mainData.Categories.RemoveAll(c => c.Id == selectedCategoryId);
                ViewState[KEY_MAIN_DATA] = CommonBusinessStuff.mainData;
                ShowCategories();
                ShowProducts();
            }
            else
            {
                CommonPresentationStuff.ShowGenericErrorMessage(this);
            }
        }

        protected void ButtonAddCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCategory.aspx", false);
        }

        private int GetProductId(GridViewCommandEventArgs e)
        {
            LinkButton button = (LinkButton)e.CommandSource;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            return Convert.ToInt32(((HiddenField)row.FindControl("HiddenFieldProductId")).Value);
        }

        protected async void GridViewProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int productId = GetProductId(e);

            if (e.CommandName.Equals("EditProduct"))
            {
                string url = string.Format("EditProduct.aspx?id={0}", productId);
                Response.Redirect(url, false);
            }
            else if (e.CommandName.Equals("DeleteProduct"))
            {
                bool success = await RestClient.DeleteProduct(productId);

                if (success)
                {
                    CommonPresentationStuff.ShowAlert(this, "Proizvod uspješno obrisan!");
                    CommonBusinessStuff.mainData.Products.RemoveAll(p => p.Id == productId);
                    ViewState[KEY_MAIN_DATA] = CommonBusinessStuff.mainData;
                    ShowCategories();
                    ShowProducts();
                }
                else
                {
                    CommonPresentationStuff.ShowGenericErrorMessage(this);
                }
            }
        }

        protected void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx", false);
        }
    }
}
