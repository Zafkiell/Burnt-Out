using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VortexScrpt : MonoBehaviour
{
    bool ligado;
    Vector3 posInicial;
    float speed;
    public AudioSource somVortex;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        ligado = false;
        posInicial = transform.position;
        InvokeRepeating("PassaVortex",10f,60f);
        speed = -3f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0,0,-10f);

        if(ligado)
        {
            transform.position += new Vector3(-speed,0,0) * Time.deltaTime;
        }
        
    }
    void PassaVortex()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        ligado = true;
        somVortex.Play();
        FindObjectOfType<PlayerMovemetScript>().invertControl = true;
        Invoke("Estabiliza",15f);
        Invoke("Desliga",3f);
    }
    void Desliga()
    {
        ligado = false;
        GetComponent<SpriteRenderer>().enabled = false;
        transform.position = posInicial;
    }
    void Estabiliza(){
        FindObjectOfType<PlayerMovemetScript>().invertControl = false;
    }
}
