using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyIndividualProject.Models;


namespace MyIndividualProject.BusinessLogic
{
    class StudentUtils : CommandPromptUtils
    {
        public List<Student> GetListOfStudents(List<Course> courses)
        {
            Console.Write("Now, let's add our Students!\nWould you like to : \n");
            string option1 = "Get Synthetic Students";
            string option2 = "Add your own students";
            string choice = SelectFromListOfStrings(new List<string>() { option1, option2, });
            List<Student> listOfStudents = new List<Student>();
            if (choice == option1)
            {
                listOfStudents = GetSyntheticStudents(courses);
            }
            else
            {
                string choice2 = "";
                while (choice2 != "N")
                {
                    Console.WriteLine("Please enter the Data of the student you want to add");
                    listOfStudents.Add(GetStudentDetails(courses));
                    Console.Write("Press any key to add another student,\n or type N and press Enter to continue");
                    choice2 = Console.ReadLine();
                }

            }
            return (listOfStudents);
        }
        public List<Student> GetSyntheticStudents(List<Course> courses)
        {
            Student student1 = new Student();
            Student student2 = new Student
            {
                FirstName = "Generic First Name 2",
                LastName = "Generic Last Name 2",
                TuitionFees = 400.00F,
                DateOfBirth = DateTime.Parse("19/ 10 / 1988"),
                CoursesOfStudent = courses
            };

            List<Student> syntheticStudents = new List<Student> { student1, student2 };

            return (syntheticStudents);

        }

        public Student GetStudentDetails(List<Course> courses)
        {
            Student student = new Student();
            List<Course> studentCourses = new List<Course>();
            student.FirstName = AskDetail("Give me your first name");
            student.LastName = AskDetail("Give me the last name");
            student.DateOfBirth = ConvertToDateTime($"{AskDetail("Give me your date of birth")}");
            student.TuitionFees = ConvertToDouble($"{AskDetail("Give me your tuition fees")}");
            Console.WriteLine("In which course is the user enrolled to?:");
            studentCourses.Add(SelectFromListOfCourses(courses));
            string choice;
            Console.Write("Is the student enrolled to another course?\n" +
                "Press Y to add another course and choose from the list or\n" +
                "press any key and Enter to continue");
            choice = Console.ReadLine();
            while (choice == "Y")
            {
                studentCourses.Add(SelectFromListOfCourses(courses));
                Console.Write("Is the student enrolled to another course?\n" +
                "Press Y to add another course and choose from the list or\n" +
                "press any key and Enter to continue");
                choice = Console.ReadLine();

            }

            student.CoursesOfStudent = studentCourses;


            return (student);

        }

    }
}
