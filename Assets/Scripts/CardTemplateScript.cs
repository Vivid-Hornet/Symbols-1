using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardTemplateScript : ScriptableObject
{
    public string cardName;

    public string description;

    public int power;

    public Sprite cardArt;

    public int polyPoints;
}