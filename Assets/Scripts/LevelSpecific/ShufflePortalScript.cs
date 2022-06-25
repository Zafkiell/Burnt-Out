using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShufflePortalScript : MonoBehaviour
{
    public Transform[] portals;
    public Transform hold;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shuffle",5f,20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Shuffle()
    {
        hold.position = portals[0].position ;
        portals[0].position  = portals[1].position ;
        portals[1].position  = portals[2].position ;
        portals[2].position  = portals[3].position ;
        portals[3].position  = portals[4].position ;
        portals[4].position  = portals[5].position ;
        portals[5].position  = hold.position ;
    }
}
