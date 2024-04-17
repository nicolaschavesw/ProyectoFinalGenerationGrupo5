using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public GameObject funciones;
    public void cambiarEscenaPersonajes()
    {
        SceneManager.LoadScene("ScenaPersonajes");
    }
    public void cambiarEscenaNivel1()
    {
        SceneManager.LoadScene("EscenaTest");
    }
    public void cambiarEscenaNivelMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
