using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public int TimeScene;
    void Start()
    {
        StartCoroutine(MakeTheLoad(TimeScene));
    }

    IEnumerator MakeTheLoad(float Time)
    {
        yield return new WaitForSeconds(Time);
        SceneManager.LoadScene(LevelLoader.nextLevel);
    }
}

