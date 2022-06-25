using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pausePrefab;
    bool pausado;
    // Start is called before the first frame update
    void Start()
    {
        pausado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && pausado == false || Input.GetKeyDown(KeyCode.Escape) && pausado == false)
        {
            Time.timeScale = 0;
            pausePrefab.SetActive(true);
            pausado = true;
        }
        else if(Input.GetKeyDown(KeyCode.P) && pausado == true || Input.GetKeyDown(KeyCode.Escape) && pausado == true)
        {
            Time.timeScale = 1;
            pausePrefab.SetActive(false);
            pausado = false;
        }
    }
    void Inverte()
    {
        pausado = !pausado;
    }
}
