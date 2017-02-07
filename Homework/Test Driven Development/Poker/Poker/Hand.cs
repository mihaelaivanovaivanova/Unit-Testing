using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            if (this.Cards == null)
            {
                throw new ArgumentNullException();
            }

            var result = new StringBuilder();
            
            for (int i = 0; i < this.Cards.Count; i++)
            {
                if (this.Cards[i] != null)
                {
                    if (i != this.Cards.Count - 1)
                    {
                        result.Append($"{this.Cards[i].Face} {this.Cards[i].Suit}, ");
                    }
                    else
                    {
                        result.Append($"{this.Cards[i].Face} {this.Cards[i].Suit}");
                    }
                }
                
            }
            return result.ToString();

        }
    }
}