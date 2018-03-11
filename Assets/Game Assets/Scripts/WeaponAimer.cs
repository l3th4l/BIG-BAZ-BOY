using UnityEngine;

internal sealed class WeaponAimer : MonoBehaviour
{
    private float offset;

    private void Start()
    {
        this.offset = this.transform.localPosition.magnitude;
    }

    private void Update()
    {
        Vector3 mouseDir = (Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position)).normalized;
        this.transform.localPosition = mouseDir * this.offset;
        this.transform.up = mouseDir;
    }
}