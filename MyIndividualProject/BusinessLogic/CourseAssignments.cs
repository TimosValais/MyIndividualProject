using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyIndividualProject.Models;

namespace MyIndividualProject.BusinessLogic
{
    class CourseAssignments : CommandPromptUtils
    {
        private List<Assignment> _assignments;

        private Course _course;

        public Course Course
        {
            get { return _course; }
            set { _course = value; }
        }

        private List<string> _assignmentincourse;

        public List<string> AssignmentsInCourse
        {
            get { return _assignmentincourse; }
            set { _assignmentincourse = value; }
        }

        public List<string> AssignmentsPerCourse(Course course, List<Assignment> assignments)
        {
            bool hasTheCourse = true;
            List<string> assignmentInCourse = new List<string>();

            foreach (var item in assignments)
            {
                for (int i = 0; i < item.CoursesOfAssignment.Count; i++)
                {
                    if (hasTheCourse == IsEqual(course, item.CoursesOfAssignment[i]))
                    {
                        assignmentInCourse.Add(item.Title + item.Description);
                    }

                }

            }
            this._course = course;
            this._assignmentincourse = assignmentInCourse;
            return (assignmentInCourse);
        }
        public void PrintAllAssignmentsPerAllCourses(List<Course> courses, List<Assignment> assignments)
        {
            foreach (var item in courses)
            {

                Console.WriteLine($"This course:\n {item} \nHas these assingments :\n");
                List<string> listOfAssignments = AssignmentsPerCourse(item, assignments);
                for (int i = 0; i < listOfAssignments.Count; i++)
                {
                    Console.WriteLine($"{listOfAssignments[i]}\n");

                }
            }
        }

        public void PrintAllAssignmentsPerOneCourse(List<Course> courses, List<Assignment> assignments)
        {
            Console.WriteLine("Which Course's Assignments would you like to print? :");
            Course course = SelectFromListOfCourses(courses);
            List<string> assignmentsPerCourse = AssignmentsPerCourse(course, assignments);
            Console.WriteLine($"{course.Title} {course.Stream} {course.Type} has these students\n");
            for (int i = 0; i < assignmentsPerCourse.Count; i++)
            {
                Console.WriteLine($"{assignmentsPerCourse[i]}\n");

            }
        }
    }
}
