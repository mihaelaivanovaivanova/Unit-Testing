using StudentsAndClasses.Contracts;
using System;

namespace StudentsAndClasses.Models
{
    public class Students:IStudent
    {
        private string name;
        private static int counter = 1000;
        private int studentID;

        public Students(string name)
        {
            this.Name = name;
            this.StudentID = studentID;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be null!");
                }
                this.name = value;
            }
        }

        public int StudentID
        {
            get
            {
                return this.studentID;
            }
            private set
            {
                this.studentID = counter;
                counter++;
            }
        }

        public void JoinCourse(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("This course does not eist!");
            }
            course.AddStudent(this);
        }

        public void LeaveCourse(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("This course does not eist!");
            }
            course.RemoveStudent(this); 
        }
    }
}
