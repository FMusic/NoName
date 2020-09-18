using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace NoNameWebApp.Presentation
{
    public partial class MainPage : System.Web.UI.Page
    {
        private const string KEY_MAIN_DATA = "mainData";
        private const string KEY_BILL_CONTENTS = "billContents";
        private List<BillContent> billContents;

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonBusinessStuff.mainData = await RestClient.GetMainData();

                billContents = new List<BillContent>();

                ViewState[KEY_MAIN_DATA] = CommonBusinessStuff.mainData;
                ViewState[KEY_BILL_CONTENTS] = billContents;
            }
            else
            {
                CommonBusinessStuff.mainData = (MainData)ViewState[KEY_MAIN_DATA];
                billContents = (List<BillContent>)ViewState[KEY_BILL_CONTENTS];
            }

            ShowCategories();
            ShowProducts();
            ShowBillContents();
        }

        private void ShowCategories()
        {
            int selectedIndex = DropDownListCategories.SelectedIndex;
            DropDownListCategories.DataSource = CommonBusinessStuff.mainData.Categories;
            DropDownListCategories.DataValueField = "Id";
            DropDownListCategories.DataTextField = "Name";

            if (selectedIndex != -1)
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

        private void ShowBillContents()
        {
            if (billContents.Count == 0)
            {
                PanelBillContents.Visible = false;
                return;
            }

            GridViewBillContents.DataSource = billContents;
            GridViewBillContents.DataBind();
            LabelTotal.Text = CommonPresentationStuff.FormatPrice(GetTotalBillPrice());
            PanelBillContents.Visible = true;
        }

        private float GetTotalBillPrice()
        {
            float result = 0;

            foreach (BillContent content in billContents)
            {
                result += content.ProductPrice * content.ProductQuantity;
            }

            return result;
        }

        private Product GetProductBehindSelectedRow(GridViewCommandEventArgs e)
        {
            LinkButton button = (LinkButton)e.CommandSource;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int productId = Convert.ToInt32(((HiddenField)row.FindControl("HiddenFieldProductId")).Value);
            return CommonBusinessStuff.mainData.Products.First(p => p.Id == productId);
        }

        protected void GridViewProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("AddProduct"))
            {
                return;
            }

            Product product = GetProductBehindSelectedRow(e);
            BillContent content = billContents.FirstOrDefault(item => item.CorrespondingProduct.Id == product.Id);

            if (content == null)
            {
                content = new BillContent()
                {
                    ProductPrice = product.Price,
                    ProductQuantity = 1,
                    CorrespondingProduct = product
                };

                billContents.Add(content);
            }
            else
            {
                ++content.ProductQuantity;
            }

            ViewState[KEY_BILL_CONTENTS] = billContents;
            ShowBillContents();
        }

        protected void GridViewBillContents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Product product = GetProductBehindSelectedRow(e);
            BillContent content = billContents.First(item => item.CorrespondingProduct.Id.Equals(product.Id));

            if (e.CommandName.Equals("DecreaseQuantity"))
            {
                --content.ProductQuantity;

                if (content.ProductQuantity == 0)
                {
                    billContents.Remove(content);
                }
            }
            else if (e.CommandName.Equals("IncreaseQuantity"))
            {
                ++content.ProductQuantity;
            }

            ShowBillContents();
        }

        protected async void ButtonOrder_Click(object sender, EventArgs e)
        {
            if (billContents.Count == 0)
            {
                return;
            }

            Bill bill = new Bill
            {
                Contents = new List<BillContent>(),
                Statuses = new List<BillStatus>()
            };

            bill.Contents.AddRange(billContents);
            bill.Statuses.Add(new BillStatus { Name = "CREATED" });

            bool success = await RestClient.CreateBill(bill);

            if (success)
            {
                CommonPresentationStuff.ShowAlert(this, "Narudžba uspješno obavljena!");

                DropDownListCategories.SelectedIndex = 0;
                billContents.Clear();
                ViewState[KEY_BILL_CONTENTS] = billContents;

                ShowCategories();
                ShowProducts();
                ShowBillContents();
            }
            else
            {
                CommonPresentationStuff.ShowGenericErrorMessage(this);
            }
        }
    }
}