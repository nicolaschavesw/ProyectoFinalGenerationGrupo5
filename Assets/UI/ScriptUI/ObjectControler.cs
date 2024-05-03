using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControler : MonoBehaviour
{
    [SerializeField] GameObject Object;
    [SerializeField] AudioClip soundCheck;
    public GameObject colliderKey;




    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            GameObject[] inventario = GameObject.FindGameObjectWithTag("GeneralEvent").GetComponent<InventoryControler>().GetSlots();
            for (int i = 0; i < inventario.Length; i++)
            {
                if (!inventario[i])
                {
                    GameObject.FindGameObjectWithTag("GeneralEvent").GetComponent<InventoryControler>().SetSlot(Object);
                    GameObject.FindGameObjectWithTag("GeneralEvent").GetComponent<InventoryControler>().showInventory();
                    AudioManager.InstanceMusic.PlaySound(soundCheck);
                    Debug.Log("Apaga");
                    colliderKey.SetActive(false); 
                    gameObject.SetActive(false);
                    return;
                }

            }
        }
    }

}
