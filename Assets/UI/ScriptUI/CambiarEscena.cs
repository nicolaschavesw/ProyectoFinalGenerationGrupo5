using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Composites;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiarEscena : MonoBehaviour
{
    public GameObject funciones;

    public Button sonidoBoton;
    public AudioClip audioBotones;
    // public void cambiarEscenaPersonajes()
    // {
    //     SceneManager.LoadScene("ScenaPersonajes");
    // }
     public void cambiarEscenaNivel1()
        {
            LevelLoader.LoadLelevel("Level Design");

        }
    // public void cambiarEscenaNivelMenu()
    // {
    //     SceneManager.LoadScene("MainMenu");
    // }

    public void ClikearBoton()
    {
        AudioManager.InstanceMusic.PlaySound(audioBotones);
    }

    public void SiguienteEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
