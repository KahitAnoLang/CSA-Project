using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSA
{
    public class TimeInModel
    {
        public string Username { get; set; }
    }
        
    public class StudentListModel
    {
        public StudentModel[] StudentList
        {
            get
            {
                return new StudentModel[]
                {
                    new StudentModel()
                    {
                        StudentNo = "2012122921",
                        Name = "Bryan DC"
                    },
                    new StudentModel()
                    {
                        StudentNo = "20190338933",
                        Name = "Noot"
                    }
                };
            }
        }
    }

    public class StudentModel
    {
        public string StudentNo { get; set; }
        public string Name { get; set; }
    }
}
