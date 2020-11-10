using MyIndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyIndividualProject.BusinessLogic;

namespace MyIndividualProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandPromptUtils cpUtils = new CommandPromptUtils();
            CourseUtils courseUtils = new CourseUtils();
            StudentUtils studentUtils = new StudentUtils();
            //Console.WriteLine(trainer);
            //Console.WriteLine(trainer2);
            //List<Trainer> trainers = new List<Trainer>();
            //trainers.AddcpUtils.GetTrainerDetails();
            //List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();
            courses = courseUtils.GetListOfCourses();
            List<Student> students = new List<Student>();
            students = studentUtils.GetListOfStudents(courses);

            CourseStudents studernsPerCourse = new CourseStudents();

            //List<Student> students = new List<Student>();
            //students = cpUtils.GetListOfStudents(courses);
            foreach (var item in courses)
            {
                
                Console.WriteLine($"This course:\n {item} \nHas these students :\n");
                List <string> listOfStudents = studernsPerCourse.StudentsPerCourse(item, students);
                for (int i = 0; i < listOfStudents.Count; i++)
                {
                    Console.WriteLine($"{listOfStudents[i]}\n");

                }
            }

            //cpUtils.CheckForDuplicateCourses(courses);

            //courseUtils.CheckForDuplicateCourses(courses);
            //courseUtils.PrintCoursesList(courses);



            //foreach (var item in students)
            //{
            //    Console.WriteLine(item);

            //}



            //students.Add(cpUtils.GetStudentDetails());

            //cpUtils.PrintTrainersList(trainers);
            //List<Course> courses = new List<Course>();
            //courses.Add(cpUtils.GetCourseDetails());
            //cpUtils.PrintCoursesList(courses);



        }


        // Create appropriate methods in order to ask
        // from the user data for the four main classes
    }
}
