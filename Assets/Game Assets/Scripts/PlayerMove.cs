using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
internal sealed class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private float maxGroundedHeight = 0.6f;

    [SerializeField]
    private float moveSpeed = 5f;

    private Rigidbody2D rb;

    private bool IsGrounded(float heightThreshold)
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, heightThreshold, this.groundMask);
        if (hit)
        {
            if (hit.transform.CompareTag("Walkable"))
            {
                return true;
            }
        }

        return false;
    }

    private void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float movInp = Input.GetAxisRaw("Horizontal") * this.moveSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            if (this.IsGrounded(this.maxGroundedHeight))
            {
                this.rb.AddForce(this.transform.up * this.jumpForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            if (this.IsGrounded(this.maxGroundedHeight))
            {
                this.rb.velocity = new Vector2(movInp, this.rb.velocity.y);
            }
        }
    }
}