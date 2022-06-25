using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject[] cameras;
    public int indice;
    bool podemudar;
    public GameObject opcoesTitulo,opcoes,creditos,saveTitulo,saveButtons;
    GameObject cameraAtual;
    public AudioSource somPortaJogar;
    public GameObject quarto1,quarto2,quarto3,player1,player2,player3;
    public GameObject SceneLoader;
    public GameObject ConfirmaCancela,ConfirmaSair;
    // Start is called before the first frame update
    void Start()
    {
        indice = 0;
        cameraAtual = cameras[indice];
        podemudar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
            ConfirmaSair.SetActive(true);
        }

        //troca modelo quarto
        if(FindObjectOfType<ManagerGeneralScript>().fasesTerminadas < 5 || FindObjectOfType<ManagerGeneralScript>().fasesTerminadas >= 12)
        {
            quarto1.SetActive(true);
            quarto2.SetActive(false);
            quarto3.SetActive(false);

            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(false);
        }
        if(FindObjectOfType<ManagerGeneralScript>().fasesTerminadas >= 6 && FindObjectOfType<ManagerGeneralScript>().fasesTerminadas < 9)
        {
            quarto1.SetActive(false);
            quarto2.SetActive(true);
            quarto3.SetActive(false);

            player1.SetActive(false);
            player2.SetActive(true);
            player3.SetActive(false);
        }
        if(FindObjectOfType<ManagerGeneralScript>().fasesTerminadas >= 9 && FindObjectOfType<ManagerGeneralScript>().fasesTerminadas < 12)
        {
            quarto1.SetActive(false);
            quarto2.SetActive(false);
            quarto3.SetActive(true);

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(true);
        }

        //desliga outras cameras
        for(int f = 0; f < cameras.Length;f++)
        {
            if(cameras[f] != cameraAtual)
            {
                cameras[f].SetActive(false);
            }
        }
        //troca cameras
        if(podemudar)
        {
            if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(indice < cameras.Length-1){
                    indice += 1;
                cameraAtual = cameras[indice];
                }else{
                    cameraAtual = cameras[0];
                    indice = 0;
                }
                cameraAtual.SetActive(true);
            }
                if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(indice > 0){
                    indice -= 1;
                cameraAtual = cameras[indice];
                }else{
                    cameraAtual = cameras[cameras.Length -1];
                    indice = cameras.Length - 1;
                }
                cameraAtual.SetActive(true);
            }
        }

       switch(indice)
       {
           case 0:
                ConfirmaCancela.SetActive(false);
           break;
           case 1:
                ConfirmaCancela.SetActive(false);
           break;
           case 2:
                ConfirmaCancela.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                somPortaJogar.Play();
                //SceneManager.LoadScene(FindObjectOfType<ManagerGeneralScript>().proximaTela);
                SceneLoader.GetComponent<LevelLoaderScript>().LoadNextLevel(FindObjectOfType<ManagerGeneralScript>().proximaTela);
            }
           break;
           case 4:
           ConfirmaCancela.SetActive(true);
                if(Input.GetKey(KeyCode.E))
                {
                    saveTitulo.SetActive(false);
                    saveButtons.SetActive(true);
                }
                if(Input.GetKey(KeyCode.Q))
                {
                    saveTitulo.SetActive(true);
                    saveButtons.SetActive(false);
                }
           break;
           case 5:
           ConfirmaCancela.SetActive(true);
           if(Input.GetKeyDown(KeyCode.E)){
                opcoesTitulo.SetActive(false);
                opcoes.SetActive(true);
                podemudar = false;
            }
            if(Input.GetKeyDown(KeyCode.Q)){
                opcoesTitulo.SetActive(true);
                opcoes.SetActive(false);
                podemudar = true;
            }
           break;
           case 6:
           ConfirmaCancela.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
                creditos.SetActive(true);
                podemudar = false;
            }
            if(Input.GetKeyDown(KeyCode.Q)){
                creditos.SetActive(false);
                podemudar = true;
            }
           break;
       } 
    }
    public void VaiDireita()
    {
                if(indice < cameras.Length-1){
                    indice += 1;
                cameraAtual = cameras[indice];
                }else{
                    cameraAtual = cameras[0];
                    indice = 0;
                }
                cameraAtual.SetActive(true);
    }
    public void VaiEsquerda()
    {
                if(indice > 0){
                    indice -= 1;
                cameraAtual = cameras[indice];
                }else{
                    cameraAtual = cameras[cameras.Length -1];
                    indice = cameras.Length - 1;
                }
                cameraAtual.SetActive(true);
    }
    public void Cancela()
    {
        ConfirmaSair.SetActive(false);
    }
    public void Sair()
    {
        Application.Quit();
    }
}
