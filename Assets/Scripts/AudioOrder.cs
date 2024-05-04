using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOrder : MonoBehaviour
{
    public CargarPersonaje cargarPersonaje;
    public GameObject auidoElara, audioGawain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cargarPersonaje.male)
        {
            auidoElara.SetActive(false);
            audioGawain.SetActive(true);
        }
        if (cargarPersonaje.female)
        {
            auidoElara.SetActive(true);
            audioGawain.SetActive(false);
        }
    }
}
