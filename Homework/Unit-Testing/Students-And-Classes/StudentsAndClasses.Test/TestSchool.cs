using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;
using StudentsAndClasses.Models;

namespace StudentsAndClasses.Test
{
    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        public void School_WhenInstanced_HasAPropertyStudentsInSchoolWithZeroLength()
        {
            //Arrange
            School school = new School();
            //Act and Assert
            Assert.AreEqual(0, school.StudentsInSchool.Count);
        }

        [TestMethod]
        public void School_WhenInstanced_HasAPropertyCoursesInSchoolWithZeroLength()
        {
            //Arrange
            School school = new School();
            //Act and Assert
            Assert.AreEqual(0, school.CoursesInSchool.Count);
        }

        [TestMethod]
        public void School_WhenAddingStudent_ShouldThrowExceptionIfStudentISNull()
        {
            //Arrange
            School school = new School();
            //Act and Assert
            ThrowsAssert.Throws<ArgumentNullException>(() => school.AddStudents(null));
        }

        [TestMethod]
        public void School_WhenAddingStudent_ShouldShouldAddStudentsCorrectly()
        {
            //Arange
            var studentVesko = new Students("Vesko");
            var studentPesho = new Students("Pesho");
            var school = new School();
            //Act
            school.AddStudents(studentPesho);
            school.AddStudents(studentVesko);
            //Assert
            Assert.AreEqual(2, school.StudentsInSchool.Count);
        }

        [TestMethod]
        public void School_WhenAddingStudent_ShouldThrowExceptionIfSchoolMaxCappacityISReached()
        {
            //Arrange
            School school = new School();
            //Act
            for (int i = 0; i < 8999; i++)
            {
                school.AddStudents(new Students("TestStudent"));
            }
            //Assert
            ThrowsAssert.Throws(() => school.AddStudents(new Students("student")));
        }

        [TestMethod]
        public void School_WhenAddingStudentWithSameID_ShouldThrowException()
        {
            //Arange
            var studentVesko = new Students("Vesko");
            var studentPesho = new Students("Pesho");
            var school = new School();
            var secondSchool = new School();
            //Act
            school.AddStudents(studentVesko);
            secondSchool.AddStudents(studentPesho);
            //Assert
            ThrowsAssert.Throws<ArgumentException>(() => school.AddStudents(studentPesho));
        }

        [TestMethod]
        public void School_SameIDsInSameSchool_ShouldHaveDifferentStudentNumbers()
        {
            //Arrange
            var studentVesko = new Students("Vesko");
            var studentPesho = new Students("Pesho");
            var school = new School();
            //Act
            school.AddStudents(studentVesko);
            school.AddStudents(studentPesho);
            //Assert
            Assert.AreNotEqual(studentVesko.StudentID, studentPesho.StudentID);
        }

        [TestMethod]
        public void School_WhenRemovingStudentFromSchool_ShouldRemoveStudentsCorrectly()
        {
            {
                //Arange
                var studentVesko = new Students("Vesko");
                var studentPesho = new Students("Pesho");
                var school = new School();
                //Act
                school.AddStudents(studentPesho);
                school.AddStudents(studentVesko);
                school.RemoveStudents(studentVesko);
                //Assert
                Assert.AreEqual(1, school.StudentsInSchool.Count);
            }
        }

        [TestMethod]
        public void School_WhenRemovingStudent_ShouldThrowExceptionIfStudentIsNull()
        {
            {
                //Arrange
                var studentVesko = new Students("Vesko");
                var school = new School();
                //Act
                school.AddStudents(studentVesko);
                //Assert
                ThrowsAssert.Throws<ArgumentException>(() => school.RemoveStudents(null));
            }
        }

        [TestMethod]
        public void School_WhenRemovingStudent_ShouldThrowExceptionIfStudentIsNotInTheSchool()
        {
            //Arange
            var studentVesko = new Students("Vesko");
            var studentPesho = new Students("Pesho");
            var school = new School();
            //Act
            school.AddStudents(studentPesho);
            //Assert
            ThrowsAssert.Throws<ArgumentException>(() => school.RemoveStudents(studentVesko));
        }

        [TestMethod]
        public void School_WhenAddingCourse_ShouldAddCourseCorrectly()
        {
            {
                //Arange
                var course = new Course("Literature");
                var school = new School();
                //Act
                school.AddCourse(course);
                //Assert
                Assert.AreEqual(1, school.CoursesInSchool.Count);
            }
        }

        [TestMethod]
        public void School_WhenAddingCourse_ShouldThrowExceptionIfCourseIsNull()
        {
            {
                //Arrange
                var school = new School();
                //Act and Assert
                ThrowsAssert.Throws<ArgumentException>(() => school.AddCourse(null));
            }
        }

        [TestMethod]
        public void School_WhenRemovingCourse_ShouldThrowExceptionIfCourseIsNull()
        {
            {
                //Arrange
                var course = new Course("Literature");
                var school = new School();
                //Act
                school.AddCourse(course);
                //Assert
                ThrowsAssert.Throws<ArgumentException>(() => school.RemoveCourse(null));
            }
        }

        [TestMethod]
        public void School_WhenRemovingCourse_ShouldThrowExceptionIfCourseIsNotInTheSchool()
        {
            //Arange
            var courseHistory = new Course("History");
            var courseLiterature = new Course("Literature");
            var school = new School();
            //Act
            school.AddCourse(courseHistory);
            //Assert
            ThrowsAssert.Throws<ArgumentException>(() => school.RemoveCourse(courseLiterature));
        }

        [TestMethod]
        public void School_WhenRemovingCourseFromSchool_ShouldRemoveCourseCorrectly()
        {
            {
                //Arange
                var courseHistory = new Course("History");
                var courseLiterature = new Course("Literature");
                var school = new School();
                //Act
                school.AddCourse(courseHistory);
                school.AddCourse(courseLiterature);
                school.RemoveCourse(courseHistory);
                //Assert
                Assert.AreEqual(1, school.CoursesInSchool.Count);
            }
        }
    }
}
