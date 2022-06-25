using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacienteScript : MonoBehaviour
{
    public string peçaCerta;
    public string corCerta;
    public Material[] minhaCor;
    public Slider HealthBar;
    public float tempoVida;
    public bool dissolve;
    public ParticleSystem faisca;
    bool morreu,ligaFaisca;

    //bool deietado;
    // Start is called before the first frame update
    void Start()
    {
        //deietado = true;
        tempoVida = 120f;
        dissolve = false;
        morreu = false;
        ligaFaisca = false;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value -= 1 / tempoVida * Time.deltaTime;

        if(HealthBar.value < 0.3f && !ligaFaisca)
        {
            faisca.Play();
            ligaFaisca = true;
        }
        if(HealthBar.value <= 0 && morreu == false)
        {
            if(FindObjectOfType<HUDManagerScript>().pontos > 0)
            {
                //FindObjectOfType<HUDManagerScript>().pontos -= 1;
            }
            transform.parent.GetComponent<PacienteManagerScript>().somMorre.Play();
            //transform.parent.GetComponent<PacienteManagerScript>().Proximo();
            dissolve = true;
            Invoke("Dissolve",2f);
            morreu = true;
            //Destroy(gameObject);
        }
    }
    public void AjustaProblema(string cor,string problema)
    {
        corCerta = cor;
        peçaCerta = problema;
    }
    public bool ConferePeça(string tipoPeça,string cor)
    {
        if(tipoPeça == peçaCerta && cor == corCerta)
        {
            FindObjectOfType<HUDManagerScript>().pontos += 1;
            transform.parent.GetComponent<PacienteManagerScript>().somSalva.Play();
            //transform.parent.GetComponent<PacienteManagerScript>().Proximo();
            dissolve = true;
            Invoke("Dissolve",2f);
            //Destroy(gameObject);
            return true;
        }else{
            return false;
        }
    }
    void Dissolve(){
        transform.parent.GetComponent<PacienteManagerScript>().Proximo();
        Destroy(gameObject);
    }
    void Morre(){
        
        transform.parent.GetComponent<PacienteManagerScript>().Proximo();
        Destroy(gameObject);
    }
}
