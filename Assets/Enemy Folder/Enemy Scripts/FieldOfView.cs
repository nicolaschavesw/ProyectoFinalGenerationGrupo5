using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Collider playerCollider = target.GetComponent<Collider>();

            // Asegúrate de que el jugador tenga un Collider
            if (playerCollider != null)
            {
                // Ajusta la posición del objetivo para apuntar al centro del jugador
                Vector3 targetPosition = target.position + new Vector3(0, playerCollider.bounds.size.y / 2, 0);

                // Ajusta la posición desde la que se lanza el rayo para que esté a la misma altura que el centro del jugador
                Vector3 rayOrigin = transform.position + new Vector3(0, playerCollider.bounds.size.y / 2, 0);

                Vector3 directionToTarget = (targetPosition - rayOrigin).normalized;

                if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
                {
                    float distanceToTarget = Vector3.Distance(rayOrigin, targetPosition);

                    if (!Physics.Raycast(rayOrigin, directionToTarget, distanceToTarget, obstructionMask))
                        canSeePlayer = true;
                    else
                        canSeePlayer = false;
                }
                else
                    canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

}