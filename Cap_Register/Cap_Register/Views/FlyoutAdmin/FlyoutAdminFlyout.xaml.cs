using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cap_Register.Views.FlyoutAdmin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutAdminFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutAdminFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutAdminFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class FlyoutAdminFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutAdminFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutAdminFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutAdminFlyoutMenuItem>(new[]
                {
                    new FlyoutAdminFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new FlyoutAdminFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new FlyoutAdminFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new FlyoutAdminFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new FlyoutAdminFlyoutMenuItem { Id = 4, Title = "Page 5" },
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