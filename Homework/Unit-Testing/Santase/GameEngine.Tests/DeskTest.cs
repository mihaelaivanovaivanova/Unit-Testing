using NUnit.Framework;
using Santase.Logic.Cards;
using Santase.Logic;


namespace GameEngine.Tests
{
    [TestFixture]

    public class DeckTests
    {
        [Test]
        public void Deck_WhenNewDeckInstanced_TrumpCardISTypeOfCardSuit()
        {
            //Arrange
            Deck deck = new Deck();
            //Act and Assert
            Assert.AreEqual("Santase.Logic.Cards.Card", deck.TrumpCard.GetType().ToString());
        }

        [Test]
        public void Deck_WhenNewDeckInstanced_CardsInListSouldBe24()
        {
            //Arrange
            Deck deck = new Deck();
            //Act and Assert
            Assert.AreEqual(24, deck.CardsLeft);
        }

        [Test]
        public void Deck_GetNextCard_ShouldThrowExceptionWhenNoCardAreLeftInDeck()
        {
            //Arrange
            Deck deck = new Deck();
            //Act
            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }
            //Assert
            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [Test]
        public void Deck_GetNextCard_ShouldLeaveOneLessCardLEft()
        {
            //Arrange
            Deck deck = new Deck();
            //Act
            deck.GetNextCard();
            //Assert
            Assert.AreEqual(23,deck.CardsLeft);
        }

        [Test]
        public void Deck_GetNextCard_ShouldReturnCard()
        {
            //Arrange
            Deck deck = new Deck();
            //Act and Assert
            Assert.AreEqual("Santase.Logic.Cards.Card", deck.GetNextCard().GetType().ToString());
        }

        [TestCase(CardSuit.Club, CardType.Ace)]
        [TestCase(CardSuit.Diamond, CardType.Jack)]
        public void Deck_ChangeTrumpCard_ShouldChangeTrumpCard(CardSuit cardSuit, CardType cardType)
        {
            var deck = new Deck();
            var nextTrumpCard = new Card(cardSuit, cardType);

            deck.ChangeTrumpCard(nextTrumpCard);

            Assert.AreEqual(nextTrumpCard, deck.TrumpCard);
        }


    }
}

