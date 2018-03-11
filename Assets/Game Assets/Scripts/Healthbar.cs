using ScriptableObjectUtility.Variables;
using UnityEngine;
using UnityEngine.UI;

internal sealed class Healthbar : MonoBehaviour
{
    private float damageFraction, damageVelocity;

    [SerializeField]
    private FloatReference health, maxHealth, regenCooldown;

    [SerializeField]
    private Image healthImage, damageImage;

    private void Update()
    {
        float healthFraction = this.health / this.maxHealth;
        this.healthImage.fillAmount = healthFraction;

        this.damageFraction = Mathf.SmoothDamp(
           this.damageFraction,
           healthFraction,
           ref this.damageVelocity,
           this.regenCooldown,
           float.MaxValue,
           Time.deltaTime);

        this.damageImage.fillAmount = this.damageFraction;
    }
}