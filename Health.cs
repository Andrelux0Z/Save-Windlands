using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int totalHealth;


    public int health = 1;
    public Image[] heartArray;
    public Sprite completeHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (health > 3)
        {
            health = 3;
        }

        for (int i = 0; i < heartArray.Length; i++)
        {
            //if the number off hearts containers is biggest than the health, significates that the player have less health
            if (i < health)
            {
                heartArray[i].sprite = completeHeart;
            }
            else
            {
                heartArray[i].sprite = emptyHeart;
            }
        }

        if (health == 3 && FindObjectOfType<GameManager>().isPaused == false)
        {
            Time.timeScale = 1f;
        }

        if (health <= 0f)
        {
            
            FindObjectOfType<GameManager>().Die();
            Time.timeScale = 0.3f;

        }

    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {

        if (collision.CompareTag("Heart"))
        {
            health++;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("InstaKill"))
        {
            health = 0;
        }

    }
}

















































//uwu