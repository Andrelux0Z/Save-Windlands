using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("collectible2", 1);
            Destroy(gameObject);
        }
    }
}
