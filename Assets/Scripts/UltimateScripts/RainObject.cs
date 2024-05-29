using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainObject : MonoBehaviour
{
    private int damage;

    public void SetDamage(int damageAmount)
    {
        damage = damageAmount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        P1Health p1Health = other.gameObject.GetComponent<P1Health>();
        if (p1Health != null)
        {
            p1Health.Damage(damage, GameValues.DamageTypes.Ultimate);
        }
    }
}