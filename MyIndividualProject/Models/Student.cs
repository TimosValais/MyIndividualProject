using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIndividualProject.Models
{
    class Student
    {
        private string _firstname;
        private string _lastname;
        private DateTime _dateofbirth;
        private string _tuitionfees;

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
        public string TuitionFees
        {
            get { return (this._tuitionfees); }
            set { this._tuitionfees = value; }
        }
        public override string ToString()
        {
            return ($"Student Name: {_firstname} {_lastname}\tDate of Birth: {_dateofbirth}\tTuition Fees: {_tuitionfees}");
        }
    }
}
