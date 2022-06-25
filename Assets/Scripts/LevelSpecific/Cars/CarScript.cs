using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float velocidade;
    public GameObject[] carga;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0,3);
        if(index == 0)carga[0].gameObject.SetActive(true);
        if(index == 1)carga[1].gameObject.SetActive(true);
        if(index == 2)carga[2].gameObject.SetActive(true);
        Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * velocidade;
    }
}
