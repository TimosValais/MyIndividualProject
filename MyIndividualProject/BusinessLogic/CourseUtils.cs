using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using MyIndividualProject.Models;

namespace MyIndividualProject.BusinessLogic
{
    class CourseUtils : CommandPromptUtils
    {
        public List<Course> GetListOfCourses()
        {
            string option1 = "Use synthetic courses";
            string option2 = "Choose from our colection of programming courses";
            string option3 = "Add your own courses";

            Console.WriteLine("Time to add the courses of the school!\n" +
                $"Would you like to : \n" +
                $"{ConvertToInt(SelectFromListOfStrings(new List<string>(){option1, option2, option3}))}");





















            Console.Write("Time to add the courses of the school\ntype " +
                "S to use synthetic courses, or type any key to add your own: ");
            string choice = Console.ReadLine();
            List<Course> listOfCourses = new List<Course>();
            if (choice == "S")
            {
                listOfCourses = GetSyntheticCourses();
            }
            else
            {
                string choice2 = "";
                while (choice2 != "N")
                {
                    Console.WriteLine("Please enter the Data of the course you want to add");
                    listOfCourses.Add(GetCourseDetails());
                    Console.Write("Press any key to add another course, or N to continue");
                    choice2 = Console.ReadLine();
                }

            }



            for (int i = 0; i < listOfCourses.Count; i++)
            {
                Console.WriteLine(listOfCourses[i]);
            }

            return (listOfCourses);

        }
        public Course GetCourseDetails()
        {
            Course course = new Course()
            {
                Title = AskDetail("Give me the course's title"),
                Stream = AskDetail("Give me the course's stream"),
                Type = AskDetail("Give me the type of the course"),
                StartDate = ConvertToDateTime(AskDetail("Give me the starting date of the course")),
                EndDate = ConvertToDateTime(AskDetail("Give me the ending date of the course"))
            };

            return (course);
        }
        public List<Course> GetSyntheticCourses()
        {
            Course course1 = new Course();
            Course course2 = new Course
            {
                Title = "CB Generic2",
                Stream = "Generic Programming Language2",
                Type = "Generic Type",
                StartDate = DateTime.Parse("19/ 10 / 2020"),
                EndDate = DateTime.Parse("15/ 01 / 2021")
            };
            List<Course> syntheticCourses = new List<Course> { course1, course2 };

            return (syntheticCourses);

        }
        public void PrintCoursesList(List<Course> courses)
        {
            foreach (var item in courses)
            {
                Console.WriteLine(item);
            }
        }

    }
}
