using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyScript : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        print(SceneManager.GetActiveScene().name);
        if(SceneManager.GetActiveScene().name == "Quarto")
        {
            Destroy(gameObject);
        }
    }
}
