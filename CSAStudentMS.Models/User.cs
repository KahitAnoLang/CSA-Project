using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSAStudentMS.Models
{
    public abstract class User
    {
        private int idnum;
        public User(int idnum)
        {
            this.idnum = idnum;
        }
       

        public int IdNum
        {
            get { return idnum; }
            set { idnum = value; }
        }

    }
}
