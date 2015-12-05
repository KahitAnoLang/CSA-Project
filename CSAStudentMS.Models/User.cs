using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSAStudentMS.Models
{
    public abstract class User
    {
        private string idnum;
        public User(string idnum)
        {
            this.idnum = idnum;
        }
       

        public string IdNum
        {
            get { return idnum; }
            set { idnum = value; }
        }

    }
}
