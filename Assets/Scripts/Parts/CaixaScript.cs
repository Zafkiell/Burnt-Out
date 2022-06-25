using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaScript : MonoBehaviour
{
    public GameObject minhaParte;
    public GameObject[] listaPartes,listaHolograma;
    public Sprite[] listaSprites;
    public string[] classeLista,tipoLista;
    public string classe,tipo;
    public bool rotacionar;
    public int indice;
    public Material normalMat,outlineMat;
    // Start is called before the first frame update
    void Start()
    {
        //listaPartes = new GameObject[3];
        //listaMaterials = new Material[3];

        //rotaciona caixas
        if(rotacionar == true)
        {
           InvokeRepeating("RotacionaPartes",5f,5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RotacionaPartes()
    {
        minhaParte = listaPartes[indice];
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = listaSprites[indice];
        
        listaHolograma[indice].SetActive(true);
        for(int f = 0; f < listaHolograma.Length; f++)
        {
            if(listaHolograma[f] != listaHolograma[indice]){
                listaHolograma[f].SetActive(false);
            }
        }        

        classe = classeLista[indice];
        tipo = tipoLista[indice];

        indice++;
        if(indice > 5)indice = 0;
    }
}
