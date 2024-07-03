using System;
using System.Collections.Generic;
using System.Text;

namespace Cap_Register.Models
{
    public class CoursePlanModel
    {
        public string CourseName { get; set; }
        public int CourseNumber { get; set; }
        public int PrerequisiteCourseNumber { get; set; }
    }
}
