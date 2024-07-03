using Cap_Register.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Cap_Register.Services
{
    public class ChangeCourseTimeDB
    {
        FirebaseClient client;

        public ChangeCourseTimeDB()
        {
            client = new FirebaseClient("https://cap-registration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<ChangeCourseTimeModel> getCoach()
        {
            var CoachData = client.Child("ChangeCourseTime").AsObservable<ChangeCourseTimeModel>().AsObservableCollection();



            return CoachData;



        }



        public async Task AddChange(string sName, int Snum, int Cnum, int CurrentDivision, int NewDivision, string Description)
        {
            ChangeCourseTimeModel c = new ChangeCourseTimeModel() { SName = sName, snum = Snum, cnum = Cnum, currentDivision = CurrentDivision, newDivision = NewDivision, description = Description };
            await client.Child("ChangeCourseTime").PostAsync(c);
        }
    }
}
