using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSAStudentMS.Models
{
    public static class Settings
    {
        public static string ConnectionString = @"Data Source="+Environment.MachineName+@"\SQLEXPRESS;Initial Catalog=CSA;Integrated Security=True";
    }
}
