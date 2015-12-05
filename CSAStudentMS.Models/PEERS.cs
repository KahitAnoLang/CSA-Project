using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAStudentMS.Models
{
    //PEERS(good standing) Performance Enrichment and Evaluation Reinforcement 
    public class PEERS : Student
    {
        public PEERS(string idnum, string status) : base(idnum, status)
        { }
    }
}
