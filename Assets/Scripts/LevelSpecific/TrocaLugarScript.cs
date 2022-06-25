using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaLugarScript : MonoBehaviour
{
    public Transform[] posicao;
    int indice;

    void Start()
    {
        indice = 0;
    }
    public void TrocaLugar()
    {
        indice++;
        if(indice > posicao.Length)indice = 0;
        transform.position = posicao[indice].position;
    }
}
