using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tf;
    public float speed;
    public GameObject flyEnemy;
    private bool facingRight = true;

    void Update() 
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision) 
    {
        
        if (collision.CompareTag("FlyCollision"))
        {
            if (facingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                facingRight = false;
                //flyEnemy.GetComponent<SpriteRenderer>().flipX = false;
            } 
            else if (facingRight == false)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingRight = true;
                
            }

        }

    }
}
