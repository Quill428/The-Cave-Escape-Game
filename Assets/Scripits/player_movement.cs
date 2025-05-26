using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class player_movement : MonoBehaviour
{
    public Rigidbody2D rb;
    bool isFacingRight = true;
    public IItem itemsgained;

    public float moveSpeed = 5.0f;
    public int maxJumps = 2;
    int jumpsRemaining;

    float horizontalMovement;

    public GameController controller;
    public Items item;
    int progressAmount;
    public PowerUpGain powerUpGain;

    public PauseScript pauseScript;




    //Jumping
    public float JumpPower = 15f;

    [Header("Single Jump (checking ground)")]
    public Transform touchingGround;
    public Vector2 groundSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    [Header("Gravity")]
    public float baseGravity = 2f;
    public float maxfallSpeed = 18f;
    public float fallSpeed = 2f;

    [Header("Dashing")]
    public float dashSpeed = 0f;
    public float dashDuration = 0.1f;
    public float dashCooldown = 0.1f;
    bool isDashing;
    bool canDash = true;


    void Start()
    {
        maxJumps = 2;
        progressAmount = 0;
        Items.OnGemCollect += IncreaseProgressAmount;
        dashSpeed = 5f;
        canDash = true;

    }
    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
        GroundCheck();
        Gravity();
        Flip();

        if (isDashing)
        {
            return;
        }

    }

    private void Gravity()
    {
        if(rb.linearVelocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeed; //removes the floattness
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -maxfallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }
    public void Move(InputAction.CallbackContext context) //to allow the character to be moved by the player connected to the 
    {
       horizontalMovement = context.ReadValue<Vector2>().x;
    }
    public void Dash(InputAction.CallbackContext context) //Dash function
    {
        if(context.performed && canDash)
        {
            StartCoroutine(DashCoroutine());
        }
    }
    private IEnumerator DashCoroutine()
    {
        canDash = false;
        isDashing = true;

        float dashDirection = isFacingRight ? 1f : -1f;

        rb.linearVelocity = new Vector2(dashDirection * dashSpeed, rb.linearVelocity.y); //moving dash

        yield return new WaitForSeconds(dashDuration);

        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);

        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public void MainMenu(InputAction.CallbackContext context) //to open the MainMenu 
    {
        pauseScript.Pause();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0)
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpPower);
                jumpsRemaining--;
            }
        }
    }

    public void GroundCheck()
    {
        if (Physics2D.OverlapBox(touchingGround.position, groundSize, 0, groundLayer))
        {
            jumpsRemaining = maxJumps;
        }
    }

    private void Flip()
    {
        if(isFacingRight && horizontalMovement < 0 || !isFacingRight && horizontalMovement > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(touchingGround.position, groundSize);
    }



    void IncreaseProgressAmount(int amount)
    {

        progressAmount += amount;
           
        
        if (progressAmount == 1)
        {
            //gain double jump
            Debug.Log("Jump gained");
            maxJumps = 3;
            powerUpGain.Message1();
        }
        
        else if (progressAmount == 2)
        {
            Debug.Log("item 2 gained");
            //dashSpeed = 20f;
            maxJumps = 4;
            powerUpGain.Message2();
        }

        else if (progressAmount == 3)
        {
            //gain double jump
            Debug.Log("Jump3 gained");
            maxJumps = 5;
            powerUpGain.Message3();
        }
        else if (progressAmount == 4)
        {
            Debug.Log("item 4 gained");
            //dashSpeed = 40f;
            maxJumps = 6;
            powerUpGain.Message1();
        }
        
    }
}
