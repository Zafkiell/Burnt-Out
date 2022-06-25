using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Pixelplacement;

public class Cutscene3Script : MonoBehaviour
{
    public PostProcessVolume volume;
    Vignette vignette;
    Bloom bloom;
    LensDistortion lens;
    bool escurece;
    public AudioSource morrendo;
    public int desmaia = 0;
    bool ligaEfeito;

    // Start is called before the first frame update
    void Start()
    {
        vignette = ScriptableObject.CreateInstance<Vignette>();
        vignette.enabled.Override(true);
        vignette.intensity.Override(0);

        bloom = ScriptableObject.CreateInstance<Bloom>();
        bloom.enabled.Override(true);
        bloom.intensity.Override(1f);

        lens = ScriptableObject.CreateInstance<LensDistortion>();
        lens.enabled.Override(true);
        lens.intensity.Override(50f);

        volume = PostProcessManager.instance.QuickVolume(gameObject.layer,100f,  vignette);
        volume = PostProcessManager.instance.QuickVolume(gameObject.layer,100f,  bloom);

        ligaEfeito = false;
        Invoke("EfeitosCamera",5f);
        Invoke("ForcaDesmaia",30f);
    }

    // Update is called once per frame
    void Update()
    {
        if(escurece == true && ligaEfeito == false)
        {
            vignette.intensity.value += 1f * Time.deltaTime;
            bloom.intensity.value += 10f * Time.deltaTime;
            lens.intensity.value += 10f * Time.deltaTime;
            Invoke("Para",2f);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            if( other.GetComponent<PlayerMovemetScript>().VelocityMin > 1)other.GetComponent<PlayerMovemetScript>().VelocityMin -= 1f;
            other.GetComponent<PlayerMovemetScript>().VeclocityMax =  other.GetComponent<PlayerMovemetScript>().VelocityMin;
            if(escurece == false){
                desmaia+=1;
                escurece = true;
            }
            if(desmaia == 3)
            {
                other.GetComponent<PlayerMovemetScript>().enabled = false;
                Tween.Rotate(other.transform,new Vector3(90f,0,0),Space.Self,5f,0);
                morrendo.Play();
                Invoke("Desmaia",2f);
            }
        }
    }
     void ForcaDesmaia()
    {
        GameObject pl = FindObjectOfType<PlayerMovemetScript>().gameObject;
        pl.GetComponent<PlayerMovemetScript>().enabled = false;
        Tween.Rotate(pl.transform,new Vector3(90f,0,0),Space.Self,5f,0);
        morrendo.Play();
        Invoke("Desmaia",2f);
    }
    void Desmaia()
    {   
        escurece = false;
        RuntimeUtilities.DestroyProfile(volume.profile,true);
        RuntimeUtilities.DestroyVolume(volume,true,true);
        vignette.enabled.Override(false);
        bloom.enabled.Override(false);
        lens.enabled.Override(false);
        Destroy(gameObject);
        FindObjectOfType<LevelLoaderScript>().LoadNextLevel("CutsceneFinal");
    }
    void Para()
    {
        escurece = false;
        ligaEfeito = true;
    }
    void EfeitosCamera()
    {
        vignette.intensity.value += 1f * Time.deltaTime;
            bloom.intensity.value += 10f * Time.deltaTime;
            lens.intensity.value += 10f * Time.deltaTime;
            Invoke("Para",2f);
    }
}
