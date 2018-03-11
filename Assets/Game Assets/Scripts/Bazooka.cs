using UnityEngine;

internal sealed class Bazooka : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude = 50f;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Rocket rocketPrefab;

    [SerializeField]
    private Transform rocketSpawn;

    [SerializeField]
    private float dampFactor;

    public void Shoot()
    {
        var rocketRb = Bazooka.Instantiate(this.rocketPrefab, this.rocketSpawn.position, this.rocketSpawn.rotation).GetComponent<Rigidbody2D>();
        var force = this.rocketSpawn.up * this.forceMagnitude;
        rocketRb.AddForce(force);
        this.rb.velocity = -force/dampFactor;
    }

    private void Reset()
    {
        this.rocketSpawn = this.transform;
        this.rb = this.GetComponentInParent<Rigidbody2D>();
    }
}