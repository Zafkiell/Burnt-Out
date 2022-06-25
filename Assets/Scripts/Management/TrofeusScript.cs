using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrofeusScript : MonoBehaviour
{
    public GameObject[] retratos,trofeus,baseTrofeus;
    public Material[] bronze,prata,ouro;
    int indice;
    public Text estanteText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        indice = FindObjectOfType<ManagerGeneralScript>().fasesTerminadas;
        
        if(indice > 0)
        {
            estanteText.text = "Memórias e Troféus";
            retratos[0].SetActive(false);
            trofeus[0].SetActive(true);
            if(FindObjectOfType<ManagerGeneralScript>().ranking[0] == "bronze"){
                baseTrofeus[0].GetComponent<Renderer>().material = bronze[0];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[0] == "prata"){
                baseTrofeus[0].GetComponent<Renderer>().material = prata[0];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[0] == "ouro"){
                baseTrofeus[0].GetComponent<Renderer>().material = ouro[0];
            }
        }
        if(indice > 1)
        {
            retratos[0].SetActive(false);
            trofeus[1].SetActive(true);
            if(FindObjectOfType<ManagerGeneralScript>().ranking[1] == "bronze"){
                baseTrofeus[1].GetComponent<Renderer>().material = bronze[0];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[1] == "prata"){
                baseTrofeus[1].GetComponent<Renderer>().material = prata[0];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[1] == "ouro"){
                baseTrofeus[1].GetComponent<Renderer>().material = ouro[0];
            }
        }
        if(indice > 2)
        {
            retratos[1].SetActive(false);
            trofeus[2].SetActive(true);
            if(FindObjectOfType<ManagerGeneralScript>().ranking[2] == "bronze"){
                baseTrofeus[2].GetComponent<Renderer>().material = bronze[0];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[2] == "prata"){
                baseTrofeus[2].GetComponent<Renderer>().material = prata[0];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[2] == "ouro"){
                baseTrofeus[2].GetComponent<Renderer>().material = ouro[0];
            }
        }
        if(indice > 3)
        {
            retratos[1].SetActive(false);
            trofeus[3].SetActive(true);
            if(FindObjectOfType<ManagerGeneralScript>().ranking[3] == "bronze"){
                baseTrofeus[3].GetComponent<Renderer>().material = bronze[1];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[3] == "prata"){
                baseTrofeus[3].GetComponent<Renderer>().material = prata[1];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[3] == "ouro"){
                baseTrofeus[3].GetComponent<Renderer>().material = ouro[1];
            }
        }
        if(indice > 4)
        {
            retratos[2].SetActive(false);
            trofeus[4].SetActive(true);
            if(FindObjectOfType<ManagerGeneralScript>().ranking[4] == "bronze"){
                baseTrofeus[4].GetComponent<Renderer>().material = bronze[1];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[4] == "prata"){
                baseTrofeus[4].GetComponent<Renderer>().material = prata[1];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[4] == "ouro"){
                baseTrofeus[4].GetComponent<Renderer>().material = ouro[1];
            }
        }
        if(indice > 5)
        {
            estanteText.text = "Troféus e Memórias";
            retratos[2].SetActive(false);
            trofeus[5].SetActive(true);
            if(FindObjectOfType<ManagerGeneralScript>().ranking[5] == "bronze"){
                baseTrofeus[5].GetComponent<Renderer>().material = bronze[2];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[5] == "prata"){
                baseTrofeus[5].GetComponent<Renderer>().material = prata[2];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[5] == "ouro"){
                baseTrofeus[5].GetComponent<Renderer>().material = ouro[2];
            }
        }
        if(indice > 6)
        {
            retratos[3].SetActive(false);
            trofeus[6].SetActive(true);
            if(FindObjectOfType<ManagerGeneralScript>().ranking[6] == "bronze"){
                baseTrofeus[6].GetComponent<Renderer>().material = bronze[3];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[6] == "prata"){
                baseTrofeus[6].GetComponent<Renderer>().material = prata[3];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[6] == "ouro"){
                baseTrofeus[6].GetComponent<Renderer>().material = ouro[3];
            }
        }
        if(indice > 7)
        {
            retratos[3].SetActive(false);
            trofeus[7].SetActive(true);
            if(FindObjectOfType<ManagerGeneralScript>().ranking[7] == "bronze"){
                baseTrofeus[7].GetComponent<Renderer>().material = bronze[4];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[7] == "prata"){
                baseTrofeus[7].GetComponent<Renderer>().material = prata[4];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[7] == "ouro"){
                baseTrofeus[7].GetComponent<Renderer>().material = ouro[4];
            }
        }
        if(indice > 8)
        {
            retratos[4].SetActive(false);
            trofeus[8].SetActive(true);
            if(FindObjectOfType<ManagerGeneralScript>().ranking[8] == "bronze"){
                baseTrofeus[8].GetComponent<Renderer>().material = bronze[5];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[8] == "prata"){
                baseTrofeus[8].GetComponent<Renderer>().material = prata[5];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[8] == "ouro"){
                baseTrofeus[8].GetComponent<Renderer>().material = ouro[5];
            }
        }
        if(indice > 9)
        {
            estanteText.text = "Troféus";
            retratos[4].SetActive(false);
                trofeus[9].SetActive(true);
                if(FindObjectOfType<ManagerGeneralScript>().ranking[9] == "bronze"){
                    baseTrofeus[9].GetComponent<Renderer>().material = bronze[6];
                }
                if(FindObjectOfType<ManagerGeneralScript>().ranking[9] == "prata"){
                    baseTrofeus[9].GetComponent<Renderer>().material = prata[6];
                }
                if(FindObjectOfType<ManagerGeneralScript>().ranking[9] == "ouro"){
                    baseTrofeus[9].GetComponent<Renderer>().material = ouro[6];
                }
        }
        if(indice > 10)
        {
            retratos[5].SetActive(false);
            trofeus[10].SetActive(true);
            if(FindObjectOfType<ManagerGeneralScript>().ranking[10] == "bronze"){
                baseTrofeus[10].GetComponent<Renderer>().material = bronze[7];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[10] == "prata"){
                baseTrofeus[10].GetComponent<Renderer>().material = prata[7];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[10] == "ouro"){
                baseTrofeus[10].GetComponent<Renderer>().material = ouro[7];
            }
        }
        if(indice > 11)
        {
            retratos[5].SetActive(false);
            trofeus[11].SetActive(true);
            if(FindObjectOfType<ManagerGeneralScript>().ranking[11] == "bronze"){
                baseTrofeus[11].GetComponent<Renderer>().material = bronze[8];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[11] == "prata"){
                baseTrofeus[11].GetComponent<Renderer>().material = prata[8];
            }
            if(FindObjectOfType<ManagerGeneralScript>().ranking[11] == "ouro"){
                baseTrofeus[11].GetComponent<Renderer>().material = ouro[8];
            }
        }
    }
}
