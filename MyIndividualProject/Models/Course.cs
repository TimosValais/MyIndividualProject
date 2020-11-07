﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIndividualProject.Models
{
     public class Course
    {
        private string _title;
        private string _stream;
        private string _type;
        private DateTime _startdate;
        private DateTime _enddate;

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

        public Course()
        {
            this._title = "CB Generic";
            this._stream = "Generic Programming Language";
            this._type = "Generic Time";
            this._startdate = DateTime.Parse("1 / 1 / 1821");
            this._enddate = DateTime.Parse("25 / 03 / 1821");

        }
        public override string ToString()
        {
            return ($"Course Title: {_title}\tCourse Stream: {_stream}\tCourse Type: {_type}\tCourse starts at: {_startdate}\tCourse ends at: {_enddate}");
        }
    }
}
