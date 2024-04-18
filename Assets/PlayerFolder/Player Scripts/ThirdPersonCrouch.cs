using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class ThirdPersonCrouch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;

    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (starterAssetsInputs.crouch)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
