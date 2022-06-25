using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGeneralScript : MonoBehaviour
{
    public string proximaTela;
    public int fasesTerminadas;
    public int[] score;
    public string[] ranking;

    private void Awake() {
        score = new int[12];
        ranking = new string[12];
        DontDestroyOnLoad(gameObject);
        FindObjectOfType<SaveGameScript>().LoadGame();
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
