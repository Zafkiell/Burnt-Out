using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MontagemScript : MonoBehaviour
{
    public GameObject partePronta,slotA,slotB,slotC;
    public GameObject[] pecaPrefab,iconeObj;
    public Sprite[] icones;
    public string classePeça,tipoPeçaA,tipoPeçaB,tipoPeçaC; 
    [HideInInspector]
    public bool fullSlots;
    //Variaveis barra de progresso
    public Slider progressBar;
    public bool isBuilding,finishedBuild;
    public AudioSource somParte,somMontagem;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        classePeça = "vazio";
        tipoPeçaA = "vazio";
        tipoPeçaB = "vazio";
        tipoPeçaC = "vazio";
        fullSlots = false;

        iconeObj[0].GetComponent<SpriteRenderer>().sprite = null;
        iconeObj[1].GetComponent<SpriteRenderer>().sprite = null;
        iconeObj[2].GetComponent<SpriteRenderer>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(tipoPeçaA != "vazio" && tipoPeçaB != "vazio" && tipoPeçaC != "vazio")
        {
            fullSlots = true;
        }
        if(fullSlots)
        {
            progressBar.gameObject.SetActive(true);
        }
        if(progressBar.value == progressBar.maxValue)
        {
            finishedBuild = true;
            switch(classePeça)
            {
                case "ArmA":
                    partePronta = pecaPrefab[0];
                break;
                case "ArmB":
                    partePronta = pecaPrefab[1];
                break;
                case "LegA":
                    partePronta = pecaPrefab[2];
                break;
                case "LegB":
                    partePronta = pecaPrefab[3];
                break;
            }
        }
    }
    public void MontaParte()
    {
        if(fullSlots)
        {
            if(!somMontagem.isPlaying)somMontagem.Play();
            progressBar.value += speed;
        }
    }
    public void ResetMachine()
    {
        finishedBuild = false;
        classePeça = "vazio";
        tipoPeçaA = "vazio";
        tipoPeçaB = "vazio";
        tipoPeçaC = "vazio";
        partePronta = null;
        fullSlots = false;
        progressBar.value = 0;
        progressBar.gameObject.SetActive(false);
        iconeObj[0].GetComponent<SpriteRenderer>().sprite = null;
        iconeObj[1].GetComponent<SpriteRenderer>().sprite = null;
        iconeObj[2].GetComponent<SpriteRenderer>().sprite = null;
    }
    void LigaIcone(string tipo,int posicao)
    {
        switch(tipo)
        {
            case "HandA":
                iconeObj[posicao].GetComponent<SpriteRenderer>().sprite = icones[0];
            break;
            case "BraceA":
                iconeObj[posicao].GetComponent<SpriteRenderer>().sprite = icones[1];
            break;
            case "ShoulderA":
                iconeObj[posicao].GetComponent<SpriteRenderer>().sprite = icones[2];
            break;
            case "HandB":
                iconeObj[posicao].GetComponent<SpriteRenderer>().sprite = icones[3];
            break;
            case "BraceB":
                iconeObj[posicao].GetComponent<SpriteRenderer>().sprite = icones[4];
            break;
            case "ShoulderB":
                iconeObj[posicao].GetComponent<SpriteRenderer>().sprite = icones[5];
            break;
            case "FootA":
                iconeObj[posicao].GetComponent<SpriteRenderer>().sprite = icones[6];
            break;
            case "KneecapA":
                iconeObj[posicao].GetComponent<SpriteRenderer>().sprite = icones[7];
            break;
            case "HipA":
                iconeObj[posicao].GetComponent<SpriteRenderer>().sprite = icones[8];
            break;
            case "FootB":
                iconeObj[posicao].GetComponent<SpriteRenderer>().sprite = icones[9];
            break;
            case "KneecapB":
                iconeObj[posicao].GetComponent<SpriteRenderer>().sprite = icones[10];
            break;
            case "HipB":
                iconeObj[posicao].GetComponent<SpriteRenderer>().sprite = icones[11];
            break;
        }
    }
    void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            if(other.gameObject.GetComponent<PlayerCollisionScript>().temPeça)
            {
                if(classePeça == "vazio" && other.GetComponent<PlayerCollisionScript>().classePeça != "Completo")
                {
                    //slotA = Instantiate(other.gameObject.GetComponent<PlayerCollisionScript>().peça);
                    //slotA.SetActive(false);
                    classePeça = other.GetComponent<PlayerCollisionScript>().classePeça;
                    tipoPeçaA = other.GetComponent<PlayerCollisionScript>().tipoPeça;
                    other.GetComponent<PlayerCollisionScript>().classePeça = "vazio";
                    other.GetComponent<PlayerCollisionScript>().tipoPeça = "vazio";
                    other.GetComponent<PlayerCollisionScript>().corPeça = "vazio";
                    LigaIcone(tipoPeçaA,0);
                    Destroy(other.GetComponent<PlayerCollisionScript>().peça);
                    other.GetComponent<PlayerCollisionScript>().peça = null;
                    other.GetComponent<PlayerCollisionScript>().temPeça = false;
                    somParte.Play();
                }else if(other.GetComponent<PlayerCollisionScript>().classePeça == classePeça && other.GetComponent<PlayerCollisionScript>().tipoPeça != tipoPeçaA){
                    if(tipoPeçaB == "vazio"){
                        //slotB = Instantiate(other.gameObject.GetComponent<PlayerCollisionScript>().peça);
                        //slotB.SetActive(false);
                        tipoPeçaB = other.gameObject.GetComponent<PlayerCollisionScript>().tipoPeça;
                        LigaIcone(tipoPeçaB,1);
                        Destroy(other.gameObject.GetComponent<PlayerCollisionScript>().peça);
                        other.gameObject.GetComponent<PlayerCollisionScript>().peça = null;
                        other.gameObject.GetComponent<PlayerCollisionScript>().temPeça = false;
                        other.GetComponent<PlayerCollisionScript>().classePeça = "vazio";
                        other.GetComponent<PlayerCollisionScript>().tipoPeça = "vazio";
                        other.GetComponent<PlayerCollisionScript>().corPeça = "vazio";
                        somParte.Play();
                    }else if(other.GetComponent<PlayerCollisionScript>().tipoPeça != tipoPeçaB){
                        //slotC = Instantiate(other.gameObject.GetComponent<PlayerCollisionScript>().peça);
                        //slotC.SetActive(false);
                        tipoPeçaC = other.gameObject.GetComponent<PlayerCollisionScript>().tipoPeça;
                        LigaIcone(tipoPeçaC,2);
                        Destroy(other.gameObject.GetComponent<PlayerCollisionScript>().peça);
                        other.gameObject.GetComponent<PlayerCollisionScript>().peça = null;
                        other.gameObject.GetComponent<PlayerCollisionScript>().temPeça = false;
                        other.GetComponent<PlayerCollisionScript>().classePeça = "vazio";
                        other.GetComponent<PlayerCollisionScript>().tipoPeça = "vazio";
                        other.GetComponent<PlayerCollisionScript>().corPeça = "vazio";
                        somParte.Play();
                    }
                }
            }
        }   
    }
}
