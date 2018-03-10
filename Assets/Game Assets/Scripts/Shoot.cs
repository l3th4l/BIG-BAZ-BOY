using UnityEngine;

[RequireComponent(typeof(CharMove), typeof(Rigidbody2D))]
internal sealed class Shoot : MonoBehaviour
{
    private CharMove chMove;

    [SerializeField]
    private KeyCode fire;

    private Rigidbody2D rb;

    [SerializeField]
    private float recoilForce;

    private bool IsGrounded(float HeightThreshold)
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, HeightThreshold, this.chMove.GroundMask);
        if (hit && hit.collider != null)
        {
            if (hit.transform.CompareTag("Walkable"))
            {
                return true;
            }
        }

        return false;
    }

    private void Recoil(float RF, Vector3 Dir)
    {
        //RB.AddRelativeForce(Dir * RF,ForceMode2D.Impulse);
        this.rb.velocity = Dir * RF;
    }

    private void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.chMove = GetComponent<CharMove>();
    }

    private void Update()
    {
        Vector3 mouseDir = (Camera.main.WorldToScreenPoint(this.transform.position) - Input.mousePosition).normalized;
        if (Input.GetKeyDown(this.fire))
        {
            if (!this.IsGrounded(this.chMove.MaxGroundedHeight))
            {
                print("KYS");
                this.Recoil(this.recoilForce, mouseDir);
            }
        }
    }
}