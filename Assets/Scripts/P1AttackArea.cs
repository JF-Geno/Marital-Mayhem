using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1AttackArea : MonoBehaviour
{
    private int damage = 3;

    public KnockBack knockBack;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<P2Health>() != null)
        {
           // Debug.Log("YES");
             KB1(collider);
            P2Health health = collider.GetComponent<P2Health>();
            health.Damage(damage);
        }
    }
     private void KB1(Collider2D collider) 
    {
        knockBack.KBCounter = knockBack.KBTotalTime;
        if (collider.transform.position.x <= transform.position.x)
        {
            knockBack.KnockFromRight = true;
        }
        if (collider.transform.position.x > transform.position.x)
        {
            knockBack.KnockFromRight = false;
        }
    }
}