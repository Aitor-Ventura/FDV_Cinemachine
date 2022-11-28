using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ToggleCameras : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    
    private bool enabled = true;
    
    private void Start()
    {
        camera1.SetActive(enabled);
        camera2.SetActive(!enabled);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            enabled = !enabled;
            camera1.SetActive(enabled);
            camera2.SetActive(!enabled);
        }
    }
}
