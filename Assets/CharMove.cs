using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    //Pub
    public float JumpForce;
    public float MoveSpeed;
    public float MaxGroundedHeight;
    public LayerMask GroundMask;
    //Ser
    [SerializeField]
    private KeyCode Jump;
    //Pri
    private Rigidbody2D RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float movInp = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        print(movInp);
        if (Input.GetKeyDown(Jump))
        {
            if (isGrounded(MaxGroundedHeight))
                RB.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
        }
        else
        {
            if (isGrounded(MaxGroundedHeight))
                RB.velocity = new Vector2(movInp, RB.velocity.y);
        }
    }

    bool isGrounded(float HeightThreshold)
    {
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, Vector2.down, HeightThreshold, GroundMask);
        if(_hit != null)
        {
            print(_hit.transform.name);
            if (_hit.transform.CompareTag("Walkable"))
                return true;
        }
        return false;
    }
}
