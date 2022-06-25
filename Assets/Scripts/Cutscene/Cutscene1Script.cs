using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene1Script : MonoBehaviour
{
    public Material telaMat;
    public GameObject tela,telaTarget,dialogoControl;
    public AudioSource somNotifica,somVibra;
    bool liga,ligaDialogo;

    // Start is called before the first frame update
    void Start()
    {
        telaMat.SetColor("_EmissionColor",Color.white / 2f);
        Invoke("Notificacao",7f);
        liga = false;
        ligaDialogo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(liga)
        {
            tela.transform.position = Vector2.MoveTowards(tela.transform.position,telaTarget.transform.position,1000 * Time.deltaTime);
        }
    }
    public void Notificacao()
    {
        telaMat.SetColor("_EmissionColor",Color.white * 2f);
        somNotifica.Play();
        somVibra.Play();
    }
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            tela.SetActive(true);
            liga = true;
            if(!ligaDialogo)
            {
                Invoke("Pensar",3f);
                ligaDialogo = true;
            }
        }
    }
    void Pensar()
    {
        dialogoControl.SetActive(true);
        dialogoControl.GetComponent<DialogoControlScript>().emDialogo = true;
    }
}
