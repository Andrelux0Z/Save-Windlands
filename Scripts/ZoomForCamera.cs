using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomForCamera : MonoBehaviour
{
    private float cameraZoom;
    public GameObject cinemachineCamera;

    void Start() 
    {

        cameraZoom = cinemachineCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize;

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Zoom"))
        {
            cinemachineCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 10f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Zoom"))
        {
            cinemachineCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = cameraZoom;
        }
    }
}
