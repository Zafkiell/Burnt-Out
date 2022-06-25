using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoControlScript : MonoBehaviour
{
    public int numeroDialogos;
    int dialogoatual;
    public GameObject[] dialogos;
    public bool emDialogo,cutscene1,cutsceneFinal;
    [HideInInspector]
    public bool acabou;
    public bool delayStart;
    // Start is called before the first frame update
    void Start()
    {
        dialogoatual = 0;
        acabou = false;
        if(delayStart)Invoke("ligaDialogo",2f);
    }
    void ligaDialogo()
    {
        emDialogo = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(emDialogo == true)
        {
            Time.timeScale = 0;
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(dialogoatual < numeroDialogos -1)
                {
                    dialogos[dialogoatual].SetActive(false);
                    dialogos[dialogoatual + 1].SetActive(true);
                    dialogoatual+=1;
                }else{
                    dialogos[dialogoatual].SetActive(false);
                    emDialogo = false;
                    Time.timeScale = 1;
                    acabou = true;
                    if(cutscene1)
                    {
                        FindObjectOfType<ManagerGeneralScript>().proximaTela = "Tela9";
                        Invoke("ChamaTrocaTela",2f);
                    }
                    if(cutsceneFinal)
                    {
                        FindObjectOfType<CutsceneFinalScript>().despausa = true;
                    }
                }
            }
        }
    }
    void ChamaTrocaTela()
    {
        FindObjectOfType<LevelLoaderScript>().LoadNextLevel("Tela9");
    }
}
