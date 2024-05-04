using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAnimation : MonoBehaviour
{
    public ParticleSystem Guts;


    public void PlayParticles()
    {
        Guts.Play();
    }
    public void StopParticles()
    {
        Guts.Stop();
    }

}
