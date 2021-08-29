using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScript : MonoBehaviour
{

    public void ClearPlay() {
        
        Destroy(transform.parent.Find("Play Area").Find("Template to Copy(Clone)").gameObject);
        Destroy(transform.parent.Find("Play Area").Find("Etching(Clone)").gameObject);
        Destroy(transform.parent.Find("Play Area").Find("TestPrefab(Clone)").gameObject);
        transform.parent.Find("PercentageDisplay").GetComponent<Text>().text = "00.00%";
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
