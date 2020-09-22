using ManagementApp.Repo;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        public List<Category> Categories { get; set; }
        private Order order;
        private User u;
        private Place p;
        public MenuView(User U, Place plejs)
        {
            u = U;
            p = plejs;
            InitializeComponent();
            GetData();
            BindingContext = this;
        }

        private void GetData() => Categories = StorageRepo.getAllStorage(p.Id);

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Category c = e.Item as Category;
            if (order == null)
            {
                order = OrdersRepo.newOrder(u.PlaceId, "0", u.Id);
            }
            Navigation.PushAsync(new CatView(c, order));
        }
    }
}