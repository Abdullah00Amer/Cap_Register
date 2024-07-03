using Cap_Register.Models;
using Cap_Register.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cap_Register.Views.AdminViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuggestedCoursesView : ContentPage
    {
        SuggestedCoursesViewModel SCVM;
        List<CoursePlanModel> SugesstedCourses = new List<CoursePlanModel>();
        public SuggestedCoursesView()
        {
          //  SugesstedCourses = sugesstedCourses;
          //  SCVM = new SuggestedCoursesViewModel();
            InitializeComponent();
        }
    }
}