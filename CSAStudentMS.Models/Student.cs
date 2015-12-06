using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAStudentMS.Models
{
    public class Student : User
    {
        private string name, program, status;
        private int yearlevel;
        public Student(string idnum, string name, string program, int yearlevel):base(idnum)
        {
            this.name = name;
            this.program = program;
            this.yearlevel = yearlevel;
        }
        public Student(string idnum, string status) : base(idnum)
        {
            this.status = status;
        }
        public Student(string idnum) : base(idnum)
        { }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Program   
        {
            get { return program; }
            set { program = value; }
        }

        public int YearLevel
        {
            get { return yearlevel; }
            set { yearlevel = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
