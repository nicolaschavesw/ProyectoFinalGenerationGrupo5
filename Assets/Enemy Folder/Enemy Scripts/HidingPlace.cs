using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    public GameObject hideText, stopHideText;
    public GameObject normalPlayer, hidingPlayer;
    public EnemyAI monsterScript;
    public Transform monsterTransform;
    bool interactable, hiding;
    public float loseDistance;
    public Collider maincameraCollider;
    public AudioSource hideSound, stopHideSound;
    public RoomDetector detector;
    

    void Start()
    {
        interactable = false;
        hiding = false;
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(detector.inTrigger == true)
            {
                hideText.SetActive(true);
                interactable = true;
            }
            else if(detector.inTrigger == false)
            {
                hideText.SetActive(false);
                interactable = false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            hideText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (monsterScript.IsDeathRoutineRunning())
        {
            return;
        }
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                maincameraCollider.enabled = false;
                hideText.SetActive(false);
                hideSound.Play();
                hidingPlayer.SetActive(true);
                float distance = Vector3.Distance(monsterTransform.position, normalPlayer.transform.position);
                if(distance > loseDistance)
                {
                    if(monsterScript.chasing == true)
                    {
                        monsterScript.stopChase();
                    }
                }
                stopHideText.SetActive(true);
                hiding = true;
                normalPlayer.SetActive(false);
                interactable = false;
            }
        }
        if(hiding == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                maincameraCollider.enabled = true;
                stopHideText.SetActive(false);
                stopHideSound.Play();
                normalPlayer.SetActive(true);
                hidingPlayer.SetActive(false);
                hiding = false;
            }
        }
    }
}
