using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPersonaje : MonoBehaviour
{
     public GameObject chicoPersonaje;
     public GameObject chicaPersonaje;

     public bool chico;
     public bool chica;

     void Start()
     {
          chicoPersonaje.SetActive(false);
          chicaPersonaje.SetActive(false);
     }
     private void Update()
     {

          chico = PlayerPrefs.GetInt("playerUnoSelect") == 1;
          chica = PlayerPrefs.GetInt("playerDosSelect") == 1;
          if (chico == true)
          {
               chicoPersonaje.SetActive(true);
               chicaPersonaje.SetActive(false);

          }
          if (chica == true)
          {
               chicaPersonaje.SetActive(true);
               chicoPersonaje.SetActive(false);

          }

     }




}
