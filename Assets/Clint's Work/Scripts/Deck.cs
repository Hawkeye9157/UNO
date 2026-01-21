using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Card[] deck;

    public void Shuffle()
    {

    }
    public Card Draw()
    {
        return null;
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
