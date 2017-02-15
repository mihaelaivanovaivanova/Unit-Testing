using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.Seasons
{
    [TestFixture]
    class SeasonListCoursesTests
    {
        [Test]
        public void SeasonListCourse_WhenThereIsAtLeastOneCourse_ShouldItterate()
        {
            //Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var courseMock = new Mock<ICourse>();

            season.Courses.Add(courseMock.Object);
            courseMock.Setup(x => x.ToString());

            // Act and Assert
            StringAssert.Contains(courseMock.ToString(), season.ListCourses());
        }

        [Test]
        public void SeasonListCourse_WhenThereIsNoCourse_ShouldOutputConsistsNoCourses()
        {
            //Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            //Act and Assert
            StringAssert.Contains("no courses", season.ListCourses());
        }
    }
}
