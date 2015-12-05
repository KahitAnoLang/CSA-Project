using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAStudentMS.Models
{
    public class BundyClock
    {
        private DateTime timeOut, timeIn = DateTime.Now;
        private int idNum;
        public BundyClock(int idNum)
        {
            this.idNum = idNum;
        }
        
        public int IdNum
        {
            get { return idNum; }
            set { idNum = value; }
        }
        
        public DateTime TimeIn
        {
            get { return timeIn; }
            set { timeIn = value; }
        }

        public DateTime TimeOut
        {
            get { return timeOut; }
            set { timeOut = value; }
        }

        public TimeSpan GetTotalTime(DateTime TIn, DateTime TOut)
        {
            TimeSpan TTotal;

            TTotal = TimeOut - TimeIn;
            return TTotal;
        }
    }
}
