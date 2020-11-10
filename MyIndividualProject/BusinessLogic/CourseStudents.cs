using MyIndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyIndividualProject.BusinessLogic
{
    class CourseStudents : CommandPromptUtils
    {


        private List<Student> _students;

        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        private List<Course> _courses;

        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }

        //public CourseStudents(Course course, List<Student> students)
        //{
        //    bool hasTheCourse = true;
        //    List<string> studentsInCourse = new List<string>();

        //    foreach (var item in students)
        //    {
        //        for (int i = 0; i < item.CoursesOfStudent.Count; i++)
        //        {
        //            if (hasTheCourse == IsEqual(course, item.CoursesOfStudent[i]))
        //            {
        //                Console.WriteLine($"In {course} there are these students {item.FirstName + item.LastName}");
        //            }

        //        }
  
        //    }


        
        //    //IsEqual(courses[k], students[i].CoursesOfStudent[j]);
        //    //foreach (var item in students)
        //    //{
                
        //    //    if (IsEqual(item.CoursesOfStudent, courses[i]) == true)
        //    //        Console.WriteLine(item);
        //    //}

        //    //for (int i = 0; i < this._students.Count; i++)
        //    //{
        //    //    if (this._students.Course[i] = course) ;
        //    //    Console.WriteLine(this._students.FirstName[i] + this._students.LastName[i]);
        //    //}
        //}

        public List<string> StudentsPerCourse(Course course, List<Student> students)
        {
            bool hasTheCourse = true;
            List<string> studentsInCourse = new List<string>();

            foreach (var item in students)
            {
                for (int i = 0; i < item.CoursesOfStudent.Count; i++)
                {
                    if (hasTheCourse == IsEqual(course, item.CoursesOfStudent[i]))
                    {
                        studentsInCourse.Add(item.FirstName + " " + item.LastName);
                    }

                }

            }
            return (studentsInCourse);
        }



    }
}
