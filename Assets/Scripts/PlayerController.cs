using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] LayerMask platformLayerMask;
    Rigidbody2D rigidbody2D;
    //Original solution
    /*bool leftInput;
    bool rightInput;*/

    float moveInput;
    bool jumpInput;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Original Solution
        /*leftInput = Input.GetKey(KeyCode.LeftArrow);
        rightInput = Input.GetKey(KeyCode.RightArrow);*/
        moveInput = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        //Original solution
        /*if (leftInput)
        {
            rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
        }
        else if (rightInput)
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }*/

        //ONE LINE SOLUTION FOR MOVING LEFT AND RIGHT
        rigidbody2D.velocity = new Vector2(moveInput * speed, rigidbody2D.velocity.y);
        //Input.GetAxisRaw("Horizontal") returns 1 if you press the right key, -1 if you press the left key, and 0 if you don't press either one
        //Can modify the keys you move left and right with through: Edit > Project Settings > Input Manager in Unity
        if (jumpInput && isGrounded())
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
        }
    }
    bool isGrounded()
    {
        Collider2D groundCollider = Physics2D.OverlapBox(rigidbody2D.position + Vector2.down*0.6f, new Vector2(0.5f,0.5f), 0.0f, platformLayerMask);
        return groundCollider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(rigidbody2D.position + Vector2.down * 0.6f, new Vector2(0.5f, 0.5f));
    }
}
