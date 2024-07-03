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
    public class StudentSuggestedCoursesViewModel : BaseViewModel
    {
        public string CourseName { get; set; }
        public int CourseNumber { get; set; }
        public int PrerequisiteCourseNumber { get; set; }
        public MvvmHelpers.Commands.Command GetSuggestedCoursesCommand { get; set; }

        private GetStudentSuggestedCoursesService services;

        public List<CoursePlanModel> SelectedCourses = new List<CoursePlanModel>();
        public ObservableCollection<CoursePlanModel> SuggestedCourses { get; set; }
        public ObservableCollection<CoursePlanModel> OfferdCourses { get; set; }

        public StudentSuggestedCoursesViewModel()
        {
            GetSuggestedCoursesCommand = new MvvmHelpers.Commands.Command(async () => await AddSuggestedCoursesCommandAsync());
            services = new GetStudentSuggestedCoursesService();
            SuggestedCourses = new ObservableCollection<CoursePlanModel>();
            OfferdCourses = new ObservableCollection<CoursePlanModel>();

            GetCourses();
            GetOfferdCourses();
        }
        public ICommand MultiSelectionCommand => new MvvmHelpers.Commands.Command<IList<object>>((obj) =>
        {

            List<CoursePlanModel> test = new List<CoursePlanModel>();

            foreach (var item in obj)
            {
                var selectedItems = item as CoursePlanModel;

                test.Add(selectedItems);

            }
            SelectedCourses = test;

        });

        private async Task AddSuggestedCoursesCommandAsync()
        {

            for (int i = 0; i < SelectedCourses.Count; i++)
            {


                await services.AddStudentSuggestedCourses(SelectedCourses[i].CourseNumber);

            }
        }
      
        private async void GetCourses()
        {
            try
            {
                var courses = await new GetStudentSuggestedCoursesService().GetCoursePlan();
                SuggestedCourses.Clear();
                foreach (var course in courses)
                {
                    SuggestedCourses.Add(course);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", "No Internet", "OK");
            }

    }

        private async void GetOfferdCourses()
        {
            try
            {
                var courses = await new GetStudentSuggestedCoursesService().GetOfferCourses();
                OfferdCourses.Clear();
                foreach (var course in courses)
                {
                    OfferdCourses.Add(course);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", "No Internet", "OK");
            }

        }


    }
}
