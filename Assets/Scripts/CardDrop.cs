using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public void OnPointerEnter(PointerEventData eventData) {
        //Debug.Log("Enter Pointer");
    }

    public void OnPointerExit(PointerEventData eventData) {
        //Debug.Log("Exit Pointer");
    }

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("Card Dropped");
        CardDrag card = eventData.pointerDrag.GetComponent<CardDrag>();
        if (card != null) {
            card.returnParent = gameObject.transform;
        }
    }


}
