using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class Deck : MonoBehaviour
{
    public Card[] deck;
    public Card[] discard;

    System.Random random = new System.Random();

    public void Shuffle()
    {
        if (deck.Length == 0)
        {
            deck = new Card[discard.Length];
        }
        else
        {
            deck = new Card[108];
        }

        foreach (Card card in discard)
        {
            int index;

            do
            {
                index = random.Next(deck.Length);

                deck[index] = card;
            }
            while (deck.ElementAt(index) != null);
        }
    }
    public Card Draw()
    {
        int drawnCard;
        Card card = null;

        do
        {
            drawnCard = random.Next(deck.Length);
            try
            {
                card = deck[drawnCard];
            }
            catch (NullReferenceException n)
            {
                Console.WriteLine("Drawn Card Has Already Been Drawn, Trying Again...");
            }
        }
        while (deck.ElementAt(drawnCard) == null);

        discard.Append(card);
        deck[drawnCard] = null;

        return card;
    }
    public void Deal(Player player1, Player player2, Player player3, Player player4)
    {
        for(int i = 0; i < 7; i++)
        {
            player1.hand.Append(Draw());
            player2.hand.Append(Draw());
            player3.hand.Append(Draw());
            player4.hand.Append(Draw());
        }
    }
}
