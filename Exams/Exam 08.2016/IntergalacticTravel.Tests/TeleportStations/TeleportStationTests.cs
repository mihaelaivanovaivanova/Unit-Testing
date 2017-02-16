using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Tests.TeleportStations.Mock;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.TeleportStations
{
    [TestFixture]
    class TeleportStationTests
    {
        [Test]
        public void Constructor_WhenNewTeleportStationWithValidParametersIsCreated_ShouldSetFieldsCorrectly()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var mapMock = new Mock<IEnumerable<IPath>>();
            //Act
            var teleportStation = new ExtensionTeleportStation(ownerMock.Object, mapMock.Object, locationMock.Object);
            //Assert
            Assert.AreSame(ownerMock.Object, teleportStation.Owner);
            Assert.AreSame(locationMock.Object, teleportStation.Location);
            Assert.AreSame(mapMock.Object, teleportStation.GalacticMap);

        }
        [Test]

        public void TeleportUnit_WhenUnitToTeleportIsNull_ShouldThrowArgumentNullExceptionWithCertainMessage()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var mapMock = new Mock<IEnumerable<IPath>>();
            var targetLocationMock = new Mock<ILocation>();
            var teleportStation = new ExtensionTeleportStation(ownerMock.Object,mapMock.Object,locationMock.Object);
            //Act and Assert
            var exc = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(null, targetLocationMock.Object));
            var exceptionMessage = exc.Message;
            //Assert
            StringAssert.Contains("unitToTeleport", exceptionMessage);
        }

        [Test]

        public void TeleportUnit_WhenUDestinationIsNull_ShouldThrowArgumentNullExceptionWithCertainMessage()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var mapMock = new Mock<IEnumerable<IPath>>();
            var unitToTeleportMock = new Mock<IUnit>();
            var teleportStation = new ExtensionTeleportStation(ownerMock.Object, mapMock.Object, locationMock.Object);
            //Act and Assert
            var exc = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, null));
            var exceptionMessage = exc.Message;
            //Assert
            StringAssert.Contains("destination", exceptionMessage);
        }

        [Test]

        public void TeleportUnit_WhenUsingTeleporStationFromDistantLocation_ShouldThrowTeleportOutOfRangeExceptionWithCertainMessage()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var mapMock = new Mock<IEnumerable<IPath>>();
            var locationMock = new Mock<ILocation>();
            var teleportStation = new ExtensionTeleportStation(ownerMock.Object, mapMock.Object, locationMock.Object);
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();


            locationMock.SetupGet(x => x.Planet.Name).Returns("Planet 1");
            locationMock.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy 1");

            unitToTeleportMock.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Planet 2");
            unitToTeleportMock.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Galaxy 2");
            
            //Act and Assert
            var exc = Assert.Throws<TeleportOutOfRangeException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            var exceptionMessage = exc.Message;
            //Assert
            StringAssert.Contains("unitToTeleport.CurrentLocation", exceptionMessage);
        }

        [Test]

        public void TeleportUnit_WhenTeleporUnitToAlreadyTakenLocation_ShouldThrowInvalidTeleportationLocationExceptionWithCertainMessage()
        {
            // Arrange
            var expectedExceptionMessage = "Galaxy";
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("DifferentGalaxyName");

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtensionTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act & Assert
            var exc = Assert.Throws<LocationNotFoundException>(
                () => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }


    }
}
