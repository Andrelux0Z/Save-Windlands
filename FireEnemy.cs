using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour
{

    public GameObject player;
    public GameObject Enemy;
    public Animator animator;
    public GameObject offParticles;
    public GameObject onParticles;
    public GameObject platform;
    public float speed;

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Agua") || collision.CompareTag("InstaKill"))
        {
            animator.Play("FireEnemy_Off");
            onParticles.SetActive(false);
            offParticles.SetActive(true);
            Enemy.tag = "Untagged";
            platform.SetActive(true);
            Invoke("DesactivateParticles", 3f);
            Enemy.GetComponent<PlayerFollow>().enabled = false;
        }
    }

    void DesactivateParticles()
    {

        offParticles.SetActive(false);

    } 
}
