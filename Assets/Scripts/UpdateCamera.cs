using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UpdateCamera : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera2;

    private void Awake()
    {
        Camera.main.gameObject.TryGetComponent<CinemachineBrain>(out var brain);
    }

    public void  UpdateDirection(float screex_value){
        CinemachineFramingTransposer cinemachineFramingTransposer = cinemachineVirtualCamera2.GetCinemachineComponent<CinemachineFramingTransposer>();
    //    Debug.Log(cinemachineFramingTransposer + "   " + cinemachineFramingTransposer.m_ScreenX);
        // Debug.Log(cinemachineVirtualCamera2);
        // Debug.Log(cinemachineFramingTransposer);
        cinemachineFramingTransposer.m_ScreenX = screex_value;
    }

}
