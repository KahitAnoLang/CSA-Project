using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAStudentMS.Models
{
    public class PeerAdviser : Student
    {
        private int renderedhours;
        public PeerAdviser(string idnum, string name, string program, int yearlevel) 
            : base(idnum,name, program, yearlevel)  
        { }
        public PeerAdviser(string idnum):base(idnum) { }

        public int RenderedHours
        {
            get { return renderedhours; }
            set { renderedhours = value; }
        }
    }
}
