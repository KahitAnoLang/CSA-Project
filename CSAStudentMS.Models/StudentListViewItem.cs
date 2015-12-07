using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSAStudentMS.Models
{
    public class StudentListViewItem
    {
        public StudentListViewItem()
        { }
        public string StudNo { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Program { get; set; } 
    }
}
