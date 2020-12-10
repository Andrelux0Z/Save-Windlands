using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    public Animator animator;

    void OnCollisionEnter2D(Collision2D collision) 
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            animator.Play("TrampolineTense");
        }

    }

    void OnCollisionExit2D(Collision2D collision) 
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.Play("TrampolineDestense");
            Invoke("TrampolineToNormal", 0.2f);
        }

    }

    void TrampolineToNormal()
    {

        animator.Play("TrampolineNormal");

    }
}
