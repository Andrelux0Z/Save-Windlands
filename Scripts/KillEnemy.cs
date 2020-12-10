using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{

    public GameObject enemy;
    public Rigidbody2D playerRB;

    void Update() 
    {
        
        transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, transform.position.z);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.SetActive(false);
            Destroy(enemy, 1f);
            Destroy(gameObject);
        }
    }
}
