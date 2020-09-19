using DataLayer.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static CategoriesDataService CategoriesDataService { get; set; } = new CategoriesDataService();
        public static ItemsDataService ItemsDataService { get; set; } = new ItemsDataService();
        public static GenericDataService GenericDataService { get; set; } = new GenericDataService();
        public static UsersDataService UsersDataService{ get; set; } = new UsersDataService();
        public static OrdersDataService OrdersDataService { get; set; } = new OrdersDataService();
        public static OrderItemsDataService OrderItemsDataService { get; set; } = new OrderItemsDataService();

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
