using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 1.0f;
    public float jumpforce = 2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool ShouldJump;

    public int damage = 1; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundLayer);


        //Direction
        float direction = Mathf.Sign(player.position.x - transform.position.x);

        bool isPlayerAbove = Physics2D.Raycast(transform.position, Vector2.up, 6f, 1 << player.gameObject.layer);

        if(isGrounded)
        {
            //moveing towards player
            rb.linearVelocity = new Vector2(direction * chaseSpeed, rb.linearVelocity.y);

            //Checks if there is ground
            RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 2f, groundLayer);
            //Checks if there is no ground infront
            RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(direction, 0, 0), Vector2.down, 3f, groundLayer);
            //checks if there is ground/platform above 
            RaycastHit2D platformAbove = Physics2D.Raycast(transform.position, Vector2.up, 6f, groundLayer);

            if (!groundInFront.collider && !gapAhead.collider)
            {
                ShouldJump = true;
            }
            else if (isPlayerAbove && platformAbove.collider)
            {
                ShouldJump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded && ShouldJump)
        {
            ShouldJump = false;
            Vector2 direction = (player.position - transform.position).normalized;

            Vector2 jumpDirection = direction * jumpforce;

            rb.AddForce(new Vector2(jumpDirection.x, jumpforce), ForceMode2D.Impulse);
        }
    }
}
 