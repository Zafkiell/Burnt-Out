using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodaMacaScript : MonoBehaviour
{
    public Transform[] slots;
    public GameObject[] macas;
    bool roda = false;
    public int delayRoda,delayTroca;
    bool tocasom;
    public AudioSource somRoda;
    // Start is called before the first frame update
    void Start()
    {
        macas[0].transform.position = slots[0].position;
        macas[1].transform.position = slots[1].position;
        macas[2].transform.position = slots[2].position;

        InvokeRepeating("RodaRoda",delayRoda,5f);
        InvokeRepeating("Troca",delayTroca,10f);

        tocasom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(roda)
        {
            if(!tocasom){
                somRoda.Play();
                tocasom = true;
            }
            macas[0].transform.position = Vector3.MoveTowards(macas[0].transform.position,slots[1].position,Time.deltaTime * 2f);
            macas[1].transform.position = Vector3.MoveTowards(macas[1].transform.position,slots[2].position,Time.deltaTime * 2f);
            macas[2].transform.position = slots[0].position;
        }
    }
    void RodaRoda()
    {
        roda = !roda;
        tocasom = false;
    }
    void Troca()
    {
        macas[3] = macas[2];
        macas[2] = macas[1];
        macas[1] = macas[0];
        macas[0] = macas[3];
    }
}
