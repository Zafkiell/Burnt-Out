using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveScript : MonoBehaviour
{
    public bool skin;
    float dissolve;
    bool aparece;
    public PacienteScript pac;
    // Start is called before the first frame update
    void Start()
    {
        if(skin)
        {
            gameObject.GetComponent<SkinnedMeshRenderer>().material = new Material(gameObject.GetComponent<SkinnedMeshRenderer>().material);
            gameObject.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_SliceAmount",0.5f);
        }else{
           gameObject.GetComponent<MeshRenderer>().material = new Material(gameObject.GetComponent<MeshRenderer>().material);
            gameObject.GetComponent<MeshRenderer>().material.SetFloat("_SliceAmount",0.5f); 
        }
        dissolve = 1;
        aparece = true;
    }

    // Update is called once per frame
    void Update()
    {
        //aparece
        if(aparece == true && dissolve > -0.3f)
        {
            dissolve -= 0.3f * Time.deltaTime;
        }
        if(dissolve <= 0){
            aparece = false;
        }
        //desaparece
        if(pac.dissolve == true){
            if(dissolve < 1.1f)
            {
                dissolve += 0.3f * Time.deltaTime;
            }
        }

        //muda pela skin
        if(skin == true){
            gameObject.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_SliceAmount",dissolve);
        }else{
            gameObject.GetComponent<MeshRenderer>().material.SetFloat("_SliceAmount",dissolve);   
        }
    }
}
