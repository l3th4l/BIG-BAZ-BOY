using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
internal sealed class Rocket : MonoBehaviour
{
    [SerializeField]
    private float enemyDamageRadius = 1f;

    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private AnimationCurve playerDamageDropOff, playerForceDropOff;

    [SerializeField]
    private LayerMask playerDamageLayer, enemyDamageLayer;

    private float PlayerDamageRadius
    {
        get
        {
            return this.playerDamageDropOff.keys.Length > 0
              ? this.playerDamageDropOff.keys[this.playerDamageDropOff.length - 1].time
              : 0f;
        }
    }

    private float PlayerMaxDamage
    {
        get
        {
            return this.playerDamageDropOff.keys.Length > 0
                ? this.playerDamageDropOff.keys[0].value
                : 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rocket.Instantiate(this.explosionPrefab, this.transform.position, Quaternion.identity);
        Debug.Log("Gonna kms 1");
        var playerCollider = Physics2D.OverlapCircle(this.transform.position, this.PlayerDamageRadius, this.playerDamageLayer);
        if (playerCollider != null)
        {
            Debug.Log("KMS2");
            var deltaPos = playerCollider.transform.position - this.transform.position;
            float dist = deltaPos.magnitude;
            Debug.Log("KMS3");
            float damage = this.playerDamageDropOff.Evaluate(dist);
            playerCollider.GetComponent<Player>().ApplyDamage(damage);
            Debug.Log("KMS4");
            float forceMagnitude = this.playerForceDropOff.Evaluate(dist);
            playerCollider.GetComponent<Rigidbody2D>().AddForce(deltaPos.normalized * forceMagnitude);

        }

        var enemyColliders = Physics2D.OverlapCircleAll(this.transform.position, this.enemyDamageRadius, this.enemyDamageLayer);

        foreach (var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<Enemy>().Kill();
        }

        Destroy(this.gameObject);
        Debug.Log("Gonna kms");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.enemyDamageRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, this.PlayerDamageRadius);
    }
}