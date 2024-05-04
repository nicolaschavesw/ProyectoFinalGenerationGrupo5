using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class ControlleGamePLayUi : MonoBehaviour
{


    [Header("Paneles")]    
    public GameObject panelVictoria;
    public GameObject panelDerrota;

    [Header("Canvas")]
    public GameObject canvasPause;
    private bool juegoPausado = false;

    public CargarPersonaje cargarPersonaje;
    private StarterAssetsInputs starterAssetsInputs;
    

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

        GameObject playerCharacter = GameObject.FindGameObjectWithTag("Player"); 
        if (playerCharacter != null)
        {
            starterAssetsInputs = playerCharacter.GetComponent<StarterAssetsInputs>();
            if (starterAssetsInputs != null)
            {
                canvasPause.SetActive(true);
                Time.timeScale = 0f;
                juegoPausado = true;
                starterAssetsInputs.SetCursorState(false);

            }
         }

        
    }

    public void ReanudarJuego()
    {
        GameObject playerCharacter = GameObject.FindGameObjectWithTag("Player"); // Puedes ajustar la etiqueta según tu configuración
        if (playerCharacter != null)
        {
            starterAssetsInputs = playerCharacter.GetComponent<StarterAssetsInputs>();
            if (starterAssetsInputs != null)
            {
                // Activa el canvas y reanuda el tiempo
                canvasPause.SetActive(false);
                Time.timeScale = 1.0f;
                juegoPausado = false;
                starterAssetsInputs.SetCursorState(true);
            }
         }
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