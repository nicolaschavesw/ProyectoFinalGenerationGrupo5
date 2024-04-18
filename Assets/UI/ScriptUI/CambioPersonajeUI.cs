using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CambioPersonajeUI : MonoBehaviour
{
   public GameObject personajeAtras;
    public GameObject personajeAdelante;
    public Animator animator;

    public Button butonCambiarPersonaje;


    private void Start() {
        butonCambiarPersonaje.GetComponent<Button>().onClick.AddListener(CambiarPersonajeAtras);
    }

    public void CambiarPersonajeAtras()
    {
            animator.Play("AnimacionPersonajeAtras");

    }
}
