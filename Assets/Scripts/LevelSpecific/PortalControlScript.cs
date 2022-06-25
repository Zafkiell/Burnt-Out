using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControlScript : MonoBehaviour
{
    public Transform destination;
    static bool canTeleport;
    public AudioSource somTeleporta;
    void Start() {
        canTeleport = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && canTeleport)
        {
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = destination.position;
            somTeleporta.Play();
            other.GetComponent<CharacterController>().enabled = true;
            canTeleport = false;
            Invoke("Desliga",0.3f);
        }
    }
    void Desliga()
    {
        canTeleport = true;
    }
}
