using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed =400f;
    [SerializeField]
    private float jumpForce = 5.0f;
    private bool Jumping;
    private int ExtraJump;
    private Rigidbody2D rigidBody;
    public Animator animator;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        {
            Debug.LogError("Failed to cache rigid body. rigid body not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, rigidBody.velocity.y);
        rigidBody.velocity = movement;
        animator.SetFloat("PlayerSpeed", Mathf.Abs(deltaX));


        if (!Mathf.Approximately(deltaX, 0.0f))
        {
            // Scale x to either positive or negative 1 to 'turn' the character
            transform.localScale = new Vector3(Mathf.Sign(deltaX) *1.5f, 1.5f, 1.5f);
        }

        if ((Input.GetKeyDown("w") && !Jumping) || (Input.GetKeyDown("w") && ExtraJump > 0))
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