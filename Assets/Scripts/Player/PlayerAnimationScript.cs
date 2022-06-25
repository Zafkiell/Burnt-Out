using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    Animator anim;
    enum Estados{IDLE,ANDA,ANDA2,CORRE,SEGURA,MONTA,CURTO};
    Estados estados;
    public Material rosto;
    Color blue,red,yellow,purple;
    [Range(0,3)]
    public int expressao;
    int expressaoAtual;
    public bool CutsceneEndLevel,curtoCircuito;
    bool tendoCurto;
    public AudioSource somCurto;
    [Range(0,12)]
    public int animComemora;
    public bool menu;
    [Range(7,10)]
    public int animMenu;
    public ParticleSystem faiscas;
    public bool isProp;
    [Range(0,6)]
    public int propEstados;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        tendoCurto = false;
        if(curtoCircuito){
            InvokeRepeating("TemCurtoCircuito",10f,40f);
        }
        expressaoAtual = expressao;

        blue.r = 0;
        blue.g = 106f;
        blue.b = 191f;

        red.r = 191;
        red.g = 30;
        red.b = 0;

        yellow.r = 191;
        yellow.g = 172;
        yellow.b = 10;

        purple.r = 22;
        purple.g = 0;
        purple.b = 56;
    }

    // Update is called once per frame
    void Update()
    {
        if(CutsceneEndLevel == false && tendoCurto == false && isProp == false)
        {
            if(GetComponent<PlayerMovemetScript>().Speed == 0 && GetComponent<PlayerCollisionScript>().temPeça == false && tendoCurto == false){
                estados = Estados.IDLE;
            }
            else if(GetComponent<PlayerMovemetScript>().Speed > 0 && GetComponent<PlayerMovemetScript>().corre == false)
            {
                estados = Estados.ANDA;
            }
            else if(GetComponent<PlayerMovemetScript>().corre == true){
                estados = Estados.CORRE;
            }
            if(GetComponent<PlayerCollisionScript>().temPeça == true){
                estados = Estados.SEGURA;
            }
            if(GetComponent<PlayerCollisionScript>().montando == true)
            {
                estados = Estados.MONTA;
            }

            anim.SetInteger("estado",(int)estados);

        }else{
            anim.SetBool("cutsceneEnd",CutsceneEndLevel);
            anim.SetInteger("estadoComemora",animComemora);
        }
        if(menu)
        {
            anim.SetInteger("estado",animMenu);
        }
        if(isProp)
        {
            anim.SetInteger("estado",propEstados);
        }
        //muda rosto
        if(expressao == 0){
            rosto.SetTextureOffset("_MainTex",new Vector2(0,0));
            rosto.SetColor("_EmissionColor",red*0.02f);
        }
        if(expressao == 1){
            rosto.SetTextureOffset("_MainTex",new Vector2(0.23f,0));
            rosto.SetColor("_EmissionColor",blue*0.02f);
        }
        if(expressao == 2){
            rosto.SetTextureOffset("_MainTex",new Vector2(0.47f,0));
            rosto.SetColor("_EmissionColor",purple*0.02f);
        }
        if(expressao == 3){
            rosto.SetTextureOffset("_MainTex",new Vector2(0.70f,0));
            rosto.SetColor("_EmissionColor",yellow*0.02f);
        }
    }
    void TemCurtoCircuito()
    {
        int chanceCurto = Random.Range(0,2);
        if(chanceCurto == 1)
        {
        tendoCurto = true;
        GetComponent<PlayerMovemetScript>().enabled = false;
        somCurto.Play();
        estados = Estados.CURTO;
        anim.SetBool("curto",tendoCurto);
        expressao = 0;
        faiscas.Play();
        Invoke("VoltaNormal",3f);
        }
        if(chanceCurto == 0)
        {
            //do nothing
        }
    }
    void VoltaNormal()
    {
        tendoCurto = false;
        anim.SetBool("curto",tendoCurto);
        estados = Estados.IDLE;
        expressao = expressaoAtual;
        faiscas.Stop();
        GetComponent<PlayerMovemetScript>().enabled = true;
    }
}
