using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneInsoniaScript : MonoBehaviour
{
    public Material matNormal,matOutline;
    public GameObject camera1,camera2,playerDeitado,canvasObj,luz;
    public Image fade;
    public Text relogio;
    bool deitado = false;
    bool desperta = false;
    bool mudacamera = false;
    int hora,minuto;
    public AudioSource alarme,tictac;
    public GameObject[] dialogos;
    // Start is called before the first frame update
    void Start()
    {
        hora = 22;
        minuto = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))tictac.Stop();

        if(deitado == true && Input.GetKey(KeyCode.E) && desperta == false)
        {
            //acelera o tempo
            minuto += 2;
            if(!tictac.isPlaying)tictac.Play();
            if(minuto > 59){
                minuto = 0;
                hora += 1;
                if(hora > 23){
                    hora = 0;
                }
            }
        }
        if(hora == 0){
            playerDeitado.transform.rotation =Quaternion.Slerp(transform.rotation,Quaternion.Euler(new Vector3(0,180f,90f)),1f);
            dialogos[0].SetActive(true);
            tictac.Stop();
        }
        if(hora == 3)
        {
            playerDeitado.transform.rotation =Quaternion.Slerp(transform.rotation,Quaternion.Euler(new Vector3(90f,0f,90f)),1f);
            dialogos[1].SetActive(true);
            tictac.Stop();
        }
        if(hora == 7)
        {
            playerDeitado.transform.rotation =Quaternion.Slerp(transform.rotation,Quaternion.Euler(new Vector3(90f,-180f,200f)),1f);
            dialogos[2].SetActive(true);
            tictac.Stop();
        }
        if(hora == 8 && mudacamera == false){
            desperta = true;
            tictac.Stop();
            alarme.gameObject.SetActive(true);
            playerDeitado.transform.rotation =Quaternion.Slerp(transform.rotation,Quaternion.Euler(new Vector3(-90f,-90f,0f)),1f);
            playerDeitado.GetComponent<PlayerAnimationScript>().expressao = 2;
            camera2.transform.position = new Vector3(8f,3f,-1f);
            Invoke("Termina",3f);
            mudacamera = true;
        }

        relogio.text = string.Format("{0:00}:{1:00}",hora,minuto);
    }
    void Termina()
    {
        camera2.transform.position = new Vector3(8.15f,2.02f,-0.85f);
        Invoke("Troca",3f);
    }
    void Troca()
    {
        FindObjectOfType<ManagerGeneralScript>().proximaTela = "Tela5";
        FindObjectOfType<LevelLoaderScript>().LoadNextLevel("Tela5");
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().material = matOutline;
        }
    }
    private void OnTriggerExit(Collider other) {
        GetComponent<MeshRenderer>().material = matNormal;
    }
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            FadeOut();
            camera1.SetActive(false);
            camera2.SetActive(true);
            other.gameObject.SetActive(false);
            GetComponent<MeshRenderer>().material = matNormal;
            Invoke("FadeIn",2f);
            Invoke("Delay",1f);
        }
    }
    void Delay()
    {
        playerDeitado.gameObject.SetActive(true);
        canvasObj.gameObject.SetActive(true);
        deitado = true;
        luz.GetComponent<Light>().range = 10f;
    }
    void FadeOut()
    {
        fade.gameObject.SetActive(true);
    }
    void FadeIn(){
        fade.GetComponent<Animator>().SetTrigger("End");
    }
}
