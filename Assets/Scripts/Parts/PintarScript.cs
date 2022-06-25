using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PintarScript : MonoBehaviour
{
    //[HideInInspector]
    public GameObject peça;
    public string cor;
    public Slider progressBar;
    public Image alert,complete;
    public bool isPainting, finishedPainting;
    public Material[] paint;
    public float fillTime = 1.0f;
    float overtime;
    public AudioSource somPintar,somAlerta,somTermina;
    bool acabou;
    // Start is called before the first frame update
    void Start()
    {
        isPainting = false;
        acabou = false;
        if(gameObject.name == "RedPaint")cor = "Red";
        if(gameObject.name == "YellowPaint")cor = "Yellow";

        overtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPainting)
        {
            progressBar.value = Time.time;
        }
        if(progressBar.value == progressBar.maxValue)
        {
            isPainting = false;
            somPintar.Stop();
            complete.gameObject.SetActive(true);

            if(acabou == false)
            {
                somTermina.Play();
                acabou = true;
            }
            switch(peça.tag)
            {
                case "ArmA":
                    peça.transform.GetChild(0).GetComponent<Renderer>().material = paint[0];
                    peça.transform.GetChild(1).GetChild(0).GetComponent<Renderer>().material = paint[1];
                    peça.transform.GetChild(1).GetChild(1).GetComponent<Renderer>().material = paint[2];
                    peça.transform.GetChild(2).GetComponent<Renderer>().material = paint[3];
                break;
                case "ArmB":
                    peça.transform.GetChild(0).GetComponent<Renderer>().material = paint[4];
                    peça.transform.GetChild(1).GetChild(0).GetComponent<Renderer>().material = paint[4];
                    peça.transform.GetChild(1).GetChild(1).GetComponent<Renderer>().material = paint[4];
                    peça.transform.GetChild(2).GetComponent<Renderer>().material = paint[4];
                break;
                case "LegA":
                    peça.transform.GetChild(0).GetComponent<Renderer>().material = paint[5];
                    peça.transform.GetChild(1).GetComponent<Renderer>().material = paint[6];
                    peça.transform.GetChild(2).GetComponent<Renderer>().material = paint[7];
                break;
                case "LegB":
                    peça.transform.GetChild(0).GetComponent<Renderer>().material = paint[8];
                    peça.transform.GetChild(1).GetComponent<Renderer>().material = paint[8];
                    peça.transform.GetChild(2).GetComponent<Renderer>().material = paint[8];
                break;
            }
            finishedPainting = true;
            overtime += Time.deltaTime;

            if(overtime > 10f && overtime < 11f)
            {
                complete.gameObject.SetActive(false);
                alert.gameObject.SetActive(true);
            }
            if(overtime > 20)
            {
                progressBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color32(255,170,0,255);
                if(!somAlerta.isPlaying)somAlerta.Play();
            }
            if(overtime > 30f){
                somAlerta.Stop();
                RestartMachine();
            }
        }
        
    }
    public void PintaPeça(GameObject p)
    {
        peça = Instantiate(p);
        peça.SetActive(false);
        progressBar.gameObject.SetActive(true);

        progressBar.minValue = Time.time;
        progressBar.maxValue = Time.time + fillTime;

        isPainting = true;
        somPintar.Play();
    }
    public void RestartMachine()
    {
        progressBar.value = 0;
        isPainting = false;
        finishedPainting = false;
        progressBar.gameObject.SetActive(false);
        overtime = 0;
        alert.gameObject.SetActive(false);
        complete.gameObject.SetActive(false);
        progressBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color32(86,255,0,255);
        somPintar.Stop();
        acabou = false;
        Destroy(peça.gameObject);

        Invoke("DestroyDelay",2f);
    }
    void DestroyDelay()
    {
     Destroy(peça.gameObject);
    }
}
