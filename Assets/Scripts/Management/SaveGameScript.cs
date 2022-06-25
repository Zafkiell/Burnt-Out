using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameScript : MonoBehaviour
{
    int[] saveScore;
    string[] saveRank;
    int saveFaseCompleta;
    string saveProximaFase;
    public Text feedback;
    // Start is called before the first frame update
    void Awake()
    {
        saveScore = new int[12];
        saveRank = new string[12];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveGame()
    {
        saveFaseCompleta = FindObjectOfType<ManagerGeneralScript>().fasesTerminadas;
        saveProximaFase = FindObjectOfType<ManagerGeneralScript>().proximaTela;
        for(int i = 0; i < saveScore.Length;i++)
        {
            saveScore[i] = FindObjectOfType<ManagerGeneralScript>().score[i];
            saveRank[i] = FindObjectOfType<ManagerGeneralScript>().ranking[i];
        }

        PlayerPrefs.SetInt("FasesCompletas",saveFaseCompleta);
        PlayerPrefs.SetString("ProximaFase",saveProximaFase);
        PlayerPrefs.SetInt("Score1",saveScore[0]);
        PlayerPrefs.SetInt("Score2",saveScore[1]);
        PlayerPrefs.SetInt("Score3",saveScore[2]);
        PlayerPrefs.SetInt("Score4",saveScore[3]);
        PlayerPrefs.SetInt("Score5",saveScore[4]);
        PlayerPrefs.SetInt("Score6",saveScore[5]);
        PlayerPrefs.SetInt("Score7",saveScore[6]);
        PlayerPrefs.SetInt("Score8",saveScore[7]);
        PlayerPrefs.SetInt("Score9",saveScore[8]);
        PlayerPrefs.SetInt("Score10",saveScore[9]);
        PlayerPrefs.SetInt("Score11",saveScore[10]);
        PlayerPrefs.SetInt("Score12",saveScore[11]);

        PlayerPrefs.SetString("Rank1",saveRank[0]);
        PlayerPrefs.SetString("Rank2",saveRank[1]);
        PlayerPrefs.SetString("Rank3",saveRank[2]);
        PlayerPrefs.SetString("Rank4",saveRank[3]);
        PlayerPrefs.SetString("Rank5",saveRank[4]);
        PlayerPrefs.SetString("Rank6",saveRank[5]);
        PlayerPrefs.SetString("Rank7",saveRank[6]);
        PlayerPrefs.SetString("Rank8",saveRank[7]);
        PlayerPrefs.SetString("Rank9",saveRank[8]);
        PlayerPrefs.SetString("Rank10",saveRank[9]);
        PlayerPrefs.SetString("Rank11",saveRank[10]);
        PlayerPrefs.SetString("Rank12",saveRank[11]);

        PlayerPrefs.Save();
        feedback.text = "Save Completo";
        Invoke("DesligaFeedback",3f);
    }

    public void LoadGame()
    {
        if(PlayerPrefs.HasKey("Score1"))
        {
            saveFaseCompleta = PlayerPrefs.GetInt("FasesCompletas");
            FindObjectOfType<ManagerGeneralScript>().fasesTerminadas = saveFaseCompleta;
            saveProximaFase = PlayerPrefs.GetString("ProximaFase");
            FindObjectOfType<ManagerGeneralScript>().proximaTela = saveProximaFase;
            FindObjectOfType<ManagerGeneralScript>().score[0] = PlayerPrefs.GetInt("Score1");
            FindObjectOfType<ManagerGeneralScript>().score[1] = PlayerPrefs.GetInt("Score2");
            FindObjectOfType<ManagerGeneralScript>().score[2] = PlayerPrefs.GetInt("Score3");
            FindObjectOfType<ManagerGeneralScript>().score[3] = PlayerPrefs.GetInt("Score4");
            FindObjectOfType<ManagerGeneralScript>().score[4] = PlayerPrefs.GetInt("Score5");
            FindObjectOfType<ManagerGeneralScript>().score[5] = PlayerPrefs.GetInt("Score6");
            FindObjectOfType<ManagerGeneralScript>().score[6] = PlayerPrefs.GetInt("Score7");
            FindObjectOfType<ManagerGeneralScript>().score[7] = PlayerPrefs.GetInt("Score8");
            FindObjectOfType<ManagerGeneralScript>().score[8] = PlayerPrefs.GetInt("Score9");
            FindObjectOfType<ManagerGeneralScript>().score[9] = PlayerPrefs.GetInt("Score10");
            FindObjectOfType<ManagerGeneralScript>().score[10] = PlayerPrefs.GetInt("Score11");
            FindObjectOfType<ManagerGeneralScript>().score[11] = PlayerPrefs.GetInt("Score12");

            FindObjectOfType<ManagerGeneralScript>().ranking[0] = PlayerPrefs.GetString("Rank1");
            FindObjectOfType<ManagerGeneralScript>().ranking[1] = PlayerPrefs.GetString("Rank2");
            FindObjectOfType<ManagerGeneralScript>().ranking[2] = PlayerPrefs.GetString("Rank3");
            FindObjectOfType<ManagerGeneralScript>().ranking[3] = PlayerPrefs.GetString("Rank4");
            FindObjectOfType<ManagerGeneralScript>().ranking[4] = PlayerPrefs.GetString("Rank5");
            FindObjectOfType<ManagerGeneralScript>().ranking[5] = PlayerPrefs.GetString("Rank6");
            FindObjectOfType<ManagerGeneralScript>().ranking[6] = PlayerPrefs.GetString("Rank7");
            FindObjectOfType<ManagerGeneralScript>().ranking[7] = PlayerPrefs.GetString("Rank8");
            FindObjectOfType<ManagerGeneralScript>().ranking[8] = PlayerPrefs.GetString("Rank9");
            FindObjectOfType<ManagerGeneralScript>().ranking[9] = PlayerPrefs.GetString("Rank10");
            FindObjectOfType<ManagerGeneralScript>().ranking[10] = PlayerPrefs.GetString("Rank11");
            FindObjectOfType<ManagerGeneralScript>().ranking[11] = PlayerPrefs.GetString("Rank12");
            Debug.Log("Load game");

            if(feedback != null){
                feedback.text = "Carregamento Completo";
                Invoke("DesligaFeedback",3f);
            }
        }else{
            saveFaseCompleta = 0;
            saveProximaFase = "Contexto";
            saveScore[0] = 0;
            saveScore[1] = 0;
            saveScore[2] = 0;
            saveScore[3] = 0;
            saveScore[4] = 0;
            saveScore[5] = 0;
            saveScore[6] = 0;
            saveScore[7] = 0;
            saveScore[8] = 0;
            saveScore[9] = 0;
            saveScore[10] = 0;
            saveScore[11] = 0;

            saveRank[0] = "";
            saveRank[1] = "";
            saveRank[2] = "";
            saveRank[3] = "";
            saveRank[4] = "";
            saveRank[5] = "";
            saveRank[6] = "";
            saveRank[7] = "";
            saveRank[8] = "";
            saveRank[9] = "";
            saveRank[10] = "";
            saveRank[11] = "";

            if(feedback != null){
                feedback.text = "Save não encontrado";
                Invoke("DesligaFeedback",3f);
            }
        }
    }

    public void ResetData(){
        PlayerPrefs.DeleteAll();
        saveFaseCompleta = 0;
        saveProximaFase = "Contexto";
        saveScore[0] = 0;
        saveScore[1] = 0;
        saveScore[2] = 0;
        saveScore[3] = 0;
        saveScore[4] = 0;
        saveScore[5] = 0;
        saveScore[6] = 0;
        saveScore[7] = 0;
        saveScore[8] = 0;
        saveScore[9] = 0;
        saveScore[10] = 0;
        saveScore[11] = 0;
        saveRank[0] = "";
            saveRank[1] = "";
            saveRank[2] = "";
            saveRank[3] = "";
            saveRank[4] = "";
            saveRank[5] = "";
            saveRank[6] = "";
            saveRank[7] = "";
            saveRank[8] = "";
            saveRank[9] = "";
            saveRank[10] = "";
            saveRank[11] = "";
        feedback.text = "ResetCompleto";
        Invoke("DesligaFeedback",3f);
    }
    void DesligaFeedback(){
        feedback.text = "";
    }
}
