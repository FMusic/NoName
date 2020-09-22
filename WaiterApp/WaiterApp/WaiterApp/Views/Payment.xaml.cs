using ManagementApp.Repo;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaiterApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Payment : ContentPage
    {
        public IList<Order> OrdersPaid { get; set; }
        public IList<Order> OrdersUnpaid { get; set; }

        public Payment()
        {
            InitializeComponent();
            GetData();
            BindingContext = this;
        }

        private void GetData()
        {
            IList<Order> orders = OrdersRepo.getTodayOrders(App.user.PlaceId);
            OrdersPaid = orders.Where(x => x.Charged == true).ToList();
            OrdersUnpaid= orders.Where(x => x.Charged == false).ToList();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Order order = e.Item as Order;
            OpenDetails(order);
        }

        private void OpenDetails(Order order)
        {
            Navigation.PushAsync(new OrderDetailView(order));
        }
    }
}