using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCreditos : MonoBehaviour
{
    public int velocidade;
    bool roda = true;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Para",74f);
    }

    // Update is called once per frame
    void Update()
    {
       if(roda)transform.position += new Vector3(0,velocidade,0) * Time.deltaTime;
       //print(Time.time); 
    }

    void Para()
    {
        roda = false;
    }
}
