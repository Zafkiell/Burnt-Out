using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCameraChangeScript : MonoBehaviour
{
    public GameObject[] cameras;
    bool control;
    // Start is called before the first frame update
    void Start()
    {
        control = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Troca"))
        {
            cameras[0].SetActive(control);
            cameras[1].SetActive(!control);
            //control = !control;
        }
    }
}
