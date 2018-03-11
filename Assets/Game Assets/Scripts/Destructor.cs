using UnityEngine;

internal sealed class Destructor : MonoBehaviour
{
    public void Destroy()
    {
        Destructor.Destroy(this.gameObject);
    }
}