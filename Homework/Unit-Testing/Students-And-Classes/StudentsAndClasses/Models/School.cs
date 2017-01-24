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
        private readonly int maxCapacity = minStudentID - maxStudentID;

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

            if (this.StudentsInSchool.Count == maxCapacity)
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
                throw new ArgumentException("The student does not have such student, therefore it can not be removed!");
            }
            this.StudentsInSchool.Remove(student);
        }

    }
}
