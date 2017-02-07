using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;
using System;

namespace Poker.Tests
{
    [TestClass]
    public class CardTest
    {
        [DataTestMethod]
        [DataRow (CardFace.Ace, CardSuit.Hearts)]
        [DataRow(CardFace.Ace, CardSuit.Hearts)]

        public void Card_WhenToStringISCalled_ShouldReturnTextAsStringIfTheCardDoesNotContainUndefinedValues(CardFace cardFace, CardSuit cardSuit)
        {
            //Arrange
            var card = new Card(cardFace, cardSuit);
            //Act and Assert
            Assert.AreEqual(card.ToString(), $"{card.Face} {card.Suit}");
        }

        [DataTestMethod]
        [DataRow((CardFace)42, CardSuit.Hearts)]
        [DataRow(CardFace.Ace,(CardSuit)42)]

        public void Card_WhenToStringISCalled_ShouldReturnThroeIfTheCardContainsUndefinedValues(CardFace cardFace, CardSuit cardSuit)
        {
            
            //Arrange
            var card = new Card(cardFace, cardSuit);
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => card.ToString());
        }
    }
}
