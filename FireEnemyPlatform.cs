using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyPlatform : MonoBehaviour
{

    public GameObject enemy;
    public Rigidbody2D playerRB;

    void Update() 
    {
        
        transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, transform.position.z);

    }
}
