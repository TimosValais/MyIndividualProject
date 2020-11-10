using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyIndividualProject.Models;

namespace MyIndividualProject.BusinessLogic
{
    class OrderOfOperations : CommandPromptUtils
    {
        private string _schoolname = "Generic Private School";

        public string SchoolName
        {
            get { return _schoolname; }
            set { _schoolname = value; }
        }


        private List<Course> _courses;

        public List<Course> SchoolCources
        {
            get { return _courses; }
            set { _courses = value; }
        }

        private List<Student> _students;

        public List<Student> SchoolStudents
        {
            get { return _students; }
            set { _students = value; }
        }

        private List<Trainer> _trainers;

        public List<Trainer> SchoolTrainers
        {
            get { return _trainers; }
            set { _trainers = value; }
        }

        private List<Assignment> _assignments;

        public List<Assignment> SchoolAssignments
        {
            get { return _assignments; }
            set { _assignments = value; }
        }

        // probably not gonna use all these properties now, but if in the future
        // I want to create objects - school they might be usefull.







        public OrderOfOperations()
        {
            CourseUtils courseUtils = new CourseUtils();
            TrainerUtils trainerUtils = new TrainerUtils();
            StudentUtils studentUtils = new StudentUtils();
            AssignmentUtils assignmentUtils = new AssignmentUtils();
            WelcomeScreen();
            List<Course> thisSchoolCourses = courseUtils.GetListOfCourses();
            List<Trainer> thisSchoolTrainers = trainerUtils.GetListOfTrainers(thisSchoolCourses);
            List<Student> thisSchoolStudents = studentUtils.GetListOfStudents(thisSchoolCourses);
            List<Assignment> thisSchoolAssignments = assignmentUtils.GetListOfAssignments(thisSchoolCourses);

            Console.WriteLine("Would you like to see the list of: ");
            WhichListToSee(thisSchoolCourses, thisSchoolTrainers, thisSchoolStudents,
                thisSchoolAssignments);

            Console.WriteLine("Now Please Select a student to see all of their assignments : ");
            Student student = SelectFromListOfStudents(thisSchoolStudents);
            StudentAssignment studentAssignment = new StudentAssignment(student, thisSchoolAssignments);
            //Console.WriteLine("Now Please Enter A Date to see which students owe an assignment that calendar week: ");
            //DateTime checkDate = ConvertToDateTime($"{AskDetail("Now Please Enter A Date to see which students owe an assignment that calendar week: ")}");
            List<Course> coursesDate = studentAssignment.GetCoursesFromAnAssignmentsDate(thisSchoolAssignments);
            studentAssignment.PrintStudentsThatHaveAssignments(coursesDate, thisSchoolStudents);









        }
        public void WelcomeScreen()
        {
            Console.Write("Welcome to the shcool data app!\n Please" +
            " give me the name of your shcool (press Enter to use syntetic data): ");
            string schoolName = Console.ReadLine();
            if (schoolName != null)
                this.SchoolName = schoolName;
            else
            {
                this.SchoolName = "Generic Private School";
            }
        }

        public void WhichListToSee (List<Course> thisSchoolCourses,
        List<Trainer> thisSchoolTrainers, List<Student> thisSchoolStudents,
        List<Assignment> thisSchoolAssignments)
        {
            CourseUtils courseUtils = new CourseUtils();
            TrainerUtils trainerUtils = new TrainerUtils();
            StudentUtils studentUtils = new StudentUtils();
            AssignmentUtils assignmentUtils = new AssignmentUtils();
            CourseStudents courseStudents = new CourseStudents();
            CourseAssignments courseAssignments = new CourseAssignments();
            CourseTrainers courseTrainers = new CourseTrainers();
            Student student3 = new Student();
            //StudentAssignment studentAssignment = new StudentAssignment();

            string option1 = "All The Courses";
            string option2 = "All The Trainers";
            string option3 = "All The Students";
            string option4 = "All The Assignments";
            string option5 = "All The Students Per Course";
            string option6 = "All the Trainers Per Course";
            string option7 = "All the Assignments Per Course";
            string option;
            List<Course> listOfCourses = new List<Course>();





            string answer = "";

            while (answer != "N")
            {
                option = SelectFromListOfStrings(new List<string>() { option1, option2, option3, option4,
                      option5, option6, option7});

                switch (option)
                {
                    case ("All The Courses"):
                        courseUtils.PrintCoursesList(thisSchoolCourses);
                        break;
                    case ("All The Trainers"):
                        trainerUtils.PrintTrainerList(thisSchoolTrainers);
                        break;
                    case ("All The Students"):
                        studentUtils.PrintStudentsList(thisSchoolStudents);
                        break;
                    case ("All The Assignments"):
                        assignmentUtils.PrintAssignmentList(thisSchoolAssignments);
                        break;
                    case ("All The Students Per Course"):
                        courseStudents.PrintAllStudentPerOneCourse(thisSchoolCourses, thisSchoolStudents);
                        break;
                    case ("All the Trainers Per Course"):
                        courseTrainers.PrintAllTrainersPerOneCourse(thisSchoolCourses, thisSchoolTrainers);
                        break;
                    case ("All the Assignments Per Course"):
                        courseAssignments.PrintAllAssignmentsPerOneCourse(thisSchoolCourses, thisSchoolAssignments);
                        break;

                }

                Console.Write("Would you like to see another list? Press any key to see the lists or N to continue: ");
                answer = Console.ReadLine();
            }

            

        }




    }
}
