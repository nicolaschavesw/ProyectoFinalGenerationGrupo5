using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(MakeTheLoad());
    }

    IEnumerator MakeTheLoad()
    {
        yield return new WaitForSeconds(1f); // Esperar un tiempo antes de cargar la escena
        SceneManager.LoadScene(LevelLoader.nextLevel);
    }
}

