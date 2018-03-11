using UnityEngine;

internal sealed class Enemy : MonoBehaviour
{
    private bool IsAlive
    {
        get { return this.gameObject.activeInHierarchy; }
        set { this.gameObject.SetActive(value); }
    }

    public void Kill()
    {
        this.IsAlive = false;
    }
}