using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAStudentMS.Models
{
    interface ISalary
    {
        decimal GetPayCheck(string id);  
    }
}
