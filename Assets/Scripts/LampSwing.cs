using UnityEngine;

public class LampSwing : MonoBehaviour
{
    public float angleY = 10.0f; // M�ximo �ngulo de oscilaci�n en Y en grados
    public float angleX = 5.0f;  // M�ximo �ngulo de oscilaci�n en X en grados
    public float frequencyY = 1f; // Frecuencia de la oscilaci�n en Y por segundo
    public float frequencyX = 0.5f; // Frecuencia de la oscilaci�n en X por segundo

    private float time;

    void Update()
    {
        // Incrementar el tiempo con el tiempo transcurrido desde el �ltimo frame
        time += Time.deltaTime;

        // Calcular las nuevas rotaciones en Y y X usando la funci�n seno para la oscilaci�n
        float newYRotation = Mathf.Sin(time * Mathf.PI * frequencyY) * angleY;
        float newXRotation = Mathf.Sin(time * Mathf.PI * frequencyX) * angleX;

        // Actualizar la rotaci�n de la l�mpara
        transform.rotation = Quaternion.Euler(newXRotation, newYRotation, 0);
    }
}
