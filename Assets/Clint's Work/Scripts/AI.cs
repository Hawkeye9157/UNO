using UnityEngine;

public class AI : Player
{
    public Deck deck;

    public override void CallUNO()
    {
        throw new System.NotImplementedException();
    }

    public override Card Play(Card card)
    {
        Card lastPlayed = deck.discard[deck.discard.Length - 1];

        foreach (var handCard in hand)
        {
            if (handCard.color == lastPlayed.color || handCard.number == lastPlayed.number
                || (handCard.isAction && (handCard.action == E_Action.WILD || handCard.action == E_Action.WILD_DRAW)))
            {
                card = handCard; 
                break;
            }
        }

        if (card == null)
        {
            card = deck.Draw();
            Play(card);
        }

        //throw new System.NotImplementedException();

        return card;
    }
}
