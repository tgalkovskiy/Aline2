using System;
using Cinemachine;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class ShakeCameraControl: MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineVirtual;

    private void Awake()
    {
        _cinemachineVirtual = GetComponent<CinemachineVirtualCamera>();
;    }

    public void SetShakeCamera(float power)
    {
        _cinemachineVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = power;
        _cinemachineVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = power;
    }
}
