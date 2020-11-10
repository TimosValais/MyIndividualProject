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

        private Course _course;

        public Course Course
        {
            get { return _course; }
            set { _course = value; }
        }

        private List<string> _studentsincourse;

        public List<string> StudentsInCourse
        {
            get { return _studentsincourse; }
            set { _studentsincourse = value; }
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
            this._course = course;
            this._studentsincourse = studentsInCourse;
            return (studentsInCourse);
        }

        public void PrintAllStudentsPerAllCourses(List<Course> courses, List<Student> students)
        {
            foreach (var item in courses)
            {

                Console.WriteLine($"This course:\n {item} \nHas these students :\n");
                List<string> listOfStudents = StudentsPerCourse(item, students);
                for (int i = 0; i < listOfStudents.Count; i++)
                {
                    Console.WriteLine($"{listOfStudents[i]}\n");

                }
            }
        }

        public void PrintAllStudentPerOneCourse(List<Course> courses, List<Student> students)
        {
            Console.WriteLine("Which Course's Students would you like to print? :");
            Course course = SelectFromListOfCourses(courses);
            List<string> studentsPerCourse = StudentsPerCourse(course, students);
            Console.WriteLine($"{course.Title} {course.Stream} {course.Type} has these students\n");
            for (int i = 0; i < studentsPerCourse.Count; i++)
            {
                Console.WriteLine($"{studentsPerCourse[i]}\n");

            }
        }




    }
}
