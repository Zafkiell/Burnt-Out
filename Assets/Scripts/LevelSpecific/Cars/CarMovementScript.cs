using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementScript : MonoBehaviour
{
    public GameObject carPrefab;
    GameObject car;
    public Transform[] pos;
    bool origem;
    // Start is called before the first frame update
    void Start()
    {
        origem = true;
        InvokeRepeating("SpawnCarros",2f,0.5f);
        InvokeRepeating("TrocaVia",7f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnCarros()
    {
        if(origem == true)
        {
            car = Instantiate(carPrefab,pos[0]);
            car.transform.parent = transform;
            car.transform.Rotate(0,-90f,0);
        }
        if(origem == false)
        {
            car = Instantiate(carPrefab,pos[1]);
            car.transform.parent = transform;
            car.transform.Rotate(0,-180f,0);
        }
    }
    void TrocaVia(){
        origem = !origem;
    }
}
