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

        public List<Course> CheckForDuplicateCourses (List<Course> listOfCourses)
        {
            Console.WriteLine("Checking For Duplicates");
            //for (int i = 0; i < listOfCourses.Count; i++)
            //{
            //    for (int j = 0; j < listOfCourses.Count && j != i; j++)
            //    {
                    
            //        if (listOfCourses[i] == listOfCourses[j])
            //        {
            //            listOfCourses.Remove(listOfCourses[j]);
            //        }
            //    }
            //}

            int i = 0;
            while (i < listOfCourses.Count)
            {
                for (int j = 0; (j < listOfCourses.Count && j != i); j++)
                {

                    if (listOfCourses[i].Title == listOfCourses[j].Title
                        && listOfCourses[i].Stream == listOfCourses[j].Stream
                        && listOfCourses[i].Type == listOfCourses[j].Type
                        && listOfCourses[i].StartDate == listOfCourses[j].StartDate
                        && listOfCourses[i].EndDate == listOfCourses[j].EndDate)
                    {
                        listOfCourses.Remove(listOfCourses[j]);
                        
                    }
                }
                i++;
            }
                
            

            //if (listOfCourses[0] == listOfCourses[1])
            //    Console.WriteLine("true");
            //else
            //    Console.WriteLine("false");
            return (listOfCourses);
            
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





    }
}
