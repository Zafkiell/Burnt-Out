using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Forca",3f,30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Forca()
    {
        float speed = 6;
        GetComponent<Rigidbody>().velocity = Random.onUnitSphere * speed;
        Invoke("InvokeTroca",10f);
    }
    void InvokeTroca()
    {
        TrocaLugarScript[] tl = FindObjectsOfType(typeof (TrocaLugarScript)) as TrocaLugarScript[];

        foreach(TrocaLugarScript t in tl)
        {
            t.TrocaLugar();
        }
    }
}
