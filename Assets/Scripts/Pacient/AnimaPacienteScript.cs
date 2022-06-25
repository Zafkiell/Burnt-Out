using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.UI;

public class AnimaPacienteScript : MonoBehaviour
{
    [Range(0,4)]
    public int parte;
    private void Awake() {
        //cabeça
        if(parte == 0)Tween.Rotate(transform,new Vector3(60f,0,0),Space.Self,5f,0,Tween.EaseOut,Tween.LoopType.PingPong);
        //Braco E
        if(parte == 1)Tween.Rotate(transform,new Vector3(0,10f,0),Space.Self,5f,3f,Tween.EaseWobble,Tween.LoopType.PingPong);
        //Braco D
        if(parte == 2)Tween.Rotate(transform,new Vector3(0,10f,0),Space.Self,5f,5f,Tween.EaseWobble,Tween.LoopType.PingPong);
        //Perna E
        if(parte == 3)Tween.Rotate(transform,new Vector3(15f,0,0),Space.Self,15f,2f,Tween.EaseWobble,Tween.LoopType.PingPong);
        //Parte D
        if(parte == 4)Tween.Rotate(transform,new Vector3(-15f,0,0),Space.Self,15f,6f,Tween.EaseWobble,Tween.LoopType.PingPong);
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
