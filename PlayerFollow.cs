using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D rb;
    public float speed;


    void Update()
    {
        
        transform.Translate(Vector2.right * -speed * Time.deltaTime);
        Vector3 direction = player.transform.position - gameObject.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (angle < 0.1f)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else if (angle > 0.1f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }

}

