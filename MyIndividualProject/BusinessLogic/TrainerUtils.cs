using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyIndividualProject.Models;

namespace MyIndividualProject.BusinessLogic
{
    class TrainerUtils : CommandPromptUtils
    {
        //public Trainer GetTrainerDetails(List<string> subjects = null)
        //{
        //    List<Trainer> trainers = new List<Trainer>();
        //    for (int i = 0; i < 3; i++)
        //    {
        //        if (subjects == null) subjects = new List<string>() { "C#", "Java", "Python", "Javascript", "PHP" };
        //        Trainer trainer = new Trainer
        //        {
        //            FirstName = AskDetail("Give me your first name"),
        //            LastName = AskDetail("Give me your last name"),
        //            Subject = AskDetail("Give me the subject that you teach", subjects)
        //        };
        //        trainers.Add(trainer);


        //    }

        //    return (trainers[2]);
        //}

        public List<Trainer> GetListOfTrainers(List<Course> courses)
        {
            Console.Write("Now, let's add our Trainers!\nWould you like to : \n");
            string option1 = "Get Synthetic Trainers";
            string option2 = "Add your own Trainers";
            string choice = SelectFromListOfStrings(new List<string>() { option1, option2, });
            List<Trainer> listOfTrainers = new List<Trainer>();
            if (choice == option1)
            {
                listOfTrainers = GetSyntheticTrainers(courses);
            }
            else
            {
                string choice2 = "";
                while (choice2 != "N")
                {
                    Console.WriteLine("Please enter the Data of the trainer you want to add");
                    listOfTrainers.Add(GetTrainerDetails(courses));
                    Console.Write("Press any key to add another trainer,\n or type N and press Enter to continue: ");
                    choice2 = Console.ReadLine();
                }

            }
            return (listOfTrainers);
        }
        public List<Trainer> GetSyntheticTrainers(List<Course> courses)
        {
            Trainer trainer1 = new Trainer();
            Trainer trainer2 = new Trainer
            {
                FirstName = "Mr First Name 2",
                LastName = "Generic Last Name 2",
            };
            Random randomI = new Random();

            trainer1.TrainerCourses.Add(courses[randomI.Next(0, courses.Count)]);
            trainer2.TrainerCourses.Add(courses[randomI.Next(0, courses.Count)]);
            foreach (var item in trainer2.TrainerCourses)
            {
                trainer2.Subjects.Add($"{item.Title} {item.Stream} {item.Type}");
            }
            foreach (var item in trainer1.TrainerCourses)
            {
                trainer1.Subjects.Add($"{item.Title} {item.Stream} {item.Type}");
            }

            List<Trainer> syntheticTrainers = new List<Trainer> { trainer1, trainer2 };

            return (syntheticTrainers);

        }
        public Trainer GetTrainerDetails(List<Course> courses)
        {
            Trainer trainer = new Trainer();
            List<Course> trainerCourses = new List<Course>();
            trainer.FirstName = AskDetail("Give me the trainer's First Name");
            trainer.LastName = AskDetail("Give me the trainer's Last Name");
            Console.WriteLine("What course does the trainer teach? :");
            trainerCourses.Add(SelectFromListOfCourses(courses));
            string choice;
            Console.Write("Does the trainer teach another course?\n" +
                "Press Y to add another course from the list or\n" +
                "press any key and Enter to continue");
            choice = Console.ReadLine();
            while (choice == "Y")
            {
                Course newCourse = SelectFromListOfCourses(courses);
                if (CheckForDuplicateCourses(trainerCourses, newCourse) == false)
                {
                    trainerCourses.Add(newCourse);
                }
                Console.Write("Does the trainer teach another course?\n" +
                "Press Y to add another course from the list or\n" +
                "press any key and Enter to continue");
                choice = Console.ReadLine();

            }
            foreach (var item in trainerCourses)
            {
                trainer.Subjects.Add($"{item.Title} {item.Stream} {item.Type}");

            }

            trainer.TrainerCourses = trainerCourses;


            return (trainer);

        }

        public void PrintTrainerList(List<Trainer> trainers)
        {
            foreach (var item in trainers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
