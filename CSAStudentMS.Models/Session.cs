using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAStudentMS.Models
{
    public class Session
    {
        private List<int> lstidnumA;
        private int idnumA, idnumP; 
        private TimeSpan duration;
        private string subject, sessionName;
        private DateTime timeStart, timeEnd;
        public Session(int idnumA, int idnumP, string subject, DateTime timeStart)
        {
            this.idnumA = idnumA;
            this.idnumP = idnumP;
            this.subject = subject;
            this.timeStart = timeStart;
        }
        public Session(List<int> lstidnumA, int idnumP, string subject)
        {
            this.lstidnumA = lstidnumA; 
        }     

        public int IdNumA
        {
            get { return idnumA; }
            set { idnumA = value; }
        }
        public int IdNumP
        {
            get { return idnumP; }
            set { idnumP = value; }
        }

        public List<int> LstIdNumA
        {
            get { return lstidnumA; }
            set { lstidnumA = value; }
        }
        public string SessionName
        {
            get { return sessionName; }
            set { sessionName    = value; }
        }
        public DateTime TimeStart
        {      
            get { return timeStart; }
            set { timeStart = value; }
        }
        public DateTime TimeEnd
        {
            get { return timeEnd; }
            set { timeEnd = value; }
        }
        public TimeSpan GetSessionDuration()
        {
            duration = TimeEnd - TimeStart;
            return duration;
        }


    }
}
