using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartScript : MonoBehaviour
{
    //[HideInInspector]
    public string classe,tipo,cor;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().detectCollisions = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
