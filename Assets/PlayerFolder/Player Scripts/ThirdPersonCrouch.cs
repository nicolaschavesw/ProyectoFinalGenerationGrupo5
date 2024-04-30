using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEditor.Rendering;

public class ThirdPersonCrouch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera crouchVirtualCamera;

    private StarterAssetsInputs starterAssetsInputs;

    private Animator animator;


    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (starterAssetsInputs.crouch)
        {
            crouchVirtualCamera.gameObject.SetActive(true);
            animator.SetBool("IsCrouching", true);
        }
        else
        {
            crouchVirtualCamera.gameObject.SetActive(false);
            animator.SetBool("IsCrouching", false);
        }
    }
}

