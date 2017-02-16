using IntergalacticTravel.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    class UnitsFactoryTests
    {
        [Test]
        public void GetUnit_WhenValidCommandIsPassed_ShouldReturnProcyon()
        {
            //Arrange
            var unitsFactory = new UnitsFactory();
            //Act
            var result = unitsFactory.GetUnit("create unit Procyon Gosho 1");
            //Assert
            Assert.IsInstanceOf<Procyon>(result);
        }

        [Test]
        public void GetUnit_WhenValidCommandIsPassed_ShouldReturnLuyten()
        {
            //Arrange
            var unitsFactory = new UnitsFactory();
            //Act
            var result = unitsFactory.GetUnit("create unit Luyten Pesho 2");
            //Assert
            Assert.IsInstanceOf<Luyten>(result);
        }

        [Test]
        public void GetUnit_WhenValidCommandIsPassed_ShouldReturnLacaille()
        {
            //Arrange
            var unitsFactory = new UnitsFactory();
            //Act
            var result = unitsFactory.GetUnit("create unit Lacaille Tosho 3");
            //Assert
            Assert.IsInstanceOf<Lacaille>(result);
        }

        [TestCase ("Test not in a valid format")]
        [TestCase("create unit MeMe Tosho 3")]
        public void GetUnit_WhenInvalidCommandIsPassed_ShouldThrowInvalidUnitCreationCommandException(string input)
        {
            //Arrange
            var unitsFactory = new UnitsFactory();
            //Act and Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => unitsFactory.GetUnit(input));
        }

    }
}
