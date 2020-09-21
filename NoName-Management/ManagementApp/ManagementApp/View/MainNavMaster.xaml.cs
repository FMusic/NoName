using ManagementApp.Resources;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Plugin.Multilingual;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MenuItem = ManagementApp.Model.App.MenuItem;

namespace ManagementApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNavMaster : ContentPage
    {
        public ListView ListView;

        public MainNavMaster()
        {
            InitializeComponent();

            BindingContext = new MainNavMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainNavMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuItem> MenuItems { get; set; }

            public MainNavMasterViewModel()
            {
                var culture = new CultureInfo(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);
                CrossMultilingual.Current.CurrentCultureInfo = culture;
                AppResources.Culture = culture;

                MenuItems = new ObservableCollection<MenuItem>(new[]
                {
                    new MenuItem { Id = 0, Title = AppResources.dailyIncome, TargetType=typeof(Views.DailyPage) },
                    new MenuItem { Id = 1, Title =  AppResources.monthlyIncome, TargetType=typeof(Views.MonthlyPage)},
                    new MenuItem { Id = 2, Title = AppResources.storage, TargetType=typeof(Views.StoragePage) },
                    new MenuItem { Id = 3, Title = AppResources.employees, TargetType=typeof(Views.EmployeesPage) }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}