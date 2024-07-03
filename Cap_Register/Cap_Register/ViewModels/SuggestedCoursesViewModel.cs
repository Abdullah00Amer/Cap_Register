using Cap_Register.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Cap_Register.ViewModels
{
    public class SuggestedCoursesViewModel : BaseViewModel
    {
        public string CourseName { get; set; }
        public int CourseNumber { get; set; }
        public int PrerequisiteCourseNumber { get; set; }
       

        public SuggestedCoursesViewModel()
        {

          
        }
        /*
        public ICommand MultiSelectionCommand => new Command<IList<object>>((obj) =>
       {
          

           foreach (var item in obj)
           {
               var selectedItems = item as CoursePlanModel;
               test.Add(selectedItems);
           }
       });
       */
           
       
                
        
       

       
    }
}
