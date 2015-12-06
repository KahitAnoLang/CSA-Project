using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSAStudentMS.Models
{
    public class Attendance
    {
        private DateTime timestamp;
        public Attendance(DateTime timestamp)
        {
            this.timestamp = timestamp;
        }
        public DateTime TimeStamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
    }
}
