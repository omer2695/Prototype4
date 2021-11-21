using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [SerializeField]
    private float speed=15f;
    [SerializeField]
    private float jumpForce=5f;
    private bool Jumping;
    private int ExtraJump;
    private Rigidbody2D rigidBody;
    public Animator animator;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float deltaX = rigidBody.velocity.x * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, rigidBody.velocity.y);
        


        if (Input.GetKey("l"))
        {
            rigidBody.AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);
            animator.SetFloat("PlayerSpeed", Mathf.Abs(speed * Time.deltaTime));
        }
        else if (Input.GetKey("j"))
        {
            rigidBody.AddForce(Vector2.left * jumpForce, ForceMode2D.Impulse);
            animator.SetFloat("PlayerSpeed", Mathf.Abs(speed * Time.deltaTime));
            
        }
        if (!Mathf.Approximately(deltaX, 0.0f))
        {
            // Scale x to either positive or negative 1 to 'turn' the character
            transform.localScale = new Vector3(Mathf.Sign(deltaX) * -1.5f, 1.5f, 1.5f);
        }
        else
        {
            animator.SetFloat("PlayerSpeed", 0);
        }
        if ((Input.GetKeyDown("i") && !Jumping) || (Input.GetKeyDown("i") && ExtraJump >= 0))
        {

            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
            Jumping = true;
            ExtraJump--;
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Jumping = false;
            ExtraJump = 2;
        }
    }



}
