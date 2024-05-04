using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesingFinalScene : MonoBehaviour
{
    public float Timer;
    public bool Goodending;
    public bool badEnding;
    public float limitTimer=10;

    private void OnTriggerEnter(Collider other) {

        if(Goodending)
        {
            LevelLoader.LoadLevel("Level Design","SceneLoading");

        }
        if(badEnding)
        {
            LevelLoader.LoadLevel("MainMenu","Bad Ending");
        }
        
    }
    private void Start() {
        Goodending =true;
        badEnding =false;
    }
    private void Update() 
    {
        
        Timer+=Time.deltaTime;
        if(Timer>=limitTimer)
        {
            Goodending=false;
            badEnding=true;
        }
    }
}
