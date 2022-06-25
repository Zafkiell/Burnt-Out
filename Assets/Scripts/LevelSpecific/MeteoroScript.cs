using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroScript : MonoBehaviour
{
    float speed;
    Vector3 posInicial;
    
    void Awake()
    {
        posInicial = transform.position;
    }
    void Start()
    {
        
    }
    void OnEnable()
    {
        transform.position = posInicial;
        speed = Random.Range(5f,10f);
        transform.GetChild(0).transform.Rotate(Random.Range(0,360f),Random.Range(0,360f),Random.Range(0,360f));
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.GetChild(0).transform.Rotate(5f,2f,4f);
    }
}
