using System;
using System.Collections.Generic;
using System.Text;

namespace Cap_Register.Models
{
    public class ChangeCourseTimeModel
    {
        public string SName { get; set; }
        public int snum { get; set; }
        public string description { get; set; }


        public int cnum { get; set; }

        public int currentDivision { get; set; }
        public int newDivision { get; set; }
    }
}
