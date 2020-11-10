using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyIndividualProject.Models;

namespace MyIndividualProject.BusinessLogic
{
    class AssignmentUtils : CommandPromptUtils
    {
        public List<Assignment> GetListOfAssignments(List<Course> courses)
        {
            Console.Write("Now, let's add the Assignments!\nWould you like to : \n");
            string option1 = "Get Synthetic Assignments";
            string option2 = "Add your own Assignments";
            string choice = SelectFromListOfStrings(new List<string>() { option1, option2, });
            List<Assignment> listOfAssignments = new List<Assignment>();
            if (choice == option1)
            {
                listOfAssignments = GetSyntheticAssignments(courses);
            }
            else
            {
                string choice2 = "";
                while (choice2 != "N")
                {
                    Console.WriteLine("Please enter the Data of the Assignment you want to add");
                    listOfAssignments.Add(GetAssignmentDetails(courses));
                    Console.Write("Press any key to add another assignment,\n or type N and press Enter to continue: ");
                    choice2 = Console.ReadLine();
                }

            }
            return (listOfAssignments);
        }


        public Assignment GetAssignmentDetails(List<Course> courses)
        {
            Assignment assignment = new Assignment
            {
                Title = AskDetail("Give me the assignments title"),
                Description = AskDetail("Give me the assignments description"),
                SubmissionDateTime = ConvertToDateTime($"{AskDetail("Submit until")}"), //convert to DateTime probably
                OralMark = ConvertToFloat($"{AskDetail("Give me the oral mark of the assignment")}"),
                TotalMark = ConvertToFloat($"{AskDetail("Give me the total mark of the assignment")}")
            };
            Console.WriteLine("This is an assignment for which course?:");
            assignment.CoursesOfAssignment.Add(SelectFromListOfCourses(courses));
            string choice;
            Console.Write("Does this assignment belong to another course?\n" +
                "Press Y to add another course from the list or\n" +
                "press any key and Enter to continue: ");
            choice = Console.ReadLine();
            while (choice == "Y")
            {
                Course newCourse = SelectFromListOfCourses(courses);
                if (CheckForDuplicateCourses(assignment.CoursesOfAssignment, newCourse) == false)
                {
                    assignment.CoursesOfAssignment.Add(newCourse);
                }
                //studentCourses.Add(SelectFromListOfCourses(courses));
                Console.Write("Does this assignment belong to another course?\n" +
                "Press Y to add another course from the list or\n" +
                "press any key and Enter to continue: ");
                choice = Console.ReadLine();

            }
            return (assignment);

        }


        public List<Assignment> GetSyntheticAssignments(List<Course> courses)
        {
            Assignment assignment1 = new Assignment();
            Assignment assignment2 = new Assignment
            {
                Title = "Generic Assingment",
                Description = "This is a generic assignment",
                SubmissionDateTime = DateTime.Parse("20/01/2020 23:59:59"),
                OralMark = 20.00f,
                TotalMark = 100.00f
            };
            Random randomI = new Random();

            assignment1.CoursesOfAssignment.Add(courses[randomI.Next(0, courses.Count)]);
            assignment2.CoursesOfAssignment.Add(courses[randomI.Next(0, courses.Count)]);

            List<Assignment> syntheticAssignments = new List<Assignment> { assignment1, assignment2 };

            return (syntheticAssignments);

        }
    }
}
