using ManagementApp.Model.App;
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
    public partial class StoragePage : ContentPage
    {
        public List<ItemList> items;
        public StoragePage(User u)
        {
            InitializeComponent();
            getData();
            BindingContext = this;
        }

        private void getData()
        {
            items = StorageRepo.getItems();
        }
    }
}