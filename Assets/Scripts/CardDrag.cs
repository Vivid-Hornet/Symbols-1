using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform returnParent = null;
    public GameObject etcher;
    public GameObject template;



    public void OnBeginDrag(PointerEventData eventData) {
        returnParent = gameObject.transform.parent;
        Debug.Log("Begin Drag");
        gameObject.transform.SetParent(gameObject.transform.parent.parent);
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End Drag");
        gameObject.transform.SetParent(returnParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == transform.parent.parent.Find("Play Area")) {
            int polyPoints = gameObject.GetComponent<CardInformation>().card.polyPoints;
            template.GetComponent<TestSymbolScript>().polyPoints = polyPoints;
            GameObject Etcher = Instantiate(etcher, new Vector2(0, 0), Quaternion.identity);
            Etcher.transform.SetParent(transform.parent.parent.Find("Play Area"));
            GameObject Template = Instantiate(template, new Vector2(0, 0), Quaternion.identity);
            Template.transform.SetParent(transform.parent.parent.Find("Play Area"));
            
            Destroy(gameObject);
        }
    }
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Enter Pointer");
        transform.localScale *= 1.1f;
        gameObject.transform.position += Vector3.up * 70f;
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("Exit Pointer");
        transform.localScale /= 1.1f;
        gameObject.transform.position += Vector3.down * 70f;
    }

    public void OnDrag(PointerEventData eventData) {
        gameObject.transform.position = eventData.position;
    }
}
