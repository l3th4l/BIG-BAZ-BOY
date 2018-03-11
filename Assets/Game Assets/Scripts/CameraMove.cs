using UnityEngine;

internal sealed class CameraMove : MonoBehaviour
{
    private Vector3 offset;

    [SerializeField]
    private float smoothTime;

    [SerializeField]
    private Transform target;

    private Vector3 velocity;

    private void LateUpdate()
    {
        this.transform.position = Vector3.SmoothDamp(this.transform.position, this.target.position + this.offset, ref this.velocity, this.smoothTime);
    }

    private void Start()
    {
        this.offset = this.transform.position - this.target.position;
    }
}