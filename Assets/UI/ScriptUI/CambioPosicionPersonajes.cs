using System.Collections;
using UnityEngine;

public class CambioPosicionPersonajes : MonoBehaviour
{
    public Transform posJugador, posInicial, posDestino;
    public Animator animaciones;
    public float velocidad;

    private Coroutine movimientoCoroutine;

    void Start()
    {
        posJugador.position = posInicial.position;
    }

    public void InicioTraslado()
    {
        if (movimientoCoroutine == null)
        {
            movimientoCoroutine = StartCoroutine(TrasladoSuave());
        }
    }

    private IEnumerator TrasladoSuave()
    {
        while (Vector3.Distance(posJugador.position, posDestino.position) > 0.01f)
        {
            posJugador.position = Vector3.MoveTowards(posJugador.position, posDestino.position, velocidad * Time.deltaTime);
            animaciones.SetBool("PasarACaminar", true);
            yield return null;
        }
        animaciones.SetBool("PasarACaminar", false);
        movimientoCoroutine = null;
    }

    public void RestablecerTraslado()
    {

        if (movimientoCoroutine != null)
        {
            StopCoroutine(movimientoCoroutine);
            movimientoCoroutine = null;
        }
        posJugador.position = posInicial.position;
        animaciones.SetBool("PasarACaminar", false);
    }
}
