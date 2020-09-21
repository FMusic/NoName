using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManagementApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNav : MasterDetailPage
    {
        User User;
        public MainNav(User u)
        {
            User = u;
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Model.App.MenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType, User);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}