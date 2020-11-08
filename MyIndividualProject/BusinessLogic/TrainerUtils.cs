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
        public Trainer GetTrainerDetails(List<string> subjects = null)
        {
            List<Trainer> trainers = new List<Trainer>();
            for (int i = 0; i < 3; i++)
            {
                if (subjects == null) subjects = new List<string>() { "C#", "Java", "Python", "Javascript", "PHP" };
                Trainer trainer = new Trainer
                {
                    FirstName = AskDetail("Give me your first name"),
                    LastName = AskDetail("Give me your last name"),
                    Subject = AskDetail("Give me the subject that you teach", subjects)
                };
                trainers.Add(trainer);


            }

            return (trainers[2]);
        }
    }
}
