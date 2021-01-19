using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardPlay.Interface;

namespace CardPlay.Implementation
{
    public class Deck : IDeck
    {
        public List<Card> CardSet { get; set; }

        //Random Number generation variables
        private static readonly Random Rand = new Random();
        private static readonly object SyncLock = new object();


        /// <summary>
        /// Deck Constructor
        /// </summary>
        public Deck()
        {
            CardSet = new List<Card>();
            for (int i = 0; i < 4; i++)         //Suit values 0-3 (0-clubs, 1-diamonds, 2-hearts, 3-spades)
            {
                for (int j = 1; j < 14; j++)    //Card values 1-13 (values ordered from 2 to Ace, Ace is high)
                {
                    CardSet.Add(new Card(i, j));
                }
            }
        }

        /// <summary>
        /// Shuffle the deck.
        /// </summary>
        public void Shuffle()
        {
            for (int i = 0; i < CardSet.Count; i++)
            {
                //FisherYates in-place shuffle
                var temp = CardSet[i];
                var index = RandomNumber(0, CardSet.Count);
                CardSet[i] = CardSet[index];
                CardSet[index] = temp;
            }
        }


        /// <summary>
        /// Draw a the specified number of cards from the deck.
        /// </summary>
        /// <returns>the list of drawn cards</returns>
        public Card Draw()
        {
            int index = CardSet.Count - 1;

            var userHand = new Card((int)CardSet[index].CardSuit, (int)CardSet[index].CardValue);
            CardSet.RemoveAt(index);

            return userHand;
        }

        /// <summary>
        /// Print provided card value
        /// </summary>
        /// <param name="card">Card input.</param>
        public void Print(Card card)
        {
            Console.WriteLine("{0} of {1}", card.CardValue, card.CardSuit);
        }

        /// <summary>
        /// Generates random number within the range of min to max-1
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Random Number Integer</returns>
        private int RandomNumber(int min, int max)
        {
            lock (SyncLock)
            {
                return Rand.Next(min, max);
            }
        }
    }
}
