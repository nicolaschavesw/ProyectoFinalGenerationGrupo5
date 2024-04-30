using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPersonaje : MonoBehaviour
{
     public GameObject maleCharacter;
     public GameObject femaleCharacter;

     public bool male;
     public bool female;

     void Start()
     {
         maleCharacter.SetActive(false);
         femaleCharacter.SetActive(false);
     }
     private void Update()
     {

          male = PlayerPrefs.GetInt("playerUnoSelect") == 1;
          female = PlayerPrefs.GetInt("playerDosSelect") == 1;
          if (male == true)
          {
               maleCharacter.SetActive(true);
               femaleCharacter.SetActive(false);

          }
          if (female == true)
          {
               femaleCharacter.SetActive(true);
               maleCharacter.SetActive(false);

          }

     }




}
