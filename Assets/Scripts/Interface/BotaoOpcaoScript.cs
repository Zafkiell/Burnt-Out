using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoOpcaoScript : MonoBehaviour
{
    public GameObject pausaOpcoes,menuOpcoes;
       public void MostraOpcoes()
    {
        pausaOpcoes.SetActive(false);
        menuOpcoes.SetActive(true);
    }
    public void EscondeOpcoes(){
        menuOpcoes.SetActive(false);
        pausaOpcoes.SetActive(true);
    }
}
