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
<<<<<<< HEAD:Assets/CameraMove.cs
    {  

        this.offset = this.transform.position - this.target.position;
    }
}
=======
    {
        this.transform.position = Vector3.Lerp(this.transform.position, this.target.position + this.offset, this.speed);
        this.offset = this.transform.position - this.target.position;
    }
}
>>>>>>> d1767412494b0fca08e27ae8d6d90cbf32992802:Assets/Game Assets/Scripts/CameraMove.cs
