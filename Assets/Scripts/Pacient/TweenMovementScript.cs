using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class TweenMovementScript : MonoBehaviour
{
    public Spline mySpline;
    public float duration,delay;
    private void Awake() 
    {
        Tween.Spline(mySpline,transform,0,1,true,duration,delay,Tween.EaseLinear,Tween.LoopType.Loop);
    }
}
