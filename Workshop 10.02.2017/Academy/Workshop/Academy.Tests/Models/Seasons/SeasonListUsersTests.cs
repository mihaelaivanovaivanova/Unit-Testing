using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;

namespace Academy.Tests.Models.Seasons
{
    [TestFixture]
    class SeasonListUsersTests
    {
        [Test]
        public void SeasonListUserts_WhenThereIsOneTrainer_ShouldItterate()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var trainerMock = new Mock<ITrainer>();

            season.Trainers.Add(trainerMock.Object);
            trainerMock.Setup(x=>x.ToString());

            // Assert
            StringAssert.Contains(trainerMock.ToString(), season.ListUsers());
        }

        [Test]
        public void SeasonListUserts_WhenThereIsOneStudent_ShouldItterate()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var studentMock = new Mock<IStudent>();

            season.Students.Add(studentMock.Object);
            studentMock.Setup(x => x.ToString());

            // Assert
            StringAssert.Contains(studentMock.ToString(), season.ListUsers());
        }

        [Test]
        public void SeasonListUserts_WhenThereAreNoUsers_ShouldIncludeNoUsers()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            //Act and Assert
            StringAssert.Contains("no users", season.ListUsers());
        }

    }
}

