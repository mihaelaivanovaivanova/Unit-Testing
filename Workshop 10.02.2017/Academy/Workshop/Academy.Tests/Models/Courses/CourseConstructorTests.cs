using Academy.Models;
using NUnit.Framework;
using System;

namespace Academy.Tests.Models.Courses
{
    [TestFixture]
    public class CourseConstructorTests
    {
        internal DateTime startDate;
        internal DateTime endDate;
        internal Course course;

        [SetUp]
        public void BeforeEachTest()
        {
          startDate = new DateTime(2016, 05, 30);
          endDate = new DateTime(2016, 06, 29);
          course = new Course("Mathematics", 5, startDate, endDate);
        }

        [Test]
        public void CourseConstructor_WhenPassedValiedValues_ShouldSetNameCorrectly()
        {
            Assert.AreEqual("Mathematics", course.Name);
        }

        [Test]
        public void CourseConstructor_WhenPassedValiedValues_ShouldSetNumberOfLecturesPerWeekCorrectly()
        {
            Assert.AreEqual(5, course.LecturesPerWeek);
        }

        [Test]
        public void CourseConstructor_WhenPassedValiedValues_ShouldSetStartDateCorrectly()
        {
            Assert.AreEqual(startDate, course.StartingDate);
        }

        [Test]
        public void CourseConstructor_WhenPassedValiedValues_ShouldSetEndDateCorrectly()
        {
            Assert.AreEqual(endDate, course.EndingDate);
        }
    }
}
