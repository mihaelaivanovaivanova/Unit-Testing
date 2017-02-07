using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandsCheckerTest
    {
        [TestMethod]
        public void PockerHandsCkecker_WhenHandWithLessThan5CardsIsPassed_IsValidShouldReturnFalse()
        {
            //Arrange
            var pockerHandChecker = new PokerHandsChecker();
            var cardOne = new Card(CardFace.King, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.Six, CardSuit.Clubs);
            var cardThree = new Card(CardFace.Two, CardSuit.Hearts);
            var cardFour = new Card(CardFace.Nine, CardSuit.Spades);
            var cards = new List<ICard> { cardOne, cardTwo, cardThree, cardFour };
            var hand = new Hand(cards);
            //Act and Assert
            Assert.IsFalse(pockerHandChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void PockerHandsCkecker_WhenHandWithMoreThan5CardsIsPassed_IsValidShouldReturnFalse()
        {
            //Arrange
            var pockerHandChecker = new PokerHandsChecker();
            var cardOne = new Card(CardFace.King, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.Six, CardSuit.Clubs);
            var cardThree = new Card(CardFace.Two, CardSuit.Hearts);
            var cardFour = new Card(CardFace.Nine, CardSuit.Spades);
            var cardFive = new Card(CardFace.Queen, CardSuit.Diamonds);
            var cardSix = new Card(CardFace.Three, CardSuit.Spades);

            var cards = new List<ICard> { cardOne, cardTwo, cardThree, cardFour, cardFive, cardSix };
            var hand = new Hand(cards);
            //Act and Assert
            Assert.IsFalse(pockerHandChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void PockerHandsCkecker_WhenHandWithExactly5CardsIsPassed_IsValidShouldReturnTrue()
        {
            var pockerHandChecker = new PokerHandsChecker();
            var cardOne = new Card(CardFace.King, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.Six, CardSuit.Clubs);
            var cardThree = new Card(CardFace.Two, CardSuit.Hearts);
            var cardFour = new Card(CardFace.Nine, CardSuit.Spades);
            var cardFive = new Card(CardFace.Eight, CardSuit.Spades);

            var cards = new List<ICard> { cardOne, cardTwo, cardThree, cardFour, cardFive };
            var hand = new Hand(cards);
            //Act and Assert
            Assert.IsTrue(pockerHandChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void PockerHandsCkecker_WhenNullIsPassed_IsValidShouldThrowArgumentNullException()
        {
            //Arrange,
            var pockerHandChecker = new PokerHandsChecker();
            //Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => pockerHandChecker.IsValidHand(null));
        }

        [TestMethod]
        public void PockerHandsCkecker_WhenHandWithExactly5CardsIsPassedAndACardIsRepeated_IsValidShouldReturnFalse()
        {
            //Arrange
            var pockerHandChecker = new PokerHandsChecker();
            var cardOne = new Card(CardFace.King, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.Six, CardSuit.Clubs);
            var cardThree = new Card(CardFace.Two, CardSuit.Hearts);
            var cardFour = new Card(CardFace.Nine, CardSuit.Spades);
            var cardFive = new Card(CardFace.King, CardSuit.Hearts);

            var cards = new List<ICard> { cardOne, cardTwo, cardThree, cardFour, cardFive };
            var hand = new Hand(cards);
            //Act and Assert
            Assert.IsFalse(pockerHandChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void PockerHandsCkecker_WhenHandWith5CardsWithTheSameSuit_IsFlashShouldReturnTrue()
        {
            //Arrange
            var pockerHandChecker = new PokerHandsChecker();
            var cardOne = new Card(CardFace.King, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.Six, CardSuit.Hearts);
            var cardThree = new Card(CardFace.Two, CardSuit.Hearts);
            var cardFour = new Card(CardFace.Nine, CardSuit.Hearts);
            var cardFive = new Card(CardFace.Four, CardSuit.Hearts);

            var cards = new List<ICard> { cardOne, cardTwo, cardThree, cardFour, cardFive };
            var hand = new Hand(cards);
            //Act and Assert
            Assert.IsTrue(pockerHandChecker.IsFlush(hand));
        }

        [TestMethod]
        public void PockerHandsCkecker_WhenDifferentSuitsInHand_IsFlashShouldReturnFalse()
        {
            //Arrange
            var pockerHandChecker = new PokerHandsChecker();
            var cardOne = new Card(CardFace.King, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.Six, CardSuit.Diamonds);
            var cardThree = new Card(CardFace.Two, CardSuit.Clubs);
            var cardFour = new Card(CardFace.Nine, CardSuit.Spades);
            var cardFive = new Card(CardFace.Four, CardSuit.Hearts);

            var cards = new List<ICard> { cardOne, cardTwo, cardThree, cardFour, cardFive };
            var hand = new Hand(cards);
            //Act and Assert
            Assert.IsFalse(pockerHandChecker.IsFlush(hand));
        }

        [TestMethod]
        public void PockerHandsCkecker_WhenThereAreLessThanFourCardsOfAKindInAValidHand_IsFourOfAKindShouldReturnFalse()
        {
            //Arrange
            var pockerHandChecker = new PokerHandsChecker();
            var cardOne = new Card(CardFace.King, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.Six, CardSuit.Clubs);
            var cardThree = new Card(CardFace.Two, CardSuit.Hearts);
            var cardFour = new Card(CardFace.Nine, CardSuit.Spades);
            var cardFive = new Card(CardFace.King, CardSuit.Diamonds);

            var cards = new List<ICard> { cardOne, cardTwo, cardThree, cardFour, cardFive };
            var hand = new Hand(cards);
            //Act and Assert
            Assert.IsFalse(pockerHandChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void PockerHandsCkecker_WhenThereAreExaclyFourOfAKindInAValidHand_IsFourOfAKindShouldReturnTrue()
        {
            //Arrange
            var pockerHandChecker = new PokerHandsChecker();
            var cardOne = new Card(CardFace.King, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.King, CardSuit.Clubs);
            var cardThree = new Card(CardFace.Two, CardSuit.Hearts);
            var cardFour = new Card(CardFace.King, CardSuit.Spades);
            var cardFive = new Card(CardFace.King, CardSuit.Diamonds);

            var cards = new List<ICard> { cardOne, cardTwo, cardThree, cardFour, cardFive };
            var hand = new Hand(cards);
            //Act and Assert
            Assert.IsTrue(pockerHandChecker.IsFourOfAKind(hand));
        }
    }
}
