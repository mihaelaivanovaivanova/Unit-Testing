using Academy.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.Courses
{
    [TestFixture]
    class LecturesPerWeekTests
    {
        [TestCase(0)]
        [TestCase(9)]
        [TestCase(null)]
        [TestCase(-3)]
        public void LecturesPerWeek_WhenPassedValueIsNotValid_ShouldThrowArgumentException(int number)
        {
            //Arrange
            var startDate = new DateTime(2016, 05, 30);
            var endDate = new DateTime(2016, 06, 29);
            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Course("Mathematics", number, startDate, endDate));
        }

        [Test]
        public void LecturesPerWeek_WhenPassedValidValue_ShouldSetLecturesPerWeekCorrectly()
        {
            //Arrange
            var startDate = new DateTime(2016, 05, 30);
            var endDate = new DateTime(2016, 06, 29);
            //Act
            var course = new Course("History", 5, startDate, endDate);
            course.LecturesPerWeek = 3;
            //Assert
            Assert.AreEqual(3, course.LecturesPerWeek);
        }
    }
}
