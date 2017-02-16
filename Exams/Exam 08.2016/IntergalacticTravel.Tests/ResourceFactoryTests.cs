using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    class ResourceFactoryTests
    {
        [TestCase ("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]

        public void GetResources_WhenInputStringIsInCorrectFormat_ShouldSetObjectPropertiesCorrectly(string input)
        {
            //Arrange
            var resourceFactory = new ResourcesFactory();
            //Act
            var resources= resourceFactory.GetResources(input);
            //Assert
            Assert.AreEqual(20, resources.GoldCoins);
            Assert.AreEqual(30, resources.SilverCoins);
            Assert.AreEqual(40, resources.BronzeCoins);
        }

        [TestCase ("some other input format")]
        [TestCase("create resourses try(1) trytry(2) trytrytry(3)")]

        public void GerResources_WhenInputStringIsInvalid_ShouldThrowInvalidOperationException(string input)
        {
            //Arrange
            var resourceFactory = new ResourcesFactory();
            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => resourceFactory.GetResources(input));
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
    
        public void GerResources_WhenInputStringIsValidButBiggerThanUintMaxValue_ShouldThrowOverflowException(string input)
        {
            //Arrange
            var resourceFactory = new ResourcesFactory();
            //Act and Assert
            Assert.Throws<OverflowException>(() => resourceFactory.GetResources(input));
        }
    }
}
