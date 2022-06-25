using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionScript : MonoBehaviour
{
    [HideInInspector]
    public bool temPeça,montando,peçaInteira;
    GameObject peçaReference;
    public GameObject peça;
    public string tipoPeça,classePeça,corPeça;
    Vector3 posCheckpoint;
    public GameObject reloginho;
    public AudioSource somParte,somBateu;
    // Start is called before the first frame update
    void Start()
    {
        temPeça = false;
        montando = false;
    }
    private void FixedUpdate() {
        if(temPeça == true && Input.GetKeyDown(KeyCode.Q))
        {
            peça.GetComponent<Rigidbody>().useGravity = true;
            peça.GetComponent<Rigidbody>().detectCollisions = true;
            peça.GetComponent<PartScript>().classe = classePeça;
            peça.GetComponent<PartScript>().tipo = tipoPeça;
            peça.GetComponent<PartScript>().cor = corPeça;
            peça.transform.parent = null;
            classePeça = "vazio";
            tipoPeça = "vazio";
            corPeça = "vazio";
            peça = null;
            temPeça = false;
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            montando = false;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
     {
        if(hit.gameObject.tag == "Elevator")
        {
            transform.parent = hit.transform;
        }
        if(hit.gameObject.tag == "Obstaculo"){
            MorreVolta();
            somBateu.Play();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("CaixaParte")){
            other.GetComponent<Renderer>().material = other.GetComponent<CaixaScript>().outlineMat;
        }
        if(other.CompareTag("Checkpoint")){
            posCheckpoint = transform.position;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Elevator")
        {
            transform.parent = GameObject.Find("Fase").transform;
        }
        if(other.CompareTag("MesaMontagem"))
        {
            montando = false;
            other.GetComponent<MontagemScript>().somMontagem.Stop();
        }
         if(other.CompareTag("CaixaParte")){
            other.GetComponent<Renderer>().material = other.GetComponent<CaixaScript>().normalMat;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(temPeça == false)
        {
            if(other.tag == "Parte" || other.tag == "ArmA" || other.tag == "ArmB" || other.tag == "LegA" || other.tag == "LegB")
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    peçaReference = other.gameObject;
                    peçaReference.transform.position = Vector3.zero;
                    peça = Instantiate(peçaReference,transform.GetChild(1).transform);
                    peça.GetComponent<Rigidbody>().useGravity = false;
                    peça.GetComponent<Rigidbody>().detectCollisions = false;
                    temPeça = true;
                    classePeça = other.GetComponent<PartScript>().classe;
                    tipoPeça = other.GetComponent<PartScript>().tipo;
                    corPeça = other.GetComponent<PartScript>().cor;
                    if(other.tag == "ArmA" || other.tag == "ArmB" || other.tag == "LegA" || other.tag == "LegB")
                    {
                        classePeça = "Completo";
                        tipoPeça = other.tag;
                    }
                    somParte.Play();
                    Destroy(other.gameObject);
                }
            }
            if(other.tag == "CaixaParte" && Input.GetKeyDown(KeyCode.E))
            {
                peçaReference = other.gameObject.GetComponent<CaixaScript>().minhaParte;
                peça = Instantiate(peçaReference,transform.GetChild(1).transform);
                temPeça = true;
                classePeça = other.GetComponent<CaixaScript>().classe;
                tipoPeça = other.GetComponent<CaixaScript>().tipo;
                corPeça = "Gray";
                somParte.Play();
            }
            if(other.gameObject.tag == "Paint" && Input.GetKeyDown(KeyCode.E))
            {
                if(other.GetComponent<PintarScript>().finishedPainting == true)
                {
                    peça = Instantiate(other.GetComponent<PintarScript>().peça,transform.GetChild(1).transform);
                    peça.SetActive(true);
                    temPeça = true;
                    tipoPeça = "Completo";
                    classePeça = "Colorida";
                    corPeça = other.GetComponent<PintarScript>().cor;
                    peça.GetComponent<PartScript>().cor = corPeça;
                    other.GetComponent<PintarScript>().RestartMachine();
                    somParte.Play();
                }
            }
            if(other.tag == "MesaMontagem" && Input.GetKey(KeyCode.E))
            {
                if(other.GetComponent<MontagemScript>().finishedBuild == false)
                {
                    other.GetComponent<MontagemScript>().MontaParte();
                    montando = true;
                }else{
                    peçaReference = other.GetComponent<MontagemScript>().partePronta;
                    peça = Instantiate(peçaReference,transform.GetChild(1).transform);
                    temPeça = true;
                    classePeça = "Completo";
                    tipoPeça = other.GetComponent<MontagemScript>().partePronta.tag;
                    other.GetComponent<MontagemScript>().ResetMachine();
                    montando = false;
                    somParte.Play();
                    peçaInteira = true;
                }
            }
        }else{
            if(other.gameObject.tag == "Paint" && Input.GetKeyDown(KeyCode.E))
            {
                if(peça != null && classePeça == "Completo" && other.GetComponent<PintarScript>().peça == null){
                    other.GetComponent<PintarScript>().PintaPeça(peça);
                    //peça.SetActive(false);
                    classePeça = "vazio";
                    tipoPeça = "vazio";
                    corPeça = "vazio";
                    Destroy(peça);
                    peça = null;
                    temPeça = false;
                    somParte.Play();
                }
            }
            if(other.gameObject.tag == "Paciente" && Input.GetKeyDown(KeyCode.E))
            {
                if(other.transform.parent.GetComponent<PacienteScript>().ConferePeça(peça.tag,corPeça) == true)
                {
                    Destroy(peça);
                    classePeça = "vazio";
                    tipoPeça = "vazio";
                    corPeça = "vazio";
                    peça = null;
                    temPeça = false;
                }
            }
            if(other.gameObject.tag == "Lixeira" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(peça);
                classePeça = "vazio";
                tipoPeça = "vazio";
                corPeça = "vazio";
                peça = null;
                temPeça = false;
            }
        }
    }
    void MorreVolta(){
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<PlayerMovemetScript>().enabled = false;
        reloginho.SetActive(true);
        Invoke("Volta",3f);
    }
    void Volta(){
        reloginho.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<PlayerMovemetScript>().enabled = true;
        GetComponent<CharacterController>().enabled = false;
        transform.position = posCheckpoint;
        GetComponent<CharacterController>().enabled = true;
    }
}
