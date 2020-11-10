using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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
            string option2 = "Choose from our collection of programming courses";
            string option3 = "Add your own courses";
            string option;
            List<Course> listOfCourses = new List<Course>();


            Console.WriteLine("Time to add the courses of the school!\n" +
                $"Would you like to : ");
            option = SelectFromListOfStrings(new List<string>() { option1, option2, option3 });

            switch (option)
            {
                case ("Use synthetic courses"):
                    listOfCourses = GetSyntheticCourses();
                    break;
                case ("Choose from our collection of programming courses"):
                    string continuing = "";
                    while (continuing != "N")
                    {
                        Course newCourse = ChoosePremadeCourse();
                        if (CheckForDuplicateCourses(listOfCourses, newCourse) == false)
                        {
                            listOfCourses.Add(newCourse);
                        }

                        Console.Write("Press any key to choose another course, or N to move on: ");
                        continuing = Console.ReadLine();
                    }


                    break;
                case ("Add your own courses"):
                    string choice = "";
                    while (choice != "N")
                    {
                        
                        Console.WriteLine("Please enter the Data of the course you want to add");
                        Course newCourse =  GetCourseDetails();
                        if (CheckForDuplicateCourses(listOfCourses, newCourse) == false)
                        {
                            listOfCourses.Add(newCourse);
                        }
                       
                        Console.Write("Press any key to add another course, or N to move on: ");
                        choice = Console.ReadLine();
                    }
                    break;
            }


            return (listOfCourses);



        }

        public Course ChoosePremadeCourse()
        {

            Course course = new Course()
            {
                Title = AskDetail("Choose one of these titles",
                               new List<string> { "CB 12", "CB 11" }),
                Stream = AskDetail("Choose one of these streams",
                    new List<string> { "C#", "Java", "Javascript", "C++", "Python" }),
                Type = AskDetail("Choose one of these types",
                               new List<string> { "Full Time", "Part Time" }),
                StartDate = ConvertToDateTime
                ($"{AskDetail("Choose the starting date",new List<string> { "05/10/2020", "19/10/2020", "05/02/2021", "19/02/2021" })}")
            };

            if (course.Type == "Full Time")
            {
                course.EndDate = course.StartDate.AddDays(90);
            }
            else
            {
                course.EndDate = course.StartDate.AddDays(180);
            }
            

            return (course);
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
