using Academy.Models;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.Courses
{
    [TestFixture]
    class CourseToStringTests
    {
        [Test]
        public void ToString_WhenCollectionIsNotEmpty_ShouldItterateOverTheCollection()
        {
            //Arrange
            DateTime startDate = new DateTime(2016, 05, 30);
            DateTime endDate = new DateTime(2016, 06, 30);
            var course = new Course("Mathematics", 5, startDate, endDate);
            var firstLectureMock = new Mock<ILecture>();
            firstLectureMock.Setup(x => x.ToString());
            course.Lectures.Add(firstLectureMock.Object);
            //Act
            course.ToString();
            //Assert
            StringAssert.Contains(firstLectureMock.ToString(),course.ToString());

        }

        [Test] 
        public void ToString_WhenCollectionIsEmpty_ShouldNotItterateOverTheCollection()
        {
            //Arrange
            DateTime startDate = new DateTime(2016, 05, 30);
            DateTime endDate = new DateTime(2016, 06, 30);
            var course = new Course("Mathematics", 5, startDate, endDate);
            //Act
            course.ToString();
            //Assert
            StringAssert.Contains("no lectures", course.ToString());

        }
    }
}
