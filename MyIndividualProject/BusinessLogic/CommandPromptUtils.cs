using MyIndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyIndividualProject.BusinessLogic
{
    class CommandPromptUtils
    {
        

        public object GetTrainerDetails(List<string> subjects = null)
        {
            List<Trainer> trainers = new List<Trainer>();
            for (int i = 0; i < 3; i++)
            {
                if (subjects == null) subjects = new List<string>() { "C#", "Java", "Python", "Javascript", "PHP" };
                Trainer trainer = new Trainer();
                trainer.FirstName = AskDetail("Give me your first name");
                trainer.LastName = AskDetail("Give me your last name");
                trainer.Subject = AskDetail("Give me the subject that you teach", subjects);
                trainers.Add(trainer);
                

            }

            return (trainers[2]);
        }

        public Course GetCourseDetails()
        {
            Course course = new Course();
            course.Title = AskDetail("Give me the course's title");
            course.Stream = AskDetail("Give me the course's stream");
            course.Type = AskDetail("Give me the type of the course");
            course.StartDate = ConvertToDateTime(AskDetail("Give me the starting date of the course")); // convert to DateTime probably
            course.EndDate = ConvertToDateTime(AskDetail("Give me the ending date of the course")); // convert to DateTime probably

            return (course);

        }
        public Student GetStudentDetails()
        {
            Student student = new Student();
            student.FirstName = AskDetail("Give me your first name");
            student.LastName = AskDetail("Give me the course's stream");
            student.DateOfBirth = ConvertToDateTime(AskDetail("Give me the type of the course")); //convert to DateTime probably
            student.TuitionFees = Convert.ToDouble(AskDetail("Give me the starting date of the course")); 
            

            return (student);

        }
        public Assignment GetAssignmentDetails()
        {
            Assignment assignment = new Assignment();
            assignment.Title = AskDetail("Give me the assignments title");
            assignment.Description = AskDetail("Give me the assignments description");
            assignment.SubmissionDateTime = ConvertToDateTime(AskDetail("Submit until")); //convert to DateTime probably
            assignment.OralMark = AskDetail("Give me the oral mark of the assignment"); 
            assignment.TotalMark = AskDetail("Give me the total mark of the assignment");
            return (assignment);

        }
        //public string AskListedDetail(string message, List<string> listedDetails)
        //{
        //    string result;
        //    Console.Write(message + ": ");
        //    int i = 0;
        //    while (i < listedDetails.Count)
        //    {
        //        Console.WriteLine(listedDetails[i]);
        //    }
        //    Console.WriteLine("This are the subjects:");
        //    Console.WriteLine($"Press 1 for {listedDetails[1]}, press 2 for {listedDetails[2]}, press 3 for {listedDetails[3]}, press 4 for {listedDetails[4]} and press 5 for {listedDetails[5]}");
        //    int x = Convert.ToInt32(Console.ReadLine());

        //    result = listedDetails[x];
        //    return (result);


        //}

        private string AskDetail(string message, List<string> subjects = null)
        {
            string result = "";
            Console.Write(message + ": ");
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

        private string SelectFromListOfStrings (List<string> elements)
        {
            string result;
            int counter = 1;
            Console.WriteLine();
            foreach (var item in elements)
            {
                Console.WriteLine($"{counter++}. {item}");
            }
            int choice = Convert.ToInt32(Console.ReadLine());
            while (choice > elements.Count || choice <= 0)
            {
                Console.Write("Please choose one of the given choices: ");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            result = elements.ElementAt(choice - 1); // elements[choice - 1];
            return (result);
        }

        public void PrintTAList(List<object> listObjects)
        {
            foreach (var item in listObjects)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintCoursesList(List<Course> courses)
        {
            foreach (var item in courses)
            {
                Console.WriteLine(item);
            }
        }

        public DateTime ConvertToDateTime (string dateTime)
        {

            bool isItADate;
            DateTime date;
            isItADate = DateTime.TryParse(dateTime, out date);


            while (dateTime == null || isItADate == false)
            {
                Console.Write("Please enter a valid date (DD/MM/YYYY): ");
                dateTime = Console.ReadLine();
                isItADate = DateTime.TryParse(dateTime, out date);
            }
            date = DateTime.Parse(dateTime);
            return (date);
        }
    }
}
