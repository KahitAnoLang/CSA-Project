using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAStudentMS.Models
{
    public class Announcement
    {
        private int id;
        private string title, content;
        private DateTime timestamp;
        public Announcement(int id, DateTime timestamp, string title, string content)
        {
            this.id = id;
            this.timestamp = timestamp;
            this.title = title;
            this.content = content;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
  
        public DateTime TimeStamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }



    }
}
