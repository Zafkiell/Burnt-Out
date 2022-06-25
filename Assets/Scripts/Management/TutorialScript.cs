using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public DialogoControlScript[] tutorialMsg;
    public PintarScript[] maquinas;
    bool ensinaPeca,ensinaMonta,ensinaPintar,ensinaPaciente1,ensinaPaciente2,acabaTutorial;
    // Start is called before the first frame update
    void Start()
    {
        ensinaPeca = false;
        ensinaMonta = false;
        ensinaPintar = false;
        ensinaPaciente1 = false;
        ensinaPaciente2 = false;
        acabaTutorial = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<PacienteManagerScript>().temPaciente == true && ensinaPaciente1 == false)
        {
            tutorialMsg[1].gameObject.SetActive(true);
            ensinaPaciente1 = true;
        }
        if(FindObjectOfType<PlayerCollisionScript>().temPeça == true && ensinaPeca == false)
        {
            tutorialMsg[2].gameObject.SetActive(true);
            ensinaPeca = false;
        }
        if(FindObjectOfType<MontagemScript>().fullSlots == true && ensinaMonta == false)
        {
            tutorialMsg[3].gameObject.SetActive(true);
            ensinaMonta = true;
        }
         if(FindObjectOfType<PlayerCollisionScript>().peçaInteira == true && ensinaPintar == false)
        {
            tutorialMsg[4].gameObject.SetActive(true);
            ensinaPintar = true;
        }
         if(maquinas[0].finishedPainting == true || maquinas[1].finishedPainting == true)
        {
            if(ensinaPaciente2 == false)
            {
                tutorialMsg[5].gameObject.SetActive(true);
                ensinaPaciente2 = true;
            }
        }
        if(gameObject.GetComponent<HUDManagerScript>().pontos > 0 && acabaTutorial == false)
        {
            tutorialMsg[6].gameObject.SetActive(true);
            acabaTutorial = true;
        }
    }
}
