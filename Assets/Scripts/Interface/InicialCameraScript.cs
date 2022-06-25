using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicialCameraScript : MonoBehaviour
{
    public GameObject camera1,camera2;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TrocaCamera",2f);
    }
    void TrocaCamera()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
    }
}
