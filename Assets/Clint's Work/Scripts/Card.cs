using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int number;
    public string color;
    public bool isAction;
    public E_Action action;

    public string tempColor; //used for wild cards to decide color

    public Texture2D image;
}
