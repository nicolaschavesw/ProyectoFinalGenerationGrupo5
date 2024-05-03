using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryOpenDoor : MonoBehaviour
{
    public AudioClip forceDoor;
    private void OnCollisionEnter(Collision other) {
        Debug.Log("collision");
        if (other.gameObject.tag == "Player") 
        {
            Debug.Log("sound");
            AudioManager.InstanceMusic.PlaySound(forceDoor);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            Debug.Log("sound");
            AudioManager.InstanceMusic.PlaySound(forceDoor);    
        }
    }
}
