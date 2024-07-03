using Cap_Register.Models;
using Cap_Register.ViewModels;
using Cap_Register.Views.AdminViews;
using Cap_Register.Views.FlyoutAdmin;
using Cap_Register.Views.StudentViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cap_Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMain : ContentPage
    {
        public FlyoutMain()
        {
            InitializeComponent();

            BindingContext = new CoursesPlanViewModel();
        }
        
        
        


    }
}