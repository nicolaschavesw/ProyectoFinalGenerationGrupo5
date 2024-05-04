using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public int timeScene; 
    void Start()
    {
        StartCoroutine(MakeTheLoad(timeScene));
    }

    IEnumerator MakeTheLoad(int Time)
    {
        yield return new WaitForSeconds(Time); // Esperar un tiempo antes de cargar la escena
        SceneManager.LoadScene(LevelLoader.nextLevel);
    }
}

