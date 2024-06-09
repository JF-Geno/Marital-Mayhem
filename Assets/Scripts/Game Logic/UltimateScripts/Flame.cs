using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private int damage;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    public void SetDamage(int damageAmount)
    {
        damage = damageAmount;
        Debug.Log(damage);
    }

     void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<Player>();
        if (player != null)
        {
            KnockBackFunction(collider);
            player.Damage(damage, GameValues.DamageTypes.Ultimate);
            Debug.Log(collider.name);
            Destroy(gameObject);
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