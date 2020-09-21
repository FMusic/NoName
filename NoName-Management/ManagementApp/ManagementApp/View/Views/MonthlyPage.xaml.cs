using ManagementApp.Model;
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
    public partial class MonthlyPage : ContentPage
    {
        public IList<Revenue> revenuesForMonth { get; set; }
        public MonthlyPage(User u)
        {
            InitializeComponent();
            revenuesForMonth = OrdersRepo.getMonthRev(u.PlaceId);
            BindingContext = this;
        }
    }
}