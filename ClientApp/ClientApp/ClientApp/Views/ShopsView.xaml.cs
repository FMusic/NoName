using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp.Repo;
using Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopsView : ContentPage
    {
        public IList<Place> All { get; set; }
        public IList<Place> Places { get; set; }
        private User user;
        public ShopsView(User u)
        {
            InitializeComponent();
            All = PlacesRepo.GetAllPlaces();
            Places = All;
            BindingContext = this;
            user = u;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var place = e.Item as Place;
            Navigation.PushAsync(new MenuView(user, place));
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Places = All.Where(x => x.Name.ToLower().Contains(entry.Text.ToLower())).ToList();
        }
    }
}