using StudentsAndClasses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndClasses.Models
{
   public class School
    {
        private const int minStudentID = 1000;
        private const int maxStudentID = 9999;

        private int uniqueNumberCounter;
        public School()
        {
            this.StudentsInSchool = new List<IStudent>();
            this.CoursesInSchool = new List<ICourse>();
            uniqueNumberCounter = minStudentID;
        }

        public ICollection<IStudent> StudentsInSchool { get; private set; }
        public ICollection<ICourse> CoursesInSchool { get; private set; }

        public void AddStudents(Students student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student can not be null!");
            }

            if (this.StudentsInSchool.Count == 8999)
            {
                throw new ArgumentException("The school exceeded its limit. No more students can be added!");
            }

            foreach (var std in this.StudentsInSchool)
            {
                if (std.StudentID == student.StudentID &&
                    std.School != null &&
                    student.School != null)
                {
                    throw new ArgumentException("Student with the same number already exists!");
                }
            }

            student.StudentID = uniqueNumberCounter++;
            this.StudentsInSchool.Add(student);
            student.School = this;
        }

        public void RemoveStudents(Students student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student can not be null!");
            }

            if (!this.StudentsInSchool.Contains(student))
            {
                throw new ArgumentException("The school does not have such student, therefore it can not be removed!");
            }
            this.StudentsInSchool.Remove(student);
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course can not be null!");
            }

            this.CoursesInSchool.Add(course);
            course.School = this;
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course can not be null!");
            }

            if (!this.CoursesInSchool.Contains(course))
            {
                throw new ArgumentException("The school does not have such course, therefore it can not be removed!");
            }
            this.CoursesInSchool.Remove(course);
        }

    }
}
