using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultadoScript : MonoBehaviour
{
    public Text pontos;
    public int pontoInt,meta1,meta2,meta3;
    public GameObject gear1,gear2,gear3,playerObj,continueButton,noMetaText;
    string rank;
    public string proxFase;
    public int essaFase;
    public AudioSource somGanha,somPerde;
    bool tocou = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rank = "";
        Invoke("PausaAnim",1f);
        Invoke("PlayAnim",2f);
    }
    private void OnEnable() {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(pontoInt < meta1 && tocou == false){
            somPerde.Play();
            tocou = true;
        }
        if(pontoInt >= meta1 && tocou == false){
            somGanha.Play();
            tocou = true;
        }

        if(pontoInt < meta1)
        {
            playerObj.SetActive(false);
            continueButton.SetActive(false);
            noMetaText.SetActive(true);
        }
        if(pontoInt >= meta1)
        {
            gear1.SetActive(true);
            rank = "bronze";
            noMetaText.SetActive(false);
            playerObj.SetActive(true);
            continueButton.SetActive(true);
        }
        if(pontoInt >= meta2)
        {
            gear2.SetActive(true);
            rank = "prata";
        }
        if(pontoInt >= meta3)
        {
            gear3.SetActive(true);
            rank = "ouro";
        }
        //iga trofeus
        FindObjectOfType<ManagerGeneralScript>().proximaTela = proxFase;
            if(essaFase > FindObjectOfType<ManagerGeneralScript>().fasesTerminadas){
        FindObjectOfType<ManagerGeneralScript>().fasesTerminadas = essaFase;
        }
        FindObjectOfType<ManagerGeneralScript>().ranking[essaFase - 1] = rank;
        FindObjectOfType<ManagerGeneralScript>().score[essaFase - 1] = pontoInt;
    }
    public void PausaAnim()
    {
        anim.speed = 0;
    }
    public void PlayAnim()
    {
        anim.speed = 1;
    }
    public void MudaTela(string fase)
    {
        SceneManager.LoadScene(fase);
        //if(fase == "Quarto")
        //{
            FindObjectOfType<ManagerGeneralScript>().proximaTela = proxFase;
            if(essaFase > FindObjectOfType<ManagerGeneralScript>().fasesTerminadas){
            FindObjectOfType<ManagerGeneralScript>().fasesTerminadas = essaFase;
            }
            FindObjectOfType<ManagerGeneralScript>().ranking[essaFase - 1] = rank;
            FindObjectOfType<ManagerGeneralScript>().score[essaFase - 1] = pontoInt;
        //}
    }
}
