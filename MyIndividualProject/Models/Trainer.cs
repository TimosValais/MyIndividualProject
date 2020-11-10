using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIndividualProject.Models
{
    class Trainer
    {
        private string _firstname; 
        private string _lastname;
        private List<string> _subjects; // must be from the courses list. could be composition

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

        public List<string> Subjects
        {
            get { return (this._subjects); }
            set { this._subjects = value; }
        }

        private List<Course> _trainercourses;

        public List<Course> TrainerCourses
        {
            get { return _trainercourses; }
            set { _trainercourses = value; }
        }


        public Trainer()
        {
            this._firstname = "Mr First Name";
            this._lastname = "Mr Last Name";
            List<Course> courses = new List<Course>();
            foreach (var item in courses)
            {
                this._subjects.Add($"{item.Title} {item.Stream} {item.Type}");

            }
            
        }



        public override string ToString()
        {

            return ($"First Name: {_firstname}\tLast Name: {_lastname}\tTeaches {_subjects.Count} subjects");

        }


    }
}
