using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{ 
    public float recoilForce;
    public KeyCode fire;
    private Rigidbody2D RB;
    private CharMove ChMove;
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        ChMove = GetComponent<CharMove>();
    }

    void Update ()
    {
        Vector3 mouseDir =  (Camera.main.WorldToScreenPoint(transform.position) - Input.mousePosition).normalized;
        if (Input.GetKeyDown(fire))
        {
            if (!isGrounded(ChMove.MaxGroundedHeight))
            {
                print("KYS");
                recoil(recoilForce, mouseDir);
            }
        }
	}
    void recoil(float RF, Vector3 Dir)
    {
        //RB.AddRelativeForce(Dir * RF,ForceMode2D.Impulse);
        RB.velocity = Dir * RF;
    }

    bool isGrounded(float HeightThreshold)
    {
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, Vector2.down, HeightThreshold,ChMove.GroundMask);
        if (_hit != null && _hit.collider != null)
        {
            if (_hit.transform.CompareTag("Walkable"))
                return true;
        }
        return false;
    }
}
