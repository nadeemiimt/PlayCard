using System;
using System.Collections.Generic;
using CardPlay.Implementation;
using CardPlay.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardPlayTest
{
    [TestClass]
    public class DeckTests
    {
        private readonly IDeck _deckOfCards = new Deck();

        [TestMethod]
        public void DeckInstance_TestInstanceCardCount_Return52()
        {
            int cardCount = _deckOfCards.CardSet.Count;
            Assert.AreEqual(52, cardCount);
        }

        [TestMethod]
        public void Shuffle_TestCardShuffle_ReturnDeckNotEqualToOriginal()
        {
            bool isDifferent = false;

            //New instances of new Deck will equal any other instance by length
            //and type. Shuffle will adjust the order of the list.
            Deck tempDeck = new Deck();

            tempDeck.Shuffle();

            for (int i = 0; i < tempDeck.CardSet.Count; i++)
            {
                if (tempDeck.CardSet[i].CardSuit != _deckOfCards.CardSet[i].CardSuit)
                {
                    //If a suit at any position in tempDeck does not match that of deckOfCards,
                    //then we can state that the deck was successfully shuffled by atleast 1 card
                    isDifferent = true;
                    break;
                }
            }

            //If this test passes, then newDeck is different in order than that of deckOfCards
            Assert.IsTrue(isDifferent);
        }

        [TestMethod]
        public void Draw_TestCardCountDrawn_ReturnHandCountEqualToHowMany()
        {
            int playTimes = 52;
            List<Card> userHandCard = new List<Card>();
            _deckOfCards.Shuffle();
            for (int i = 0; i < playTimes; i++)
            {
                userHandCard.Add(_deckOfCards.Draw());
            }
            

            Assert.AreEqual(userHandCard.Count, playTimes);
            CollectionAssert.AllItemsAreUnique(userHandCard); // All cards are unique
        }
    }
}