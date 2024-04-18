using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEditor.Rendering;

public class ThirdPersonCrouch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera crouchVirtualcamera;

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
            crouchVirtualcamera.gameObject.SetActive(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1),1f, Time.deltaTime * 10.0f));
        }
        else
        {
            crouchVirtualcamera.gameObject.SetActive(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10.0f));

        }
    }
}

