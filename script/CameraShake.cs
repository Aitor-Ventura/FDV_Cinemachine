using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera camera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(nameof(DoShake));
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag($"Enemy"))
        {
            StartCoroutine(nameof(DoShake));
        }
    }

    private IEnumerator DoShake()
    {
        SetNoise(1, 5f);
        yield return new WaitForSeconds(0.5f);
        SetNoise(0, 0);
    }

    private void SetNoise(float amplitudeGain, float frequencyGain)
    {
        var _camera = camera.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
        if (_camera)
        {
            Debug.LogWarning("Cinemachine noise profile not found.", this);
        }
        _camera.m_AmplitudeGain = amplitudeGain;
        _camera.m_FrequencyGain = frequencyGain;
    }
}
