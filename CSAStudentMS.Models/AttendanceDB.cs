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
            SqlCommand command = new SqlCommand("INSERT INTO Attendance (Studno, ATimeIn) VALUES (@STUDNO, @TIMEIN)", conn);
            command.Parameters.Add("@STUDNO", SqlDbType.VarChar);
            command.Parameters["@STUDNO"].Value = s.IdNum;
            command.Parameters.Add("@TIMEIN", SqlDbType.DateTime);
            command.Parameters["@TIMEIN"].Value = a.TimeStamp.ToShortTimeString();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            AddToLogs();
        }
        //Time-out log
        public void EditEntry()
        {
            SqlConnection conn = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand("UPDATE Attendance SET ATimeOut = @TIMEOUT where Studno = '"+s.IdNum+"'", conn);
            command.Parameters.Add("@TIMEOUT", SqlDbType.DateTime);
            command.Parameters["@TIMEOUT"].Value = a.TimeStamp.ToShortTimeString();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            command = new SqlCommand("UPDATE AttendanceLog SET ATimeOut = @TIMEOUT where Studno = '" + s.IdNum + "'", conn);
            command.Parameters.Add("@TIMEOUT", SqlDbType.DateTime);
            command.Parameters["@TIMEOUT"].Value = a.TimeStamp.ToShortTimeString();
            da = new SqlDataAdapter(command);
            ds = new DataSet();
            da.Fill(ds);
        }

        public void DeleteEntry()
        {
            SqlConnection conn = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand("DELETE FROM Attendance where Studno = '" + s.IdNum + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
        }

        public void AddToLogs()
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
    }
}
