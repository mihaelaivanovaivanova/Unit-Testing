using StudentsAndClasses.Contracts;
using System;

namespace StudentsAndClasses.Models
{
    public class Students:IStudent
    {
        private string name;
        private const int minStudentID = 1000;

        public Students(string name)
        {
            this.Name = name;
            this.StudentID = minStudentID;
            this.School = null;
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

        public int StudentID { get; internal set; }
        public School School { get; private set; }

        public void JoinCourse(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("This course does not exist!");
            }
            course.AddStudent(this);
        }

        public void LeaveCourse(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("This course does not eist!");
            }
            if (course.StudentsInCourse.IndexOf(this) < 0)
            {
                throw new ArgumentException("This student is not attempting the course, therefore it san not leave it!");
            }
            course.RemoveStudent(this); 
        }
    }
}
