using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool facingRight = true;
    public Transform groundDetector;
    public Transform wallDetector;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetector.position, Vector2.down, distance, LayerMask.GetMask("Ground"));
        RaycastHit2D groundInfo2 = Physics2D.Raycast(wallDetector.position, Vector2.right, distance, LayerMask.GetMask("Ground"));

        if (groundInfo.collider == false || groundInfo2 == true)
        {
            if(facingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                facingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingRight = true;
            }
        }
    }
}
