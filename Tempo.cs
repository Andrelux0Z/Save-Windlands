using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tempo : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform tf;
    public float speed;

    void Start() 
    {

        rb.velocity = new Vector2(speed, rb.velocity.y);

    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        rb.velocity = rb.velocity * -1;
    }

}
