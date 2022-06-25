using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SireneScript : MonoBehaviour
{
    public GameObject[] maca,pos;
    bool emergencia;
    public AudioSource somSirene;
    bool tocouSirene;
    // Start is called before the first frame update
    void Start()
    {
        tocouSirene = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<HUDManagerScript>().relógio.fillAmount <= 0.5f)
        {
            emergencia = true;
            if(tocouSirene == false){
                somSirene.Play();
                tocouSirene = true;
                Invoke("paraSirene",7f);
            }
        }
        if(emergencia)
        {
            maca[0].SetActive(true);
            maca[0].transform.position = Vector3.Lerp(maca[0].transform.position,pos[0].transform.position,0.05f);
            maca[1].SetActive(true);
            maca[1].transform.position = Vector3.Lerp(maca[1].transform.position,pos[1].transform.position,0.05f);

            if(Vector3.Distance(maca[0].transform.position,pos[0].transform.position) < 0.2f)
            {
                maca[0].transform.GetChild(2).gameObject.SetActive(false);
                maca[0].transform.GetChild(3).gameObject.SetActive(false);
            }
            if(Vector3.Distance(maca[1].transform.position,pos[1].transform.position) < 0.2f)
            {
                maca[1].transform.GetChild(2).gameObject.SetActive(false);
                maca[1].transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }
    void paraSirene(){
        somSirene.Stop();
    }
}
