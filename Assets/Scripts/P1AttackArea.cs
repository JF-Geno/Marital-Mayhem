using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1AttackArea : MonoBehaviour
{
    private int damage = 3;

    public KnockBack knockBack;

       public P1PlayerAttack p1PlayerAttack;

 void Start()
    {
        
        p1PlayerAttack = GameObject.FindObjectOfType<P1PlayerAttack>(); 
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<P2Health>() != null)
        {
            Debug.Log("man got ");
             KB1(collider);
            P2Health health = collider.GetComponent<P2Health>();
            health.Damage(damage);
            p1PlayerAttack.UltimateLogic();
        }
    }
     public void KB1(Collider2D collider) 
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