using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    
    [SerializeField]
    private float DamageConst;

    private void OnCollisionStay2D(Collision2D other)
    {
        var Damage = other.transform.GetComponent<Player>();
        if (Damage != null)
            Damage.ApplyDamage(DamageConst);
        print(00);

    }
}
