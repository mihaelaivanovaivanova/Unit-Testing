using StudentsAndClasses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndClasses.Models
{
    class Course:ICourse
    {
        private IList<IStudent> studentsInCourse;
        private const int maxStudentsInCourse = 30;
        public Course(string name)
        {
            this.Name = name;
            this.studentsInCourse = new List<IStudent>();
            this.StudentsInCourse = studentsInCourse;
        }

        public string Name { get; set; }
        public IList<IStudent> StudentsInCourse { get; set; }

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
