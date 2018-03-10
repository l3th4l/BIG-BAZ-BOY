using UnityEngine;

internal sealed class CameraMove : MonoBehaviour
{
    private Vector3 offset;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform target;

    private void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, this.target.position + this.offset, this.speed);
    }

    private void Start()
    {  

        this.offset = this.transform.position - this.target.position;
    }
}
