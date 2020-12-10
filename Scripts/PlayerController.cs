using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Data
    public float speed;
    public float jumpForce;
    private float moveInput;
    private float moveVerticalInput;
    public int extraJumps;
    public int totalExtraJumps;
    public float climbSpeed;
    public float launchForce;
    private float originalGravityScale;


    //Objects
    public GameObject SplashParticles;


    //Is variables
    private bool isOnWater;
    public bool isIdle;
    private bool isClimbing;
    public bool isFalling;
    public bool isJumping;
    private bool facingRight = true;
    

    //Components
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator playerAnimator;
    
    
    //Ground Detection
    public bool isGrouded;
    public Transform isGroudedDetector;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    void Start() 
    {

        //Set permanent data
        originalGravityScale = rb.gravityScale;
        extraJumps = totalExtraJumps;
   
    }

    void Update()
    {
        if (FindObjectOfType<GameManager>().isDead == true)
        {
            FindObjectOfType<PlayerController>().enabled = false;
        }

        //Is modifications-
        if (rb.velocity.x < 0.05f && rb.velocity.y < 0.05f && rb.velocity.x > -0.05f && rb.velocity.y > -0.05f)
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }

        if (rb.velocity.y > 0.05 && isGrouded == false && isClimbing == false)
        {
            isJumping = true;
            isFalling = false;
        }
        else if (rb.velocity.y < -0.05 && isGrouded == false && isClimbing == false)
        {
            isFalling = true;
            isJumping = false;
        }
        else
        {
            isJumping = false;
            isFalling = false;
        }

        if (isGrouded == true)
        {
            extraJumps = totalExtraJumps;
        }
        //-Is Modifications

        //Flip-
        if (facingRight == false && moveInput > 0)
        {
            facingRight = !facingRight;
            spriteRenderer.flipX = false;
        }
        else if (facingRight == true && moveInput < 0)
        {
            facingRight = !facingRight;
            spriteRenderer.flipX = true;
        }
        //-Flip

        //Jump-
        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0 && isClimbing == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrouded == true && isClimbing == false)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        //-Jump

    }

    void FixedUpdate() 
    {

        //Ground Verification-
        isGrouded = Physics2D.OverlapCircle(isGroudedDetector.position, checkRadius, whatIsGround);
        //-Ground Verification

        //Horizontal movement-
        moveInput = Input.GetAxisRaw("Horizontal");   
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        //-Horizontal movement

        //Climp-
        if (isClimbing == true)
        {
            moveVerticalInput = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, moveVerticalInput * climbSpeed);  
            rb.gravityScale = 0f;
        }
        //-Climp
    }

    private void LateUpdate() 
    {

        //Animator with code-
        if (isIdle == true && isClimbing == false && isGrouded == true)
        {
            playerAnimator.Play("Idle");
        }
        else if (isClimbing == true)
        {
            if (isIdle == true)
            {
                playerAnimator.Play("Scale_Idle");
            }
            else
            {
                playerAnimator.Play("Scale");
            }
        }
        else if (isGrouded == true && isClimbing == false && isIdle == false || isOnWater == true)
        {
            playerAnimator.Play("Walk");
        }
        else if (isJumping == true && isFalling == false && isOnWater == false)
        {
            playerAnimator.Play("Jump_Up");
        }
        else if (isFalling == true && isJumping == false && isOnWater == false)
        {
            playerAnimator.Play("Jump_Down");
        }

        //-Animator with code
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //Activate splash particles
        if (collision.CompareTag("Agua") && rb.velocity.y < -10)
        {
            SplashParticles.SetActive(true);
            Invoke("DesactivateParticles", 1f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        //Know where can climp
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = true;
        }

        //Know where can swim
        if (collision.CompareTag("Agua"))
        {
            isOnWater = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collsion) 
    {
        //Reset some variables
        isClimbing = false;
        rb.gravityScale = originalGravityScale;
        isOnWater = false;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        //Know when the player touch a trampoline
        if (other.gameObject.CompareTag("Trampoline"))
        {
            rb.velocity = Vector2.up * launchForce;
        }
    }

    void DesactivateParticles()
    {

        SplashParticles.SetActive(false);

    }
}
