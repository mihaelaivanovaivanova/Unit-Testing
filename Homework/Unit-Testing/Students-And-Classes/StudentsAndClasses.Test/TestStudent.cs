using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;
using StudentsAndClasses.Models;

namespace StudentsAndClasses.Test
{
    [TestClass]
    public class TestStudent
    {
        
        [TestMethod]
        public void Students_WhenNameIsNull_ThrowsException()
        {
            //Arrange, Act, Assert
            ThrowsAssert.Throws<ArgumentNullException>(() =>new Students(null));
        }

        [TestMethod]
        public void Students_WhenNameIsEmpty_ThrowsException()
        {
            //Arrange, Act, Assert
            ThrowsAssert.Throws<ArgumentNullException>(() => new Students(string.Empty));
        }

        [TestMethod]
        public void Studenst_WhenInstanced_ShouldSetNameCorrectly()
        {
            //Arrange
            Students studentVesko = new Students("Vesko");
            //Act and Assert
            Assert.AreEqual("Vesko", studentVesko.Name);
        }

        [TestMethod]
        public void Students_WhenInstanced_ShouldSetUniqueNumber1000()
        {
            //Arrange
            Students studentVesko = new Students("Vesko");
            Students studentPesho = new Students("Pesho");

            //Act and Assert
            Assert.AreEqual(1000, studentPesho.StudentID);
        }

        [TestMethod]
        public void Students_WhenInstanced_ShouldSetSchoolNullProperty()
        {
            //Arrange
            Students studentVesko = new Students("Vesko");
            //Act and Assert
            Assert.IsNull(studentVesko.School);
        }

        [TestMethod]
        public void Students_WhenJoinCourse_ShouldJoinCourseCorrectly()
        {
            //Arrange
            Students studentVesko = new Students("Vesko");
            Course course = new Course("History");
            //Act
            studentVesko.JoinCourse(course);
            //Assert
            Assert.AreEqual(true, course.StudentsInCourse.IndexOf(studentVesko) >= 0);
        }
        [TestMethod]
        public void Students_WhenJoinCourse_ShouldThrowWhneCourseNameIsNull()
        {
            //Arrange
            Students studentVesko = new Students("Vesko");
            Course course = new Course("History");
            //Act and Assert
            ThrowsAssert.Throws<ArgumentNullException>(() => studentVesko.JoinCourse(null));
        }

        [TestMethod]

        public void Students_WhenLeaveCourse_ShouldLeaveCourseCorrectly()
        {
            //Arrange
            Students studentVesko = new Students("Vesko");
            Course course = new Course("History");
            //Act
            studentVesko.JoinCourse(course);
            studentVesko.LeaveCourse(course);
            //Assert
            Assert.AreEqual(true, course.StudentsInCourse.IndexOf(studentVesko) < 0);
        }

        [TestMethod]

        public void Students_WhenLeaveCourse_ShoudThrowIfStudentDoesNotAttendTheCurrentCourse()
        {
            //Arrange
            Students studentVesko = new Students("Vesko");
            Course course = new Course("History");
            //Act andAssert
            ThrowsAssert.Throws<ArgumentException>(() => studentVesko.LeaveCourse(course));
        }

        [TestMethod]

        public void Students_WhenLeaveCourse_ShoudThrowIfCourseIsNull()
        {
            //Arrange
            Students studentVesko = new Students("Vesko");
            //Act andAssert
            ThrowsAssert.Throws<ArgumentNullException>(() => studentVesko.LeaveCourse(null));
        }
    }
}
