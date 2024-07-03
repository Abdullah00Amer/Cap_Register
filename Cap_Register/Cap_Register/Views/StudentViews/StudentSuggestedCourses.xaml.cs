using Cap_Register.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cap_Register.Views.StudentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentSuggestedCourses : ContentPage
    {
        public StudentSuggestedCourses()
        {
            InitializeComponent();
            BindingContext = new StudentSuggestedCoursesViewModel();

        }
    }
}