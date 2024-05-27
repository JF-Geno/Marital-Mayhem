using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2AttackArea : MonoBehaviour
{
    private int damage = 3;

    public KnockBack knockBack;

   public P2PlayerAttack p2PlayerAttack;

 void Start()
    {
        
        p2PlayerAttack = GameObject.FindObjectOfType<P2PlayerAttack>(); 
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<P1Health>() != null)
        {
            Debug.Log(" woman got");
            KB2(collider);
            P1Health health = collider.GetComponent<P1Health>();
            health.Damage(damage);
            p2PlayerAttack.UltimateLogic();
        }
    }

     public void KB2(Collider2D collider) 
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