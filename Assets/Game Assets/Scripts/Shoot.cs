using UnityEngine;

internal sealed class Shoot : MonoBehaviour
{
    [SerializeField]
    private Bazooka bazooka;

    private void Reset()
    {
        this.bazooka = this.GetComponentInChildren<Bazooka>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.bazooka.Shoot();
        }
    }
}