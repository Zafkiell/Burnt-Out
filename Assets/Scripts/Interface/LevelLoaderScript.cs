using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    public bool autoTroca;
    public string qualTela;
    public int delayTroca;

    // Start is called before the first frame update
    void Start()
    {
        if(autoTroca)Invoke("AutoTroca",delayTroca);
    }
    void AutoTroca()
    {
         StartCoroutine(LoadLevel(qualTela));
    }
    public void LoadNextLevel(string index)
    {
        StartCoroutine(LoadLevel(index));
    }
    IEnumerator LoadLevel(string levelIndex)
    {
        //play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        Time.timeScale = 1;
        SceneManager.LoadScene(levelIndex);
    }
}
