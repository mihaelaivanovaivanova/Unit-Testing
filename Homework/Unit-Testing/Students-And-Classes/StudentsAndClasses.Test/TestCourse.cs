using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsAndClasses.Models;
using MSTestExtensions;

namespace StudentsAndClasses.Test
{
    [TestClass]
    public class TestCourse
    {
        [TestMethod]
        public void Course_WhenNewInstanceOfCourse_ShouldInstanceHaveTypeOfCourse()
        {
            //Arrange
            Course course = new Course("Mathematics");
            //Act and Assert
            Assert.IsInstanceOfType(course, typeof(Course));
        }

        [TestMethod]
        public void Course_WhenNewInstanceOfCourse_ShouldHaveAListOfStudentsWithZeroLength()
        {
            //Arrange
            Course course = new Course("Mathematics");
            //Act and Assert
            Assert.AreEqual(course.StudentsInCourse.Count,0);
        }

        [TestMethod]
        public void Course_WhenInstanced_ShouldSetSchoolNullProperty()
        {
            //Arrange
            Course course = new Course("Mathematics");
            //Act and Assert
            Assert.IsNull(course.School);
        }

        [TestMethod]
        public void Course_WhenNewCoursIsInstanced_ShouldSetNameCorrectly()
        {
            //Arrange
            string nameOfCourse = "Mathematics";
            Course course = new Course(nameOfCourse);
            //Act and Assert
            Assert.AreEqual(nameOfCourse, course.Name);
        }

        [TestMethod]
        public void Course_WhenNewStudentIsAdded_ShouldAddStudentCorrectly()
        {
            //Arrange
            Students studentVesko = new Students("Vesko");
            Course course = new Course("Mathematics");
            //Act
            course.AddStudent(studentVesko);
            //Assert
            Assert.AreEqual(true, course.StudentsInCourse.IndexOf(studentVesko)>=0);
        }

        [TestMethod]
        public void Course_WhenAddingStudents_ShpuldReturnThecorectNumberOFStudentsInCourse()
        {
            Students studentVesko = new Students("Vesko");
            Course course = new Course("Mathematics");
            //Act
            for (int i = 0; i < 15; i++)
            {
                course.AddStudent(studentVesko);
            }
            //Assert
            Assert.AreEqual(15,course.StudentsInCourse.Count);
        }

        [TestMethod]

        public void Course_WhenCourseIsFull_ShouldThrowWhenTryingToAddNewStudent()
        {
            //Arrange
            Students studentVesko = new Students("Vesko");
            Course course = new Course("Mathematics");
            //Act
            for (int i = 0; i < 30; i++)
            {
                course.AddStudent(studentVesko);
            }
            //Assert
            ThrowsAssert.Throws<ArgumentOutOfRangeException>(() => course.AddStudent(studentVesko));
        }

        [TestMethod]
        public void Course_WhenStudentIsRemoved_ShouldRemoveStudentCorrectly()
        {
            //Arrange
            Students studentVesko = new Students("Vesko");
            Students studentPesho = new Students("Pesho");
            Course course = new Course("Mathematics");
            //Act
            course.AddStudent(studentVesko);
            course.AddStudent(studentPesho);
            course.RemoveStudent(studentVesko);
            //Assert
            Assert.AreEqual(true, course.StudentsInCourse.IndexOf(studentVesko) < 0);
        }

        [TestMethod]
        public void Course_WhenStudentThatIsNotInTheCourseIsTryingToBeRemoved_ShouldThrowException()
        {
            //Arrange
            Students studentVesko = new Students("Vesko");
            Students studentPesho = new Students("Pesho");
            Course course = new Course("Mathematics");
            //Act
            course.AddStudent(studentVesko);
            //Assert
            ThrowsAssert.Throws<ArgumentException>(() => course.RemoveStudent(studentPesho));
        }

    }
}
