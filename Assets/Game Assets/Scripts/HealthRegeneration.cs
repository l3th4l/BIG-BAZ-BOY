using ScriptableObjectUtility.Events;
using ScriptableObjectUtility.Variables;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    [SerializeField]
    private FloatVariable health;

    [SerializeField]
    private FloatReference maxHealth;

    [SerializeField]
    private float regenRate = 5f;

    [SerializeField]
    private GameEvent regenStart, regenStop;

    private void OnDestroy()
    {
        this.regenStart.Unregister(this.StartRegen);
        this.regenStop.Unregister(this.StopRegen);
    }

    private void Start()
    {
        this.regenStart.Register(this.StartRegen);
        this.regenStop.Register(this.StopRegen);
    }

    private void StartRegen()
    {
        this.enabled = true;
    }

    private void StopRegen()
    {
        this.enabled = false;
    }

    private void Update()
    {
        this.health.Value = Mathf.Clamp(
            this.health.Value + (this.regenRate * Time.deltaTime),
            0f,
            this.maxHealth);
    }
}