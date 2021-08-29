using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealCards : MonoBehaviour
{
    public GameObject defenseCard;
    public GameObject attackCard;
    public GameObject healCard;
    public GameObject handArea;

    List<GameObject> CardTypes = new List<GameObject>();
    // Start is called before the first frame update
    void Start() {
        CardTypes.Add(defenseCard);
        CardTypes.Add(attackCard);
        CardTypes.Add(healCard);
    }

    public void CreateCard() {
        if (handArea.transform.childCount < 5) {
            GameObject newCard = Instantiate(CardTypes[Random.Range(0, CardTypes.Count)], new Vector2(0, 0), Quaternion.identity);

            newCard.transform.SetParent(handArea.transform, false);
        }
        else {
            Debug.Log("Too many cards in your hand.");
        }
    }
}
