using UnityEngine;

internal sealed class Player : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;

    private float maxHealth;

    private float Health
    {
        get
        {
            return this.health;
        }

        set
        {
            this.health = value > 0f ? value : 0f;
        }
    }

    public void ApplyDamage(float value)
    {
        this.Health -= value;
    }

    private void Start()
    {
        this.maxHealth = this.health;
    }
}