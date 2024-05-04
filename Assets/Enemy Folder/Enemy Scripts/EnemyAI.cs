using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent ai;
    public Animator aiAnim;
    public AudioSource audioSource;
    public FieldOfView fieldOfView;
    public StarterAssetsInputs inputs;

    [Header("Settings")]
    public List<Transform> destinations;
    public Transform player;
    public Vector3 rayCastOffset;
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, detectionDistance, catchDistance, searchDistance, minChaseTime, maxChaseTime, minSearchTime, maxSearchTime, jumpscareTime, rotationSpeed;
    public string deathScene;
    public GameObject hideText, stopHideText;

    [Header("Sounds")]
    public AudioClip[] idleSounds;
    public AudioClip[] footstepSounds;
    public AudioClip[] runFoostepSounds;
    public AudioClip jumpscareSound;

    private Transform currentDest;
    private Vector3 dest;
    private float aiDistance;
    private float originalDetectionDistance;
    public bool walking, chasing, searching;
    private bool isDeathRoutineRunning = false;

    private void Start()
    {
        walking = true;
        currentDest = destinations[Random.Range(0, destinations.Count)];
        audioSource = GetComponent<AudioSource>();
        originalDetectionDistance = detectionDistance;
    }

    private void Update()
    {
        if(inputs == null)
        {
            inputs = FindAnyObjectByType<StarterAssetsInputs>();
            player = inputs.transform;
        }
        detectionDistance = inputs.crouch ? originalDetectionDistance / 2 : originalDetectionDistance;
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        aiDistance = Vector3.Distance(player.position, this.transform.position);
        Vector3 rayOrigin = transform.position + rayCastOffset;

        Debug.DrawRay(rayOrigin, direction * detectionDistance, Color.red);
        if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, detectionDistance))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                walking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("searchRoutine");
                StartCoroutine("searchRoutine");
                searching = true;
            }
        }

        if (fieldOfView.canSeePlayer)
        {
            walking = false;
            searching = false;
            chasing = true;
            StopCoroutine("stayIdle");
            StopCoroutine("searchRoutine");
            StartCoroutine("chaseRoutine");
        }

        if (searching)
        {
            SearchPlayer();
        }

        if (chasing)
        {
            ChasePlayer();
        }

        if (walking)
        {
            Patrol();
        }
    }

    private void SearchPlayer()
    {
        ai.speed = 0;
        aiAnim.ResetTrigger("walk");
        aiAnim.ResetTrigger("idle");
        aiAnim.ResetTrigger("sprint");
        aiAnim.SetTrigger("search");
        if (aiDistance <= searchDistance)
        {
            StopCoroutine("stayIdle");
            StopCoroutine("searchRoutine");
            StopCoroutine("chaseRoutine");
            StartCoroutine("chaseRoutine");
            chasing = true;
            searching = false;
        }
    }

    private void ChasePlayer()
    {
        dest = player.position;
        ai.destination = dest;
        ai.speed = chaseSpeed;
        aiAnim.ResetTrigger("walk");
        aiAnim.ResetTrigger("idle");
        aiAnim.ResetTrigger("search");
        aiAnim.SetTrigger("sprint");
        if (aiDistance <= catchDistance)
        {
            player.gameObject.SetActive(false);
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("search");
            hideText.SetActive(false);
            stopHideText.SetActive(false);
            aiAnim.ResetTrigger("sprint");
            aiAnim.SetTrigger("jumpscare");
            chasing = false;
            if (!isDeathRoutineRunning)
            {
                StartCoroutine(deathRoutine());
            }
        }
    }

    private void Patrol()
    {
        dest = currentDest.position;
        ai.destination = dest;
        ai.speed = walkSpeed;
        aiAnim.ResetTrigger("sprint");
        aiAnim.ResetTrigger("idle");
        aiAnim.ResetTrigger("search");
        aiAnim.SetTrigger("walk");
        if (ai.remainingDistance <= ai.stoppingDistance)
        {
            aiAnim.ResetTrigger("sprint");
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("search");
            aiAnim.SetTrigger("idle");
            ai.speed = 0;
            StopCoroutine("stayIdle");
            StartCoroutine("stayIdle");
            walking = false;
        }
    }

    public void stopChase()
    {
        walking = true;
        chasing = false;
        StopCoroutine("chaseRoutine");
        currentDest = destinations[Random.Range(0, destinations.Count)];
    }

    public void PlayFootstepSound()
    {
        AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
        audioSource.PlayOneShot(footstepSound);
        
    }

    public void PlayRunFootstepSound()
    {
        AudioClip runFootstepSound = runFoostepSounds[Random.Range(0, runFoostepSounds.Length)];
        audioSource.PlayOneShot(runFootstepSound);
        
    }

    public bool IsDeathRoutineRunning()
    {
        return isDeathRoutineRunning;
    }

    IEnumerator stayIdle()
    {
        float idleTime = Random.Range(minIdleTime, maxIdleTime);
        AudioClip idleSound = idleSounds[Random.Range(0, idleSounds.Length)];
        audioSource.PlayOneShot(idleSound);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        currentDest = destinations[Random.Range(0, destinations.Count)];
    }

    IEnumerator searchRoutine()
    {
        while (searching)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            yield return null;
        }

        yield return new WaitForSeconds(Random.Range(minSearchTime, maxSearchTime));
        searching = false;
        walking = true;
        currentDest = destinations[Random.Range(0, destinations.Count)];
    }

    IEnumerator chaseRoutine()
    {
        yield return new WaitForSeconds(Random.Range(minChaseTime, maxChaseTime));
        stopChase();
    }

    IEnumerator deathRoutine()
    {
        if (isDeathRoutineRunning)
        {
            yield break;
        }

        isDeathRoutineRunning = true;
        audioSource.PlayOneShot(jumpscareSound);
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathScene);
    }
}
