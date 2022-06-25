using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaCamera : MonoBehaviour
{
    public GameObject camPerto,camLonge;
    bool control;
    // Start is called before the first frame update
    void Start()
    {
        control = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            camPerto.SetActive(control);
            camLonge.SetActive(!control);
            control = !control;
        }
    }
}
