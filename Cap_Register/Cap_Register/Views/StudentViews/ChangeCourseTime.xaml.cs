using Cap_Register.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cap_Register.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeCourseTime : ContentPage
    {
        public ChangeCourseTime()
        {
            InitializeComponent();
            BindingContext = new ChangeCourseTimeViewModel();
        }
    }
}