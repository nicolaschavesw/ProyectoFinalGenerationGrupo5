using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
   {
    public float minOnTime = 0.5f; // Tiempo mínimo en que la luz está encendida
    public float maxOnTime = 1.5f; // Tiempo máximo en que la luz está encendida
    public float minOffTime = 0.5f; // Tiempo mínimo en que la luz está apagada
    public float maxOffTime = 0.5f; // Tiempo máximo en que la luz está apagada

    private Light lightSource;

    private void Start()
    {
        lightSource = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        while (true)
        {
            lightSource.enabled = true; // Encender la luz
            yield return new WaitForSeconds(Random.Range(minOnTime, maxOnTime));
            
            lightSource.enabled = false; // Apagar la luz
            yield return new WaitForSeconds(Random.Range(minOffTime, maxOffTime));
        }
    }
}