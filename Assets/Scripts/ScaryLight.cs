using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryLight : MonoBehaviour
{
    public List<Light> pointLights; // Aseg�rate de asignar estas luces en el inspector de Unity
    public Color horrorColor = Color.red; // Puedes cambiar esto al color que quieras
    private List<Color> initialColors = new List<Color>();
    private bool isFlickering = false;

    private void Start()
    {
        // Guardamos los colores iniciales de las luces
        foreach (Light light in pointLights)
        {
            initialColors.Add(light.color);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Cambiamos el color de las luces y comenzamos a parpadear
            for (int i = 0; i < pointLights.Count; i++)
            {
                pointLights[i].color = horrorColor;
            }
            isFlickering = true;
            StartCoroutine(FlickerLights());
        }        
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
             for (int i = 0; i < pointLights.Count; i++)
            {
                pointLights[i].color = initialColors[i];
            }
            isFlickering = false;
            StopCoroutine(FlickerLights());
        }
    }

    IEnumerator FlickerLights()
    {
        while (isFlickering)
        {
            foreach (Light light in pointLights)
            {
                // Apaga la luz
                light.enabled = false;
            }
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

            foreach (Light light in pointLights)
            {
                // Enciende la luz
                light.enabled = true;
            }
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
        }
    }
}
