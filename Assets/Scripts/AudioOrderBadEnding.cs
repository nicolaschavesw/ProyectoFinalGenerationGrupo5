using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOrderBadEnding : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] audioClips; // Array que contiene los clips de audio en orden de reproducción
    private AudioSource audioSource; // Referencia al AudioSource

    private int currentClipIndex = 0; // Índice del clip de audio actual

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtener el componente AudioSource adjunto al objeto

        // Verificar si hay clips de audio y comenzar la reproducción del primer clip
        if (audioClips.Length > 0)
        {
            PlayNextClip();
        }
        else
        {
            Debug.LogWarning("No hay clips de audio asignados.");
        }
    }

    void Update()
    {
        // Verificar si el clip de audio actual ha terminado de reproducirse
        if (!audioSource.isPlaying)
        {
            // Reproducir el siguiente clip en la secuencia
            PlayNextClip();
        }
    }

    // Método para reproducir el siguiente clip de audio en la secuencia
    void PlayNextClip()
    {
        // Verificar si hay más clips de audio por reproducir
        if (currentClipIndex < audioClips.Length)
        {
            // Establecer el clip de audio y reproducirlo
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();

            // Incrementar el índice para el próximo clip
            currentClipIndex++;
        }
        else
        {
            // Reiniciar la secuencia si ya se reprodujeron todos los clips
            currentClipIndex = 0;
        }
    }

    IEnumerator AudioOrder()
    {

        yield return new WaitForSeconds(0);
    }
}
