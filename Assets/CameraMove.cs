using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cVelocity;
    public Transform target;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }
	void FixedUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position , target.position + offset, cVelocity);
        
	}
    void blank()
    {

    }
}
