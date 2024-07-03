using Cap_Register.Views;
using Cap_Register.Views.StudentViews;
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

namespace Cap_Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class FlyoutFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutFlyoutMenuItem>(new[]
                {
                    new FlyoutFlyoutMenuItem { Id = 0, Title = "Home",TargetType=typeof(FlyoutMain) },
                    new FlyoutFlyoutMenuItem { Id = 1, Title = "Add Course",TargetType=typeof(CourseRegistration) },
                    new FlyoutFlyoutMenuItem { Id = 2, Title = "Drop Course",TargetType=typeof(DropCourse) },
                    new FlyoutFlyoutMenuItem { Id = 3, Title = "Change Course Time", TargetType=typeof(ChangeCourseTime) },
                    new FlyoutFlyoutMenuItem { Id = 4, Title = "SuggestedCourses", TargetType=typeof(SuggestedCourses) },
                    new FlyoutFlyoutMenuItem { Id = 5, Title = "StudentSuggestedCourses", TargetType=typeof(StudentSuggestedCourses) },
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