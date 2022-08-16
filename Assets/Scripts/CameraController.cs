using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float maxZoom;
    [SerializeField] float minZoom;
    [SerializeField] float zoomSpeed;

    Vector2 rawInput;
    CinemachineComponentBase componentBase;

    private void Start()
    {
        componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
    }
    private void OnZoom(InputValue value)
    {
        if (rawInput == null) return;
        rawInput = value.Get<Vector2>();
        if (rawInput.y > 0)
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    private void ZoomOut()
    {
        if (componentBase is CinemachineFramingTransposer)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance = 
                Math.Clamp((componentBase as CinemachineFramingTransposer).m_CameraDistance + zoomSpeed, minZoom, maxZoom);
        }
    }

    private void ZoomIn()
    {
        if (componentBase is CinemachineFramingTransposer)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance =
                Math.Clamp((componentBase as CinemachineFramingTransposer).m_CameraDistance - zoomSpeed, minZoom, maxZoom);
        }
    }
}
