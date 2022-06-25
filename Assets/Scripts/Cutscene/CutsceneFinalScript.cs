using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFinalScript : MonoBehaviour
{
    public Animator aniCamera,animCena;
    public GameObject dialogo;
    public int delay,delayFim;
    public bool despausa;
    bool chamaFim;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PausaAnim",delay);
        despausa = false;
        chamaFim = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(despausa == true)
        {
            aniCamera.speed = 1;
            animCena.speed = 1;
            dialogo.SetActive(false);
            if(!chamaFim)
            {
                Invoke("PuxaCreditos",delayFim);
                chamaFim = true;
            }
        }
    }
    void PausaAnim ()
    {
        aniCamera.speed = 0;
        animCena.speed = 0;
        dialogo.SetActive(true);
    }
    void PuxaCreditos()
    {
        FindObjectOfType<LevelLoaderScript>().LoadNextLevel("Creditos");
    }
}
