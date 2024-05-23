using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainObject : MonoBehaviour
{
     private int damage;

    public void SetDamage(int damageAmount)
    {
        damage = damageAmount;
        Debug.Log("ggggggggg");
        Debug.Log(damage);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        P1Health p1Health = collision.gameObject.GetComponent<P1Health>();
        if (p1Health != null)
        {
            p1Health.Damage(damage);
        }
        Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
    }
}
