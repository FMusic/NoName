using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace NoNameWebApp.Presentation
{
    public partial class Reports : Page
    {
        protected async void ButtonRevenue_Click(object sender, EventArgs e)
        {
            List<Revenue> revenueList = new List<Revenue>();
            string date = SelectedDate.Text;
            int placeId = MainData.UserData.PlaceId.Value;

            Revenue revenue = await RestClient.GetRevenue(date, placeId);

            if (revenue == null)
            {
                CommonPresentationStuff.ShowAlert(this, "Invalid request.");
            }
            else
            {
                revenueList.Add(revenue);
                GridViewRevenue.DataSource = revenueList;
                GridViewRevenue.DataBind();
            }
        }
    }
}