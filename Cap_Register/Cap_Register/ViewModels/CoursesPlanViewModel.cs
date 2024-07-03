using Cap_Register.Models;
using Cap_Register.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cap_Register.ViewModels
{
    public class CoursesPlanViewModel : BaseViewModel
    {
        public string CourseName { get; set; }
        public int CourseNumber { get; set; }
        public int PrerequisiteCourseNumber { get; set; }
        public List<CoursePlanModel> SuggestedCourse = new List<CoursePlanModel>();
        public MvvmHelpers.Commands.Command StoreDataCommand { get; set; }
        private AddSuggestedCoursesService services;

      
        public ObservableCollection<CoursePlanModel> CoursePlan { get; set; }
        public ObservableCollection<CoursePlanModel> SuggestedCoursesData { get; set; }
        public CoursesPlanViewModel()
        {
            CoursePlan = new ObservableCollection<CoursePlanModel>();
            SuggestedCoursesData = new ObservableCollection<CoursePlanModel>();
            GetCourses();
            GetSuggestedCoursesAsync();
            services = new AddSuggestedCoursesService();
            StoreDataCommand = new MvvmHelpers.Commands.Command(async () => await StoreDataCommandAsync());
        }

        private async Task GetSuggestedCoursesAsync()
        {
            try
            {
                var courses = await new AddSuggestedCoursesService().GetSuggestedCourses();
                SuggestedCoursesData.Clear();
                foreach (var course in courses)
                {
                    SuggestedCoursesData.Add(course);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", "No Internet", "OK");
            }
        }

        private async Task StoreDataCommandAsync()
        {
            
            for(int i = 0;i< SuggestedCourse.Count;i++)
            {
               
                
                await services.AddCourse(SuggestedCourse[i].CourseName, SuggestedCourse[i].CourseNumber,SuggestedCourse[i].PrerequisiteCourseNumber);

            }
        }

        public ICommand MultiSelectionCommand => new MvvmHelpers.Commands.Command<IList<object>>((obj) =>
        {

            List<CoursePlanModel> test = new List<CoursePlanModel>();

            foreach(var item in obj)
            {
                var selectedItems = item as CoursePlanModel;

                test.Add(selectedItems);

            }
            SuggestedCourse = test;
            
        });

        public ICommand StoreCommand => new Xamarin.Forms.Command<IList<object>>((obj) =>
        {

            List<CoursePlanModel> test = new List<CoursePlanModel>();

            foreach (var item in obj)
            {
                var selectedItems = item as CoursePlanModel;

                test.Add(selectedItems);

            }

        });

       

        private async void GetCourses()
        {
            try
            {
                var courses = await new AddSuggestedCoursesService().GetCoursePlan();
                CoursePlan.Clear();
                foreach (var course in courses)
                {
                    CoursePlan.Add(course);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", "No Internet", "OK");
            }

        }

      
    }

   
}
