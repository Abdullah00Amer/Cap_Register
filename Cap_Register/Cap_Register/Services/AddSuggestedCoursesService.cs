using Cap_Register.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cap_Register.Services
{
    public class AddSuggestedCoursesService
    {
        FirebaseClient client;

        public AddSuggestedCoursesService()
        {
            client = new FirebaseClient("https://capreg-3e786-default-rtdb.firebaseio.com/");

        }

        public async Task<List<CoursePlanModel>> GetCoursePlan()
        {

            var CoursePlan = (await client.Child("CoursePlan").OnceAsync<CoursePlanModel>()).Select(C => new CoursePlanModel
            {
                CourseName = C.Object.CourseName,
                CourseNumber = C.Object.CourseNumber,
                PrerequisiteCourseNumber = C.Object.PrerequisiteCourseNumber,
              
            }).ToList();

            return CoursePlan;
        }
        public async Task<List<CoursePlanModel>> GetSuggestedCourses()
        {

            var SuggestedCourses = (await client.Child("SuggestedCourses").OnceAsync<CoursePlanModel>()).Select(C => new CoursePlanModel
            {
                CourseName = C.Object.CourseName,
                CourseNumber = C.Object.CourseNumber,
                PrerequisiteCourseNumber = C.Object.PrerequisiteCourseNumber,

            }).ToList();

            return SuggestedCourses;
        }

        public async Task AddCourse(string CName, int CNumber, int PreCourseNumber)
        {
            CoursePlanModel c = new CoursePlanModel() { CourseName = CName, CourseNumber = CNumber, PrerequisiteCourseNumber = PreCourseNumber };
            await client.Child("SuggestedCourses").PostAsync(c);
        }
    }
}
