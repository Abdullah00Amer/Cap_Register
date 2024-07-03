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
    public class GetStudentSuggestedCoursesService
    {
        FirebaseClient client;

        public GetStudentSuggestedCoursesService()
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
        public async Task AddStudentSuggestedCourses(int CNumber)
        {
            var StudentSuggestedCourses = new List<CoursePlanModel>();
            var uniqeCourses = new List<CoursePlanModel>();
            var SuggestedCourses = (await GetSuggestedCourses()).Where(c => c.PrerequisiteCourseNumber == CNumber || c.PrerequisiteCourseNumber == 0).ToList();
            foreach(var course in SuggestedCourses)
            {
                StudentSuggestedCourses.Add(course);
            }

           
            for (int i =0;i< StudentSuggestedCourses.Count;i++)
            {
                CoursePlanModel c = new CoursePlanModel() { CourseName = StudentSuggestedCourses[i].CourseName, CourseNumber = StudentSuggestedCourses[i].CourseNumber, PrerequisiteCourseNumber = StudentSuggestedCourses[i].PrerequisiteCourseNumber };
                await client.Child("StudentSuggestedCourses").PostAsync(c);
            }


           
        }

        public async Task<List<CoursePlanModel>> GetOfferCourses()
        {

            var OfferdCourses = (await client.Child("StudentSuggestedCourses").OnceAsync<CoursePlanModel>()).Select(C => new CoursePlanModel
            {
                CourseName = C.Object.CourseName,
                CourseNumber = C.Object.CourseNumber,
                PrerequisiteCourseNumber = C.Object.PrerequisiteCourseNumber,

            }).ToList();

            return OfferdCourses;
        }

        public async Task<List<CoursePlanModel>> GetStudentSuggestedCourses()
        {
            
            var SuggestedCourses = (await client.Child("StudentSuggestedCourses").OnceAsync<CoursePlanModel>()).Select(C => new CoursePlanModel
            {
                CourseName = C.Object.CourseName,
                CourseNumber = C.Object.CourseNumber,
                PrerequisiteCourseNumber = C.Object.PrerequisiteCourseNumber,

            }).ToList();

            return SuggestedCourses;
        }

    }
}
