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
            //Console.WriteLine(trainer);
            //Console.WriteLine(trainer2);
            //List<Trainer> trainers = new List<Trainer>();
            //trainers.AddcpUtils.GetTrainerDetails();
            //List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();
            courses = courseUtils.GetListOfCourses();
            //List<Student> students = new List<Student>();
            //students = cpUtils.GetListOfStudents(courses);



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
