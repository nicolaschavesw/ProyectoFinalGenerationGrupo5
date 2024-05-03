using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader
{
    public static string nextLelevel;
    public static void LoadLelevel(string name)
    {
        nextLelevel=name;
        SceneManager.LoadScene("SceneLoading");
        
    }



}
