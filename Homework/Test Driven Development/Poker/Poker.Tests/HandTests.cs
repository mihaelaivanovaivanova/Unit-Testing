using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class HandTests
    {

        [TestMethod]
        public void Hand_WhenNullIsPassedAsHandParameter_ShouldThrowArgumentNullException()
        {
            //Arrange
            var hand = new Hand(null);
            //Act and Assert
            Assert.ThrowsException<ArgumentNullException>(()=>hand.ToString());
        }

        [TestMethod]
        public void Hand_WhenHandWithAllInvalidParametersIsPassed_ShouldReturnEmptyStringWhenToString()
        {
            //Arrange
            var hand = new Hand(new List<ICard> { null, null });
            //Act and Assert
            Assert.AreEqual("", hand.ToString());
        }

        [TestMethod]
        public void Hand_WhenHandWithSomeInvalidParametersIsPassed_ShouldReturnCorrectlyStringWhenToString()
        {
            //Arrange
            var cardOne = new Card(CardFace.King, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.Six, CardSuit.Clubs);
            var hand = new Hand(new List<ICard> { cardOne, null, cardTwo });
            //Act and Assert
            Assert.AreEqual($"{cardOne.Face} {cardOne.Suit}, {cardTwo.Face} {cardTwo.Suit}", hand.ToString());
        }

        [TestMethod]
        public void Hand_WhenValidPArametersArePassed_ShouldReturnCorreclyString()
        {
            //Arrange
            var cardOne = new Card(CardFace.King, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.Six, CardSuit.Clubs);
            var cardThree = new Card(CardFace.Two, CardSuit.Hearts);
            var cardFour = new Card(CardFace.Nine, CardSuit.Spades);
            var cardFive = new Card(CardFace.Five, CardSuit.Diamonds);
            var cards = new List<ICard> { cardOne, cardTwo, cardThree, cardFour, cardFive };
            var hand = new Hand(cards);
            //Act and Assert
            Assert.AreEqual(hand.ToString(), $"{cardOne.Face} {cardOne.Suit}, {cardTwo.Face} {cardTwo.Suit}, {cardThree.Face} {cardThree.Suit}, {cardFour.Face} {cardFour.Suit}, {cardFive.Face} {cardFive.Suit}");
        }

    }
}
