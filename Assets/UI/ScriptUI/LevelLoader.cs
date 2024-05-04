using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader
{
    public static string nextLevel;
    public static string loadingScene = "SceneLoading"; // Escena de carga por defecto

    public static void LoadLevel(string name, string loadingSceneName = null)
    {
        nextLevel = name;
        if (!string.IsNullOrEmpty(loadingSceneName))
            loadingScene = loadingSceneName; // Si se especifica una escena de carga, usarla
        SceneManager.LoadScene(loadingScene);
    }
}
