using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectScript : MonoBehaviour
{
    public GameObject[] botoes;
    int fases;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fases = FindObjectOfType<ManagerGeneralScript>().fasesTerminadas;
        
        if(fases > 0)
        {
            for(int i = 0; i < fases;i++)
            {
                botoes[i].SetActive(true);
            }
        }
    }
}
