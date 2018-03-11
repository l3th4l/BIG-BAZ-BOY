using System.Collections;
using ScriptableObjectUtility.Events;
using ScriptableObjectUtility.Variables;
using UnityEngine;

internal sealed class Player : MonoBehaviour
{
    [SerializeField]
    private FloatVariable health;

    [SerializeField]
    private FloatReference maxHealth, cooldownTime;

    private Coroutine regenCooldown;

    [SerializeField]
    private GameEvent regenStart, regenStop;

    private float Health
    {
        get
        {
            return this.health;
        }

        set
        {
            this.health.Value = Mathf.Clamp(value, 0f, this.maxHealth);

            if (this.regenCooldown != null)
            {
                this.StopCoroutine(this.regenCooldown);
            }

            this.regenCooldown = this.StartCoroutine(this.DoRegenCooldown());
        }
    }

    public void ApplyDamage(float value)
    {
        this.Health -= value;
    }

    private IEnumerator DoRegenCooldown()
    {
        this.regenStop.Raise();
        yield return new WaitForSeconds(this.cooldownTime);
        this.regenStart.Raise();
    }
}