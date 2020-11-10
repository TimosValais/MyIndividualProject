using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MyIndividualProject.Models;

namespace MyIndividualProject.BusinessLogic
{
    class StudentAssignment : CourseAssignments
    {
        private Student _student;

        public Student Student
        {
            get { return _student; }
            set { _student = value; }
        }

        private List<string> _listofassignments;

        public List<string> ListOfAssignments
        {
            get { return _listofassignments; }
            set { _listofassignments = value; }
        }

        private Course _course;

        public Course Course2
        {
            get { return _course; }
            set { _course = value; }
        }

        private List<Course> courses;

        public List<Course> Courses
        {
            get { return courses; }
            set { courses = value; }
        }

        private DateTime _enddate;

        public DateTime EndDate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }


        public StudentAssignment(Student student, List<Assignment> assignmentList)
        {
            List<Course> courses = GetListOfCoursesFromStudent(student);
            Console.WriteLine($"These are the the assignments of the courses of {student.LastName} {student.FirstName}");
            PrintAllAssignmentsPerAllCourses(courses, assignmentList);
        }

        public List<Course> GetListOfCoursesFromStudent (Student student)
        {
            List<Course> courses = new List<Course>();
            foreach (var item in student.CoursesOfStudent)
            {
                courses.Add(item);
            }
            return (courses);
        }

        public List<Course> GetCoursesFromAnAssignmentsDate(List<Assignment> assignments)
        {
            DateTime date = ConvertToDateTime($"{AskDetail("Give me a date to check which students owe an assignment that calendar week")}");
            List<Course> courses = new List<Course>();
            int weekDayInt = (int)date.DayOfWeek;
            // making the date go to Saturday, at 00.00.00 rather
            // than making it go to Friday as I did in the beggnining

            
            switch (weekDayInt)
            {
                case 0: // Sunday, date - 1
                    date.AddDays(-1);
                        break;
                case 1: // Monday, date + 5
                    date.AddDays(5);
                    break;
                case 2: // Tuesday, date + 4
                    date.AddDays(4);
                    break;
                case 3: // Wednesday date + 3
                    date.AddDays(3);
                    break;
                case 4: // Thursday date +2
                    date.AddDays(2);
                    break;
                case 5: // Friday, +1
                    date.AddDays(1);
                    break;
                case 6: // Saturday, do nothing
                    date.AddDays(0);
                    break;

            }

            foreach (var item in assignments)
            {
                if (item.SubmissionDateTime < date)
                {
                    for (int i = 0; i < item.CoursesOfAssignment.Count; i++)
                    {
                        courses.Add(item.CoursesOfAssignment[i]);
                    }
                }
            }

            this._enddate = date;

            return (courses);
                
        }

        public void PrintStudentsThatHaveAssignments (List<Course> courses, List<Student> students)
        {
            // we get the courses that have assignments until a certain 
            // date from the GetCoursesFromAnAssignmentsDate method
            // and then we list the students of these courses

            List<string> studentsWithAssignments = new List<string>();

            foreach (var item in courses)
            {
                bool hasTheCourse = true;


                foreach (var item2 in students)
                {
                    for (int i = 0; i < item2.CoursesOfStudent.Count; i++)
                    {
                        if (hasTheCourse == IsEqual(item, item2.CoursesOfStudent[i]))
                        {
                            if(CheckForDuplicateStrings(studentsWithAssignments, item2.FirstName + " " + item2.LastName) == false)
                            studentsWithAssignments.Add(item2.FirstName + " " + item2.LastName);
                        }

                    }

                }

            }

            // and now we have to remove duplicate entries from the list of Students
            // before printing
            // to remove duplicates I tried checking afterwards but the use of the method
            // CheckForDuplicateStrings while adding them seems necessairy (if it's a duplicate,
            // it won't add them to the list

            // lastly a for loop to print the students.

            Console.WriteLine($"Students That Have an Assignment until this {this._enddate}: ");
            foreach (var item in studentsWithAssignments)
            {
                Console.WriteLine($"{item}");
            }
        }





    }
}
