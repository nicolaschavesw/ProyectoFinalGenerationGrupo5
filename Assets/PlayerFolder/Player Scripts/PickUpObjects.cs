using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public GameObject flashLightOnPlayer;
    public GameObject pickUPText;
    // Start is called before the first frame update
    void Start()
    {
        pickUPText.SetActive(false);
        pickUPText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flashLightOnPlayer = other.transform.parent.GetChild(4).GetChild(0).gameObject;
            pickUPText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                gameObject.SetActive(false);
                flashLightOnPlayer.SetActive(true);
                pickUPText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickUPText.SetActive(false);
    }
}
