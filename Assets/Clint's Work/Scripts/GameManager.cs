using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Human player1;
    [SerializeField] public AI player2;
    [SerializeField] public AI player3;
    [SerializeField] public AI player4;
    [SerializeField] public Deck baseDeck;

    public Deck deck;
    public Card lastPlayerCard;
    int drawAmount = 0;

    public bool clockwiseOrder = true;
    private Player[] turnOrder;
    private Player currentPlayer;

    private void CreateDeck()
    {
        deck = baseDeck;
    }

    public void StartGame()
    {
        turnOrder = new Player[4] {player1,player2,player3,player4 };
        CreateDeck();
        deck.Deal(player1,player2,player3,player4);
    }
    public void Reset()
    {
        player1.hand = new List<Card>();
        player2.hand = new List<Card>();
        player3.hand = new List<Card>();
        player4.hand = new List<Card>();
    }
    public void HandleAction(E_Action action)
    {
        switch (action)
        {
            case E_Action.NONE:
                break;
            case E_Action.REVERSE:
                Reverse();
                break;
            case E_Action.SKIP:
                Skip();
                break;
            case E_Action.DRAW2:
                Draw2();
                break;
            case E_Action.WILD:
                Wild();
                break;
            case E_Action.WILD_DRAW:
                Wild4();
                break;
        }
        NextTurn(currentPlayer);
    }
    public void NextTurn(Player current)
    {
        if (clockwiseOrder)
        {
            int index = Array.IndexOf(turnOrder, current);
            if((index + 1) >= turnOrder.Length - 1)
            {
                currentPlayer = turnOrder[0];
            }
            else
            {
                currentPlayer = turnOrder[index];
            }
        }
        else
        {
            int index = Array.IndexOf(turnOrder, current);
            if (index == 0 )
            {
                currentPlayer = turnOrder[turnOrder.Length - 1];
            }
            else
            {
                currentPlayer = turnOrder[index];
            }
        }
    }
    public Player NextPlayer()
    {
        int index = Array.IndexOf(turnOrder, currentPlayer);
        if (clockwiseOrder)
        {
            if (index >= turnOrder.Length - 1)
            {
                return turnOrder[0];
            }
            else
            {
                return turnOrder[index];
            }
        }
        else
        {
            if (index >= 0)
            {
                return turnOrder[turnOrder.Length - 1];
            }
            else
            {
                return turnOrder[index];
            }
        }
    }
    public void HandleWin(Player player)
    {

    }


    //action methods
    private void Reverse()
    {
        if (clockwiseOrder) clockwiseOrder = false;
        else clockwiseOrder = true;
    }
    private void Skip()
    {
        NextTurn(currentPlayer);
    }
    private void Draw2()
    {

    }
    private void Wild()
    {

    }
    private void Wild4()
    {
        Wild();
        Draw2();
        Draw2();
    }
}
