using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CSAStudentMS.Models
{
    public class AttendanceDB : IQuery
    {
        private Student s;
        private Attendance a;
        public AttendanceDB(Student s, Attendance a)
        {
            this.s = s;
            this.a = a;
        }
        //Time-in log
        public void AddEntry()
        {
            SqlConnection conn = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand("INSERT INTO AttendanceLog (Studno, ATimeIn) VALUES (@STUDNO, @TIMEIN)", conn);
            command.Parameters.Add("@STUDNO", SqlDbType.VarChar);
            command.Parameters["@STUDNO"].Value = s.IdNum;
            command.Parameters.Add("@TIMEIN", SqlDbType.DateTime);
            command.Parameters["@TIMEIN"].Value = a.TimeStamp.ToShortTimeString();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);        
        }
        //Time-out log
        public void EditEntry()
        {
            throw new NotImplementedException();
        }

        public void DeleteEntry()
        {
            throw new NotImplementedException();
        }
    }
}
