using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtchingScript : MonoBehaviour
{
    public GameObject destroyObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float reset = Input.GetAxis("Cancel");
        if (reset > 0) {
            Destroy(destroyObject);
        }
    }
}
