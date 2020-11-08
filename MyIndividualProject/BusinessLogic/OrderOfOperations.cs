using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIndividualProject.BusinessLogic
{
    class OrderOfOperations
    {
        private string _schoolname = "Generic Private School";

        public string SchoolName
        {
            get { return _schoolname; }
            set { _schoolname = value; }
        }
        public OrderOfOperations()
        {

        }
        public void WelcomeScreen()
        {
            Console.Write("Welcome to the shcool data app!\n Please" +
            " give me the name of your shcool (press Enter to use syntetic data): ");
            string schoolName = Console.ReadLine();
            if (schoolName != null)
                this.SchoolName = schoolName;
        }

    }
}
