using StarterAssets;
using UnityEngine;


public class CargarPersonaje : MonoBehaviour
{
     public GameObject maleCharacter;
     public GameObject femaleCharacter;
     private GameObject personajeIntanciado;

     public bool male;

     public bool female;

     public Transform  StartPoint;
     void Start()
     {

          male = PlayerPrefs.GetInt("playerUnoSelect") == 1;
          female = PlayerPrefs.GetInt("playerDosSelect") == 1;

          if (male == true)
          {

               personajeIntanciado = Instantiate(maleCharacter, StartPoint.position, Quaternion.identity);
          }
          if (female == true)
          {
               personajeIntanciado = Instantiate(femaleCharacter, StartPoint.position, Quaternion.identity);
          }
     }
     public StarterAssetsInputs GetStarterAssetsInputs()
     {
          if(personajeIntanciado != null)
          {
               return personajeIntanciado.GetComponent<StarterAssetsInputs>();
          }else
          {
               return null;
          }
     }

}