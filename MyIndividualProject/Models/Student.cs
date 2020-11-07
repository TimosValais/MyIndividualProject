using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIndividualProject.Models
{
    public class Student
    {
        private string _firstname;
        private string _lastname;
        private DateTime _dateofbirth;
        private double _tuitionfees;
        public string FirstName
        {
            get { return (this._firstname); }
            set { this._firstname = value; }
        }
        public string LastName
        {
            get { return (this._lastname); }
            set { this._lastname = value; }
        }
        public DateTime DateOfBirth
        {
            get { return (this._dateofbirth); }
            set { this._dateofbirth = value; }
        }
        public double TuitionFees
        {
            get { return (this._tuitionfees); }
            set { this._tuitionfees = value; }
        }


        private List<Course> _coursesofstudent;

        public List<Course> CoursesOfStudent
        {
            get { return _coursesofstudent; }
            set { _coursesofstudent = value; }
        }


        public Student()
        {
            this._firstname = "Student First Name";
            this._lastname = "Student Last Name";
            this._dateofbirth = DateTime.Parse("01-01-1821");
            this._tuitionfees = 400.00F;
            Course course = new Course();
            this._coursesofstudent.Add(course);
            
        }

        public Student(Course course1, Course course2)
        {
            course1.Title = "C";
            course2.Title = "B";
            this._coursesofstudent.Add(course1);
            this._coursesofstudent.Add(course2);

        }
        public override string ToString()
        {
            return ($"Student Name: {_firstname} {_lastname}\tDate of Birth: {_dateofbirth}\tTuition Fees: {_tuitionfees}");
        }
    }
}
