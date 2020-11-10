using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIndividualProject.Models
{
     public class Course
    {
        private string _title ;
        private string _stream ;
        private string _type ;
        private DateTime _startdate ;
        private DateTime _enddate ;

        public string Title
        {
            get { return (this._title); }
            set { this._title = value; }
        }

        public string Stream
        {
            get { return (this._stream); }
            set { this._stream = value; }
        }

        public string Type
        {
            get { return (this._type); }
            set { this._type = value; }
        }

        public DateTime StartDate
        {
            get { return (this._startdate); }
            set { this._startdate = value; }
        }

        public DateTime EndDate
        {
            get { return (this._enddate); }
            set { this._enddate = value; }
        }

        public  Course()
        {
            this._title = "CB Generic";
            this._stream = "Generic Programming Language";
            this._type = "Generic Type";
            this._startdate = DateTime.Parse("1 / 1 / 1821");
            this._enddate = DateTime.Parse("25 / 03 / 1821");

        }
        public Course(string title, string stream, string type, DateTime startDate, DateTime endDate)
        {
            this._title = title;
            this._stream = stream;
            this._type = type;
            this._startdate = startDate;
            this._enddate = endDate;

        }

        public  bool IsEqual(Course course1, Course course2)
        {
            if (course1.Title == course2.Title &&
                course1.Stream == course2.Stream &&
                course1.Type == course2.Type &&
                course1.StartDate == course2.StartDate &&
                course1.EndDate == course2.EndDate)
            {
                return (true);
            }
            else
            {
                return (false);
            }
                
        }
        public override string ToString()
        {
            return ($"Course Title: {_title}\nCourse Stream: {_stream}\nCourse Type: {_type}\nCourse starts at: {_startdate:d}\nCourse ends at: {_enddate:d}");
        }
    }
}
