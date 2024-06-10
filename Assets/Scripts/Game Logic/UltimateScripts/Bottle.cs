using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
     private int damage;
    public float thresholdY = -10.0f;

    public void SetDamage(int damageAmount)
    {
        damage = damageAmount;
    }

    public void Update()
    {
        if (transform.position.y < thresholdY)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<Player>();
        if (player != null)
        {
            if (player.playerName != "Jessica")
            {
                //KnockBackFunction(collider);
                collider.GetComponent<Player>().Damage(damage, GameValues.DamageTypes.Ultimate);
            }
        }
    }

    private void KnockBackFunction(Collider2D collider)
    {
        KnockBack knockBack = collider.GetComponent<KnockBack>();
        if (knockBack != null)
        {
            bool knockFromRight = collider.transform.position.x <= transform.position.x;
            knockBack.ApplyKnockBack(knockFromRight);
        }
    }
}
