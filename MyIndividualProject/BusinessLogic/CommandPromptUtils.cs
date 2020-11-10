using MyIndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyIndividualProject.BusinessLogic
{
    class CommandPromptUtils
    {  

        private protected string AskDetail(string message, List<string> subjects = null)
        {
            string result;
            Console.Write(message + ": \n");
            if (subjects != null)
            {
                // ask for the subject the trainer teaches
                result = SelectFromListOfStrings(subjects);

            }
            else
            {
                result = Console.ReadLine();
            }

            return (result);
        }

        private protected string SelectFromListOfStrings (List<string> elements)
        {
            string result;
            int counter = 1;
            foreach (var item in elements)
            {
                Console.WriteLine($"{counter++}. {item}");
            }
            int choice = ConvertToInt(Console.ReadLine());
            while (choice > elements.Count || choice <= 0)
            {
                Console.Write("Please choose one of the given choices: ");
                choice = ConvertToInt(Console.ReadLine());
            }
            result = elements.ElementAt(choice - 1); // elements[choice - 1];
            return (result);
        }

        public Course SelectFromListOfCourses (List<Course> courses)
        {
            Course result;
            int counter = 1;
            foreach (var item in courses)
            {
                Console.WriteLine($"{counter++}. {item}");
            }
            int choice = ConvertToInt(Console.ReadLine());
            while (choice > courses.Count || choice <= 0)
            {
                Console.Write("Please choose one of the given choices: ");
                choice = ConvertToInt(Console.ReadLine());
            }
            result = courses.ElementAt(choice - 1); // elements[choice - 1];
            return (result);

        }

        public bool CheckForDuplicateCourses (List<Course> listOfCourses, Course courseToCheck)
        {
            bool isItADuplicate = false;
            int i = 0;
            Console.WriteLine("Checking For Duplicates...");
            while (i < listOfCourses.Count)
            {
                if(IsEqual(courseToCheck, listOfCourses[i]) == true)
                {
                    Console.WriteLine("You have already added this course!");
                    isItADuplicate = true;
                }
                i++;
               
            }
            return (isItADuplicate);
        }

        public bool CheckForDuplicateStrings (List<string> listOfStrings, string string1)
        {
            bool isItADuplicate = false;
            int i = 0;
            while (i < listOfStrings.Count)
            {
                if (StringIsEqual(string1, listOfStrings[i]) == true)
                {
                    isItADuplicate = true;
                }
                i++;

            }
            return (isItADuplicate);
        }

        public DateTime ConvertToDateTime (string dateTime)
        {

            bool isItADate;
            isItADate = DateTime.TryParse(dateTime, out DateTime date);

            while (dateTime == null || isItADate == false)
            {
                Console.Write("Please enter a valid date (DD/MM/YYYY): ");
                dateTime = Console.ReadLine();
                isItADate = DateTime.TryParse(dateTime, out date);
            }
            return (date);
        }

        public double ConvertToDouble(string doubleValue)
        {

            bool isItADate;
            isItADate = double.TryParse(doubleValue, out double numericValue);

            while (doubleValue == null || isItADate == false)
            {
                Console.Write("Please choose one of the given choices: ");
                doubleValue = Console.ReadLine();
                isItADate = double.TryParse(doubleValue, out numericValue);
            }
            return (numericValue);
        }

        public int ConvertToInt(string intValue)
        {

            bool isItADate;
            isItADate = int.TryParse(intValue, out int numericValue);

            while (intValue == null || isItADate == false)
            {
                Console.Write("Please choose one of the given choices: ");
                intValue = Console.ReadLine();
                isItADate = int.TryParse(intValue, out numericValue);
            }
            return (numericValue);
        }

        public float ConvertToFloat (string floatValue)
        {

            bool isItADate;
            isItADate = float.TryParse(floatValue, out float numericValue);

            while (floatValue == null || isItADate == false)
            {
                Console.Write("Please enter a valid date (DD/MM/YYYY): ");
                floatValue = Console.ReadLine();
                isItADate = float.TryParse(floatValue, out numericValue);
            }
            return (numericValue);
        }

        public bool IsEqual(Course course1, Course course2)
        {
            if (course1.Title == course2.Title &&
                course1.Stream == course2.Stream &&
                course1.Type == course2.Type &&
                course1.StartDate == course2.StartDate &&
                course1.EndDate == course2.EndDate)
            {
                return (true);
            }
            else
            {
                return (false);
            }

        }

        public bool StringIsEqual (string string1, string string2)
        {
            if (string1 == string2)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }





    }
}
