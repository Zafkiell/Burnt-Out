using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacienteManagerScript : MonoBehaviour
{
    public GameObject[] pacientes;
    public GameObject pacientPoint,placa;
    public Sprite[] imagemPlaca;
    public float delayStart,delayProximo;

    //variaveis para definir paciente
    int geraCor,geraProblema;
    string cor,problema;
    public int corRange,problemaRange,vidaPaciente;
    public AudioSource somSalva,somMorre,somSpawn;
    Quaternion rotPaciente;
    [HideInInspector]
    public bool temPaciente;
    // Start is called before the first frame update
    void Start()
    {
        placa.GetComponent<Image>().sprite = imagemPlaca[0];
        Invoke("Spawn",delayStart);
        rotPaciente.eulerAngles = new Vector3(-90f,transform.rotation.z,transform.rotation.y);
        temPaciente = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Proximo()
    {
        placa.GetComponent<Image>().sprite = imagemPlaca[0];
        Invoke("Spawn", delayProximo);
    }
    void Spawn()
    {
        GameObject proximo = null;
        int var = Random.Range(0,2);

        somSpawn.Play();
        temPaciente = true;
        
        geraCor = Random.Range(0,corRange);
        if(geraCor == 0)
        {
            cor = "Red";
            geraProblema = Random.Range(0,problemaRange);
            if(geraProblema == 0)
            {
                problema = "ArmA";
                if(var == 0){proximo = Instantiate(pacientes[0],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[8],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[1];
            }
            if(geraProblema == 1)
            {
                problema = "LegA";
                if(var == 0){proximo = Instantiate(pacientes[0],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[4],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[9];
            }
            if(geraProblema == 2)
            {
                problema = "ArmB";
                if(var == 0){proximo = Instantiate(pacientes[4],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[12],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[5];
            }
            if(geraProblema == 3)
            {
                problema = "LegB";
                if(var == 0){proximo = Instantiate(pacientes[8],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[12],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[13];
            }
        }
        if(geraCor == 1)
        {
            cor = "Yellow";
            geraProblema = Random.Range(0,problemaRange);
            if(geraProblema == 0)
            {
                problema = "ArmA";
                if(var == 0){proximo = Instantiate(pacientes[1],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[9],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[2];
            }
            if(geraProblema == 1)
            {
                problema = "LegA";
                if(var == 0){proximo = Instantiate(pacientes[1],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[5],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[10];
            }
             if(geraProblema == 2)
            {
                problema = "ArmB";
                if(var == 0){proximo = Instantiate(pacientes[5],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[13],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[6];
            }
            if(geraProblema == 3)
            {
                problema = "LegB";
                if(var == 0){proximo = Instantiate(pacientes[9],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[13],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[14];
            }
        }
        if(geraCor == 2)
        {
            cor = "Blue";
            geraProblema = Random.Range(0,problemaRange);
            if(geraProblema == 0)
            {
                problema = "ArmA";
                if(var == 0){proximo = Instantiate(pacientes[2],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[10],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[3];
            }
            if(geraProblema == 1)
            {
                problema = "LegA";
                if(var == 0){proximo = Instantiate(pacientes[2],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[6],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[11];
            }
             if(geraProblema == 2)
            {
                problema = "ArmB";
                if(var == 0){proximo = Instantiate(pacientes[6],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[14],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[7];
            }
            if(geraProblema == 3)
            {
                problema = "LegB";
                if(var == 0){proximo = Instantiate(pacientes[10],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[14],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[15];
            }
        }
         if(geraCor == 3)
        {
            cor = "Purple";
            geraProblema = Random.Range(0,problemaRange);
            if(geraProblema == 0)
            {
                problema = "ArmA";
                if(var == 0){proximo = Instantiate(pacientes[3],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[11],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[4];
            }
            if(geraProblema == 1)
            {
                problema = "LegA";
                if(var == 0){proximo = Instantiate(pacientes[3],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[7],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[12];
            }
            if(geraProblema == 2)
            {
                problema = "ArmB";
                if(var == 0){proximo = Instantiate(pacientes[7],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[15],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[8];
            }
            if(geraProblema == 3)
            {
                problema = "LegB";
                if(var == 0){proximo = Instantiate(pacientes[11],pacientPoint.transform.position,rotPaciente);}
                if(var == 1){proximo = Instantiate(pacientes[15],pacientPoint.transform.position,rotPaciente);}
                proximo.transform.rotation = transform.rotation;
                proximo.transform.Rotate(-90f,0,0);
                proximo.transform.parent = transform;
                proximo.GetComponent<PacienteScript>().AjustaProblema(cor,problema);
                proximo.GetComponent<PacienteScript>().tempoVida = vidaPaciente;
                placa.GetComponent<Image>().sprite = imagemPlaca[16];
            }
        }
    }
}
