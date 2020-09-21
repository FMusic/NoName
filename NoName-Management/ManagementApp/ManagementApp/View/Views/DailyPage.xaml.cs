using ManagementApp.Repo;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManagementApp.View.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyPage : ContentPage
    {
        public User U { get; set; }
        public IList<Order> ordersToday { get; set; }
        public DailyPage(User u)
        {
            InitializeComponent();
            U = u;
            getData();
            setContext();
        }

        public DailyPage()
        {
            InitializeComponent();
        }

        private void getData()
        {
            ordersToday = OrdersRepo.getTodayOrders(U.PlaceId);

        }

        private void setContext()
        {
            BindingContext = this;
        }
    }
}