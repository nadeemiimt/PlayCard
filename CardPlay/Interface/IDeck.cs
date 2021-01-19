using System;
using System.Collections.Generic;
using System.Text;
using CardPlay.Implementation;

namespace CardPlay.Interface
{
    public interface IDeck
    {
        /// <summary>
        /// Card Set.
        /// </summary>
        List<Card> CardSet { get; set; }

        /// <summary>
        /// Shuffle the deck.
        /// </summary>
        void Shuffle();

        /// <summary>
        /// Draw a the specified number of cards from the deck.
        /// </summary>
        /// <returns>the list of drawn cards</returns>
        Card Draw();

        /// <summary>
        /// Print provided card value
        /// </summary>
        /// <param name="card">Card input.</param>
        void Print(Card card);
    }
}
