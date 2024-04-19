using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Maniquicontrolermale : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float rotationSpeed = 100.0f;
    public float followRange = 10.0f; // Rango de visión del maniquí
    public Animator Maniquimale;
    public Transform player; // Arrastra y suelta el GameObject del jugador aquí en el Inspector.
    private bool isFollowing = false;
    private Vector3 initialPosition;
    private Vector3 currentVelocity;
    private bool wasFollowing = false;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Calcula la dirección hacia el jugador
        Vector3 playerDirection = player.position - transform.position;
        playerDirection.y = 0.0f; // Ignora la diferencia en la altura

        // Calcula la distancia entre el maniquí y el jugador
        float distanceToPlayer = playerDirection.magnitude;

        // Calcula el ángulo entre la dirección del maniquí y la dirección al jugador
        float angle = Vector3.Angle(transform.forward, playerDirection);

        // Calcula el plano de la cámara
        Plane cameraPlane = new Plane(Camera.main.transform.forward, Camera.main.transform.position);

        // Verifica si los maniquíes están fuera del plano de la cámara
        bool isOutsideCameraView = !cameraPlane.GetSide(transform.position);

        // Si están fuera de la vista de la cámara y dentro del rango de visión, sigue al jugador
        if (isOutsideCameraView && distanceToPlayer <= followRange)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }


        // Si están siguiendo, mueve hacia el jugador y ajusta la rotación
        if (isFollowing)
        {
            // Mueve hacia adelante
            transform.Translate(playerDirection.normalized * moveSpeed * Time.deltaTime, Space.World);
            transform.Rotate(0, Time.deltaTime * rotationSpeed, 0); //rotate

            // Reanuda la animación de caminar si no estaba siguiendo antes
            if (!wasFollowing)
            {
                Maniquimale.speed = 1.0f;
                Maniquimale.Play("Zombie Clawl");
            }

            wasFollowing = true;
            currentVelocity = Vector3.zero;
            Quaternion targetRotation = Quaternion.LookRotation(playerDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
        }
        else
        {
            // Detén la animación de caminar si estaba siguiendo al jugador
            if (wasFollowing)
            {
                Maniquimale.speed = 0;
                Maniquimale.Play("Idle"); // Cambia a la animación de estar quieto
                wasFollowing = false;
            }
        }
    }
}

