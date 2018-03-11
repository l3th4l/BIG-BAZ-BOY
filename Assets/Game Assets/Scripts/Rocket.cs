using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
internal sealed class Rocket : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rocket.Instantiate(this.explosionPrefab, this.transform.position, Quaternion.identity);
        Rocket.Destroy(this.gameObject);
    }
}