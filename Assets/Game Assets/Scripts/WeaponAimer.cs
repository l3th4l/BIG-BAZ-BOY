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
        Vector2 deltaPos = Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position);
        Vector2 mouseDir = deltaPos.normalized;
        this.transform.localPosition = mouseDir * this.offset;
        this.transform.up = mouseDir;
    }
}