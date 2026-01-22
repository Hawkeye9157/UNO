using System.Linq;
using UnityEngine;

public class Human : Player
{
    public Deck deck;

    public override void CallUNO()
    {
        throw new System.NotImplementedException();
    }

    public override Card Play(Card card)
    {
        if (deck.discard == null)
        {
            deck.discard = new Card[108];
        }

        deck.discard.Append(card);

        throw new System.NotImplementedException();
    }
}
