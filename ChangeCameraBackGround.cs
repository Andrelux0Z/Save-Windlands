using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraBackGround : MonoBehaviour
{

    public GameObject cam;

    void OnTriggerEnter2D(Collider2D collision) 
    {

        cam.GetComponent<Camera>().backgroundColor = UnityEngine.Random.ColorHSV(0f, 1f, 0.3f, 0.8f, 0.3f, 0.8f);

    }
}
