using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNave : MonoBehaviour
{
    public Transform[] waypoint;
    int indice;
    public int speed;
    bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        indice = 0;
        canMove = false;
        InvokeRepeating("Liga",10f,40f);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if(canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position,waypoint[indice].position,step);
            if(transform.position == waypoint[indice].position)
            {
                indice++;
                if(indice >= waypoint.Length)indice = 0;
            }
        }
    }
    void Liga()
    {
        canMove = true;
        Invoke("Desliga",4.5f);
    }
    void Desliga()
    {
        canMove = false;
    }
}
