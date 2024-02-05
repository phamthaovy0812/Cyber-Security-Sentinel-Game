using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    public Canvas canvas;
    public Canvas canvas2;

    private void Start()
    {
        Cinemachine.CinemachineBrain cinemachineBrain = FindObjectOfType<Cinemachine.CinemachineBrain>();
        if (cinemachineBrain != null)
        {
            cinemachineBrain.m_CameraActivatedEvent.AddListener(OnCameraActivated);
        }
    }

    private void OnCameraActivated(ICinemachineCamera fromCamera, ICinemachineCamera toCamera)
    {
        if (toCamera != null)
        {
            canvas.enabled = false;
            canvas2.enabled = false;
        }
    }
}
