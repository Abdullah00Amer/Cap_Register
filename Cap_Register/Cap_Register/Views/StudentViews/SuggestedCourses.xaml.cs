using Cap_Register.Models;
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
    public partial class SuggestedCourses : ContentPage
    {
        
        public SuggestedCourses()
        {
            InitializeComponent();
            BindingContext = new CoursesPlanViewModel();

        }
       
    }
}