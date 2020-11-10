using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyIndividualProject.Models;

namespace MyIndividualProject.BusinessLogic
{
    class CourseTrainers : CommandPromptUtils
    {
        private Course _course;

        public Course Course
        {
            get { return _course; }
            set { _course = value; }
        }

        private List<string> _trainersincourse;

        public List<string> TrainersInCourse
        {
            get { return _trainersincourse; }
            set { _trainersincourse = value; }
        }




        //public CourseStudents(Course course, List<Student> students)
        //{
        //    bool hasTheCourse = true;
        //    List<string> studentsInCourse = new List<string>();

        //    foreach (var item in students)
        //    {
        //        for (int i = 0; i < item.CoursesOfStudent.Count; i++)
        //        {
        //            if (hasTheCourse == IsEqual(course, item.CoursesOfStudent[i]))
        //            {
        //                Console.WriteLine($"In {course} there are these students {item.FirstName + item.LastName}");
        //            }

        //        }

        //    }



        //    //IsEqual(courses[k], students[i].CoursesOfStudent[j]);
        //    //foreach (var item in students)
        //    //{

        //    //    if (IsEqual(item.CoursesOfStudent, courses[i]) == true)
        //    //        Console.WriteLine(item);
        //    //}

        //    //for (int i = 0; i < this._students.Count; i++)
        //    //{
        //    //    if (this._students.Course[i] = course) ;
        //    //    Console.WriteLine(this._students.FirstName[i] + this._students.LastName[i]);
        //    //}
        //}

        public List<string> TrainersPerCourse(Course course, List<Trainer> trainers)
        {
            bool hasTheCourse = true;
            List<string> trainersInCourse = new List<string>();

            foreach (var item in trainers)
            {
                for (int i = 0; i < item.TrainerCourses.Count; i++)
                {
                    if (hasTheCourse == IsEqual(course, item.TrainerCourses[i]))
                    {
                        trainersInCourse.Add(item.FirstName + " " + item.LastName);
                    }

                }

            }
            this._course = course;
            this._trainersincourse = trainersInCourse;
            return (trainersInCourse);
        }

        public void PrintAllTrainersPerAllCourses(List<Course> courses, List<Trainer> trainers)
        {
            foreach (var item in courses)
            {

                Console.WriteLine($"This course:\n {item} \nHas these trainers :\n");
                List<string> listOfTrainers = TrainersPerCourse(item, trainers);
                for (int i = 0; i < listOfTrainers.Count; i++)
                {
                    Console.WriteLine($"{listOfTrainers[i]}\n");

                }
            }
        }

        public void PrintAllTrainersPerOneCourse(List<Course> courses, List<Trainer> trainers)
        {
            Console.WriteLine("Which Course's Trainers would you like to print? :");
            Course course = SelectFromListOfCourses(courses);
            List<string> trainersPerCourse = TrainersPerCourse(course, trainers);
            Console.WriteLine($"{course.Title} {course.Stream} {course.Type} has these students\n");
            for (int i = 0; i < trainersPerCourse.Count; i++)
            {
                Console.WriteLine($"{trainersPerCourse[i]}\n");

            }
        }
    }
}
