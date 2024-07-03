using Cap_Register.Models;
using Cap_Register.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers;


namespace Cap_Register.ViewModels
{
    public class CourseRegisterViewModel : BaseViewModel
    {
        public string SName { get; set; }
        public string description { get; set; }

        public int snum { get; set; }
        public int cnum { get; set; }

        public int divisionnumber { get; set; }




        private CourseRegestrationDB services;
        public Command AddCoachesCommand { get; }

        private ObservableCollection<CourseRegisterModel> _coaches = new ObservableCollection<CourseRegisterModel>();



        public ObservableCollection<CourseRegisterModel> Coaches
        {
            get
            {


                return _coaches;
            }
            set
            {
                _coaches = value;
                OnPropertyChanged();
            }
        }



        public CourseRegisterViewModel()
        {



            services = new CourseRegestrationDB();
            Coaches = services.getCoach();

            AddCoachesCommand = new Command(async () => await AddCoachAsync(SName, snum, cnum, divisionnumber, description));

        }


        private async Task AddCoachAsync(string sName, int Snum, int Cnum, int Divisionnumber, string Description)
        {
            await services.AddCoach(sName, Snum, Cnum, Divisionnumber, Description);
        }
    }
}
