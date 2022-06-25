using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteoroScript : MonoBehaviour
{
    public GameObject meteoro;
    bool chuvaMeteoro;
    public AudioSource somMeteoro;
    // Start is called before the first frame update
    void Start()
    {
        meteoro.SetActive(false);
        chuvaMeteoro  = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(chuvaMeteoro)
        {
            SpawnMeteoro();
            chuvaMeteoro = false;
        }

    }
    void SpawnMeteoro()
    {
        meteoro.SetActive(true);
        somMeteoro.Play();
        meteoro.transform.position = transform.position;
        Invoke("FimChuva",8f);
    }
    void FimChuva()
    {
        meteoro.SetActive(false);
        Invoke("LigaChuva",10f);
    }
    void LigaChuva()
    {
        chuvaMeteoro = true;
    }
}
