using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInformation : MonoBehaviour
{

    public CardTemplateScript card;

    public Text cardName;
    public Text cardInformation;

    public Text power;

    public Image cardArt;
    // Start is called before the first frame update
    void Start()
    {
        cardName.text = card.cardName;
        cardInformation.text = card.description;

        power.text = card.power.ToString();

        cardArt.sprite = card.cardArt;
    }

}
