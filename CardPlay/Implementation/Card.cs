using System;
using System.Collections.Generic;
using System.Text;

namespace CardPlay.Implementation
{
    public class Card
    {
        public Card(int iSuit, int iValue)
        {
            CardSuit = (CardSuit)(iSuit);
            CardValue = (CardValue)(iValue);
        }

        public CardSuit CardSuit { get; }

        public CardValue CardValue { get; }
    }
}
