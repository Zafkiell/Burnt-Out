using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class DoorControlScript : MonoBehaviour
{
    public GameObject[] porta;
    bool change;
    public AudioSource somPorta;
    // Start is called before the first frame update
    void Start()
    {
        change = false;
        InvokeRepeating("AbreFecha",17f,17f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AbreFecha()
    {
        if(!change)
        {
            //porta[0].transform.position = new Vector3(porta[0].transform.position.x,-1.1f,porta[0].transform.position.z);
            Tween.Position(porta[0].transform,new Vector3(porta[0].transform.position.x,-1.1f,porta[0].transform.position.z),1f,0);
            //porta[1].transform.position = new Vector3(porta[1].transform.position.x,1.2f,porta[1].transform.position.z);
            Tween.Position(porta[1].transform,new Vector3(porta[1].transform.position.x,1.2f,porta[1].transform.position.z),1f,0);
            change = true;
        }else
        {
            //porta[0].transform.position = new Vector3(porta[0].transform.position.x,1.2f,porta[0].transform.position.z);
            Tween.Position(porta[0].transform,new Vector3(porta[0].transform.position.x,1.2f,porta[0].transform.position.z),1f,0);
            //porta[1].transform.position = new Vector3(porta[1].transform.position.x,-1.1f,porta[1].transform.position.z);
            Tween.Position(porta[1].transform,new Vector3(porta[1].transform.position.x,-1.1f,porta[1].transform.position.z),1f,0);
            change = false;  
        }
        somPorta.Play();
    }
    
}
