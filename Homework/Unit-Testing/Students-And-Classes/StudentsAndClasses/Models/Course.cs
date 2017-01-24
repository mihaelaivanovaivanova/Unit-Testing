using StudentsAndClasses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndClasses.Models
{
    public class Course:ICourse
    {
        private IList<IStudent> studentsInCourse;
        private const int maxStudentsInCourse = 30;
        private School school;
        public Course(string name)
        {
            this.Name = name;
            this.studentsInCourse = new List<IStudent>();
            this.StudentsInCourse = studentsInCourse;
            School = null;
        }

        public string Name { get; set; }
        public IList<IStudent> StudentsInCourse { get; set; }
        public School School { get; internal set; }
        public void AddStudent(IStudent student)
        {
            if (this.StudentsInCourse.Count == Course.maxStudentsInCourse)
            {
                throw new ArgumentOutOfRangeException("This course is full! No new students can be added!");
            }
            this.StudentsInCourse.Add(student);
        }

        public void RemoveStudent(IStudent student)
        {
            if (this.StudentsInCourse.All(stud => stud != student))
            {
                throw new ArgumentException("There is no such student in the course!");
            }
            this.StudentsInCourse.Remove(student);
        }
    }
}
