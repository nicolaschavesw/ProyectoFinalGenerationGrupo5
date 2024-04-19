using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPersonaje : MonoBehaviour
{

    public bool chico;
    public bool chica;

    
     private void Awake() {
        
       chico =PlayerPrefs.GetInt("playerUnoSelect")==1;
       chico =PlayerPrefs.GetInt("playerDosSelect")==1;
    }
    
    private void Update() {
        if (chico==false && chica==false)
        {
            chico=true;
        }
        
    }
    public void personajeChico()
    {
        chico=true;
        chica=false;
        personajeGuardar();
    }
    public void personajeChica()
    {
     chica=true;
     chico=false;
        personajeGuardar();

    }
    public void personajeGuardar()
    {
        PlayerPrefs.SetInt("playerUnoSelect",chico ? 1 : 0);
        PlayerPrefs.SetInt("playerDosSelect",chica ? 1 : 0);

    }

}
