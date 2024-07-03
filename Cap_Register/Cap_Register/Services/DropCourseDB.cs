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
    public class DropCourseDB
    {
        FirebaseClient client;

        public DropCourseDB()
        {
            client = new FirebaseClient("https://cap-registration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<DropCourseModel> getCoach()
        {
            var CoachData = client.Child("DeleteCourse").AsObservable<DropCourseModel>().AsObservableCollection();



            return CoachData;



        }
        public async Task AddCoach(string sName, int Snum, int Cnum, int Divisionnumber, string Description)
        {
            DropCourseModel c = new DropCourseModel() { SName = sName, snum = Snum, cnum = Cnum, divisionnumber = Divisionnumber, description = Description };
            await client.Child("DeleteCourse").PostAsync(c);
        }
    }
   

}
