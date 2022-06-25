using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManagerScript : MonoBehaviour
{
    public Text pontosText;
    [HideInInspector]
    public int pontos;
    public int meta;
    public Image relógio;
    public float tempoRelogio;
    public GameObject telaResultado,fase,hud;
    public AudioSource timerSound;
    public bool dialogoFimFase;
    bool rodouDialogo;
    public DialogoControlScript dialogo;
    // Start is called before the first frame update
    void Start()
    {
        rodouDialogo = false;
    }

    // Update is called once per frame
    void Update()
    {
        relógio.fillAmount -= 1 / tempoRelogio * Time.deltaTime;

        if(relógio.fillAmount <= 0.1f && relógio.fillAmount > 0.09f)
        {
            //if(!timerSound.isPlaying)timerSound.Play();
        }

        if(relógio.fillAmount <=0)
        {
            if(dialogoFimFase)
            {
                if(rodouDialogo == false)
                {
                    dialogo.gameObject.SetActive(true);
                    dialogo.emDialogo = true;
                    rodouDialogo = true;
                }
                if(dialogo.acabou == true)
                {
                    fase.SetActive(false);
                    hud.SetActive(false);
                    telaResultado.SetActive(true);
                    telaResultado.GetComponent<ResultadoScript>().pontoInt = pontos;
                    telaResultado.GetComponent<ResultadoScript>().pontos.text = "Pacientes: "+pontos;
                }
            }else{
            //FindObjectOfType<TrocaTelaScript>().TrocaTela(0);
            fase.SetActive(false);
            hud.SetActive(false);
            telaResultado.SetActive(true);
            telaResultado.GetComponent<ResultadoScript>().pontoInt = pontos;
            telaResultado.GetComponent<ResultadoScript>().pontos.text = "Pacientes: "+pontos;
            }
        }

        pontosText.text = "Pacientes: "+pontos+" / "+meta;
    }
    public void SkipTela()
    {
        pontos = 100;
        Time.timeScale = 1;
        relógio.fillAmount = 0;
    }
}
