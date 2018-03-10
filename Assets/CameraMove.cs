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
<<<<<<< HEAD
        transform.position = Vector3.Lerp(transform.position , target.position + offset, cVelocity);
        
	}
    void blank()
    {

    }
}
=======
        this.offset = this.transform.position - this.target.position;
    }
}
>>>>>>> 4c63aae7d7d6eee7c32bb7d6c7859e31d53846ef
