using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ControlleGamePLayUi : MonoBehaviour
{


    [Header("Paneles")]    
    public GameObject panelVictoria;
    public GameObject panelDerrota;

    [Header("Canvas")]
    public GameObject canvasPause;
    private bool juegoPausado = false;



    void Start()
    {
        canvasPause.SetActive(false);

    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    void PausarJuego()
    {
        canvasPause.SetActive(true);
        Time.timeScale = 0.0f;
        juegoPausado = true;
    }

    public void ReanudarJuego()
    {
        canvasPause.SetActive(false);
        Time.timeScale = 1.0f;
        juegoPausado = false;
    }
    
    public void ReiniciarJuego ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale=1.0F;
    }
    public void volverMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale=1.0F;
    }

    public void activarPanelVictoria()
    {
        panelVictoria.SetActive(true);
        Time.timeScale=0.0f;
        
    }
    public void activarPanelDerrota()
    {
        panelDerrota.SetActive(true);
        Time.timeScale=0.0f;
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

}
