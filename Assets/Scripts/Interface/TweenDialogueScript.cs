using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class TweenDialogueScript : MonoBehaviour
{
    public int TweenType;
    public Transform target;
    //public Spline mySpline;
    //public Transform myObject;
    //public float posS,posF;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake() 
    {
        if(TweenType == 0)Tween.Position(transform,target.transform.position,2f,0f,null,Tween.LoopType.None,null,null,false);
        //if(TweenType == 1)Tween.Spline(mySpline,myObject,posS,posF,true,40f,0,Tween.EaseOut,Tween.LoopType.Loop);
    }
}
