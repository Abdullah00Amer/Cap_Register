﻿using Cap_Register.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Cap_Register.Services
{
    public class CourseRegestrationDB
    {
        FirebaseClient client;

        public CourseRegestrationDB()
        {
            client = new FirebaseClient("https://cap-registration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<CourseRegisterModel> getCoach()
        {
            var CoachData = client.Child("CourseRegestration").AsObservable<CourseRegisterModel>().AsObservableCollection();



            return CoachData;



        }



        public async Task AddCoach(string sName, int Snum, int Cnum, int Divisionnumber, string Description)
        {
            CourseRegisterModel c = new CourseRegisterModel() { SName = sName, snum = Snum, cnum = Cnum, divisionnumber = Divisionnumber, description = Description };
            await client.Child("CourseRegestration").PostAsync(c);
        }

    }
}
