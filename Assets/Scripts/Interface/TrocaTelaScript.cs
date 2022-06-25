using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaTelaScript : MonoBehaviour
{
    public bool autoTroca;
    public float tempoTroca;
    public string trocaPraQual;
    // Start is called before the first frame update
    void Start()
    {
        if(autoTroca){
            Invoke("TrocaTelaTimer",tempoTroca);
        }
    }
    void TrocaTelaTimer(){
        SceneManager.LoadScene(trocaPraQual);
    }
    public void ChangeScene(string qualTela)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(qualTela);
    }

    public void TrocaTela(int indice)
    {
        switch(indice)
        {
            case 0:
                SceneManager.LoadScene("LevelSelect");
            break;
            case 1:
                SceneManager.LoadScene("Tela1");
            break;
            case 2:
                SceneManager.LoadScene("Tela2");
            break;
            case 3:
                SceneManager.LoadScene("Tela3");
            break;
            case 4:
                SceneManager.LoadScene("Tela4");
            break;
            case 5:
                SceneManager.LoadScene("Tela5");
            break;
            case 6:
                SceneManager.LoadScene("Tela6");
            break;
            case 7:
                SceneManager.LoadScene("Tela7");
            break;
            case 8:
                SceneManager.LoadScene("Tela8");
            break;
            case 9:
                SceneManager.LoadScene("Tela9");
            break;
             case 10:
                SceneManager.LoadScene("Tela10");
            break;
             case 11:
                SceneManager.LoadScene("Tela11");
            break;
            case 12:
                SceneManager.LoadScene("Tela12");
            break;
            case -1:
                Application.Quit();
            break;
            case -2:
                SceneManager.LoadScene("CutsceneInicial");
            break;
            case -3:
                SceneManager.LoadScene("CutsceneFinal");
            break;
            default:
            break;
        }
    }
}
