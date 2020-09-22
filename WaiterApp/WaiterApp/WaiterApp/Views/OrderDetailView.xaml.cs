using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementApp.Repo;
using Model;
using WaiterApp.Model.App;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaiterApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailView : ContentPage
    {
        public IList<OrderViewItem> Items { get; set; }
        public double orderMoney { get; set; }

        private int orderId;
        private Order Order;
        public OrderDetailView(Order order)
        {
            InitializeComponent();
            orderId = order.Id;
            orderMoney = order.TotalPrice;
            Items = OrdersRepo.GetViewItemsForOrder(order);
            BindingContext = this;
            Order = order;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Order.Charged = true;
            OrdersRepo.UpdateOrder(Order);
        }
    }
}