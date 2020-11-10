using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIndividualProject.Models
{
    class Assignment
    {
        private string _title;
        private string _description;
        private DateTime _subdatetime;
        private float _oralmark;
        private float _totalmark;

        public string Title
        {
            get { return (this._title); }
            set { this._title = value; }
        }

        public string Description
        {
            get { return (this._description); }
            set { this._description = value; }
        }

        public DateTime SubmissionDateTime
        {
            get { return (this._subdatetime); }
            set { this._subdatetime = value; }
        }

        public float OralMark
        {
            get { return (this._oralmark); }
            set { this._oralmark = value; }
        }
        public float TotalMark
        {
            get { return (this._totalmark); }
            set { this._totalmark = value; }
        }

        private List<Course> _coursesofassignment;

        public List<Course> CoursesOfAssignment
        {
            get { return _coursesofassignment; }
            set { _coursesofassignment = value; }
        }

        public Assignment()
        {
            this._title = "Generic Assingment";
            this._description = "This is a generic assignment";
            this._subdatetime = DateTime.Parse("12/12/2020 23:59:59");
            this._oralmark = 20.0f;
            this._totalmark = 80.0f;
            this._coursesofassignment = new List<Course>(); 
        }

        public override string ToString()
        {
            return ($"Assignment Title: {_title}\tDescription of the Assignment: {_description}\tSubmission Date and Time: {_subdatetime}\tOral Mark: {_oralmark}\tTotal Mark: {_totalmark}");
        }
    }
}
