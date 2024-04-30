using UnityEngine;

public class LampSwing : MonoBehaviour
{
    public float angleY = 10.0f; // Máximo ángulo de oscilación en Y en grados
    public float angleX = 5.0f;  // Máximo ángulo de oscilación en X en grados
    public float frequencyY = 1f; // Frecuencia de la oscilación en Y por segundo
    public float frequencyX = 0.5f; // Frecuencia de la oscilación en X por segundo

    private float time;

    void Update()
    {
        // Incrementar el tiempo con el tiempo transcurrido desde el último frame
        time += Time.deltaTime;

        // Calcular las nuevas rotaciones en Y y X usando la función seno para la oscilación
        float newYRotation = Mathf.Sin(time * Mathf.PI * frequencyY) * angleY;
        float newXRotation = Mathf.Sin(time * Mathf.PI * frequencyX) * angleX;

        // Actualizar la rotación de la lámpara
        transform.rotation = Quaternion.Euler(newXRotation, newYRotation, 0);
    }
}
