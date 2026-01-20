using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public List<Card> hand;

    public abstract Card Play(Card card);

    public abstract void CallUNO();
}
