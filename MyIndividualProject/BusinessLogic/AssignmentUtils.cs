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
        public Assignment GetAssignmentDetails()
        {
            Assignment assignment = new Assignment
            {
                Title = AskDetail("Give me the assignments title"),
                Description = AskDetail("Give me the assignments description"),
                SubmissionDateTime = ConvertToDateTime(AskDetail("Submit until")), //convert to DateTime probably
                OralMark = ConvertToFloat(AskDetail("Give me the oral mark of the assignment")),
                TotalMark = ConvertToFloat(AskDetail("Give me the total mark of the assignment"))
            };
            return (assignment);

        }
    }
}
