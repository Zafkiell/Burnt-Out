using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CooldownScript : MonoBehaviour
{
    float tempo;
    float timer;
    
    private void OnEnable() 
    {
        tempo = 4;
    }
    // Update is called once per frame
    void Update()
    {
        tempo -= Time.deltaTime;
        timer = (int)tempo;
        GetComponent<Text>().text = timer.ToString();
    }
}
