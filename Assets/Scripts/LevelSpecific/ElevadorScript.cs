using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorScript : MonoBehaviour
{
    public Vector3 posMax,posMin;
    public float speed;
    string controle;
    public AudioSource somElevador;
    bool sobedesce;
    // Start is called before the first frame update
    void Start()
    {
        //posMax = new Vector3(2.65f,4.2f,5f);
        //posMin = new Vector3(2.65f,-0.2f,5f);
        controle = "sobe";
        sobedesce = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(controle == "sobe")
        {
            //transform.position = Vector3.LerpUnclamped(transform.position,posMax,0.05f);
            transform.position += (posMax - transform.position).normalized * speed * Time.deltaTime;
        }
        if(controle == "desce")
        {
            //transform.position = Vector3.LerpUnclamped(transform.position,posMin,0.05f);
            transform.position += (posMin - transform.position).normalized * speed * Time.deltaTime;
        }
        if(Vector3.Distance(transform.position,posMax) < 0.5f)
        {
            if(sobedesce == false)
            {
                Invoke("Descendo",2f);
                sobedesce = true;
            }
            Parando();
        }
        if(Vector3.Distance(transform.position,posMin) < 0.5f)
        {
            if(sobedesce == false){
                Invoke("Subindo",2f);  
                sobedesce = true;
            }
            Parando();
        }
    }
    void Parando()
    {
        controle = "pare";
    }
    void Descendo()
    {
        controle ="desce";
        somElevador.Play();
        sobedesce = false;
    }
    void Subindo()
    {
        controle = "sobe";
        somElevador.Play();
        sobedesce = false;
    }

}
