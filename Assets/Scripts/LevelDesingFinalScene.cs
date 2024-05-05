using StarterAssets;
using UnityEngine;

public class LevelDesingFinalScene : MonoBehaviour
{
    public float Timer;
    public bool Goodending;
    public bool badEnding;
    public float limitTimer = 10;
    
   

    private void OnTriggerEnter(Collider other)
    {

        if (Goodending)
        {
            LevelLoader.LoadLevel("MainMenu", "Good Ending");
            SetCursorState(false);

        }
        if (badEnding)
        {
            LevelLoader.LoadLevel("MainMenu", "Bad Ending");
            SetCursorState(false);
            
        }

    }
    private void Start()
    {
        
        Goodending = true;
        badEnding = false;
    }
    private void Update()
    {

        Timer += Time.deltaTime;
        if (Timer >= limitTimer)
        {
            Goodending = false;
            badEnding = true;
        }
    }
     public void SetCursorState(bool newState)
	{
		Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
	}

}