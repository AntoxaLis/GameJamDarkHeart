using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
<<<<<<< HEAD
=======
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    private bool facingRight = true;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }
    private MovementState state;

>>>>>>> parent of 362ba7f (start of sound)
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
=======
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
>>>>>>> parent of 362ba7f (start of sound)
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
<<<<<<< HEAD
            GetComponent<Rigidbody2D>().velocity = new Vector3(0,14,0);
        }
=======
            rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y);
        }*/

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
    if (dirX != 0f )
    {
        state = MovementState.running;
        if(dirX > 0 && !facingRight){Turn();}
        else if (dirX < 0 && facingRight){Turn();}

    }
    else
    {
        state = MovementState.idle;
    }

    if (rb.velocity.y > 0.1f)
    {
        state = MovementState.jumping;
    }
    else if (rb.velocity.y < -0.1f)
    {
        state = MovementState.falling;
    }

    anim.SetInteger("state", (int)state);
    }

      private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void Turn()
    {
        facingRight= !facingRight;
        transform.Rotate(0f,180f,0f);
>>>>>>> parent of 362ba7f (start of sound)
    }
}
