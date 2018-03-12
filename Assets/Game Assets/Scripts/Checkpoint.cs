using ScriptableObjectUtility.Variables;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private FloatVariable health;

    [SerializeField]
    private FloatReference maxHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Checkpoint!");
        CheckpointManager.Instance.Save();
        this.health.Value = this.maxHealth;
    }
}