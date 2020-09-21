﻿using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace NoNameWebApp.Presentation
{
    public partial class EditBill : System.Web.UI.Page
    {
        private const string KEY_BILL = "bill";
        private Bill bill;

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                bill = await RestClient.GetBill(id);
                ViewState[KEY_BILL] = bill;
            }
            else
            {
                bill = (Bill)ViewState[KEY_BILL];
            }

            ShowBill(false);
        }

        public string GetStatusName(BillStatus status)
        {
            return CommonBusinessStuff.statusNames[status.Name];
        }

        private void ShowBill(bool afterUpdate)
        {
            LabelNumber.Text = bill.TableNumber;
            LabelTotal.Text = CommonPresentationStuff.FormatPrice(bill.TotalPrice);

            GridViewContents.DataSource = bill.Contents;
            GridViewContents.DataBind();

            ShowDropdownListOfStatuses(afterUpdate);
        }

        private void ShowDropdownListOfStatuses(bool afterUpdate)
        {
            int selectedIndex = DropDownListStatuses.SelectedIndex;
            string lastStatus = bill.Charged ? "PAYED" : "CREATED";
            ListItem lastStatusItem = new ListItem(CommonBusinessStuff.statusNames[lastStatus], lastStatus);

            DropDownListStatuses.Items.Clear();
            DropDownListStatuses.Items.Add(lastStatusItem);

            foreach (string status in CommonBusinessStuff.statusTransitions[lastStatus])
            {
                ListItem item = new ListItem(CommonBusinessStuff.statusNames[status], status);
                DropDownListStatuses.Items.Add(item);
            }

            if (selectedIndex == -1 || afterUpdate)
            {
                DropDownListStatuses.SelectedValue = lastStatus;
            }
            else
            {
                DropDownListStatuses.SelectedIndex = selectedIndex;
            }
        }

        protected async void ButtonSave_Click(object sender, EventArgs e)
        {

            string lastStatus = bill.Charged ? "PAYED" : "CREATED";

            string selectedStatus = DropDownListStatuses.SelectedValue;

            if (selectedStatus.Equals(lastStatus))
            {
                return;
            }

            bill.Charged = true;
            bool successfullyUpdated = await RestClient.UpdateBill(bill);

            if (successfullyUpdated)
            {
                bill = await RestClient.GetBill(bill.Id.Value);

                if (bill != null)
                {
                    CommonPresentationStuff.ShowAlert(this, "Promjene su uspješno spremljene!");
                    ViewState[KEY_BILL] = bill;
                    ShowBill(true);

                    return;
                }
            }

            CommonPresentationStuff.ShowGenericErrorMessage(this);
        }
    }
}