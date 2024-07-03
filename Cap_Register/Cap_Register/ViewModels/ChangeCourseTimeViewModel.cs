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
    public class ChangeCourseTimeViewModel : BaseViewModel

    {


        public string SName { get; set; }
        public string description { get; set; }

        public int snum { get; set; }
        public int cnum { get; set; }



        public int currentDivision { get; set; }
        public int newDivision { get; set; }


        private ChangeCourseTimeDB services;
        public Command AddCoachesCommand { get; }

        private ObservableCollection<ChangeCourseTimeModel> _coaches = new ObservableCollection<ChangeCourseTimeModel>();



        public ObservableCollection<ChangeCourseTimeModel> Coaches
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



        public ChangeCourseTimeViewModel()
        {





            services = new ChangeCourseTimeDB();
            Coaches = services.getCoach();

            AddCoachesCommand = new Command(async () => await AddChangeAsync(SName, snum, cnum, currentDivision, newDivision, description));

        }


        private async Task AddChangeAsync(string sName, int Snum, int Cnum, int CurrentDivision, int NewDivision, string Description)
        {
            await services.AddChange(sName, Snum, Cnum, CurrentDivision, NewDivision, Description);
        }
    }
}
