using UnityEngine;

internal sealed class CharMove : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private KeyCode jumpButton;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float maxGroundedHeight;

    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D rb;

    public LayerMask GroundMask
    {
        get { return this.groundMask; }
    }

    public float MaxGroundedHeight
    {
        get { return this.maxGroundedHeight; }
    }

    private bool IsGrounded(float HeightThreshold)
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, HeightThreshold, this.groundMask);
        if (hit)
        {
            print(hit.transform.name);
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
        float movInp = Input.GetAxisRaw("Horizontal") * moveSpeed;
        print(movInp);
        if (Input.GetKeyDown(this.jumpButton))
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