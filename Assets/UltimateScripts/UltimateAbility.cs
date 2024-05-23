using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateAbility : MonoBehaviour
{
        public GameObject abilityPrefab;

    public float fireRate;

    public int damageAmount;

    public bool isUltimateActive;

    public Transform firePoint;


    protected float nextFireTime;

    public KnockBack knockBack;


    public virtual void ActivateAbility(){}


    public void DealDamage(GameObject target)

    {

        P2Health WHealth = target.GetComponent<P2Health>();

        if (WHealth != null)

        {

            KB1(target.GetComponent<Collider2D>());

            WHealth.Damage(damageAmount);

        }


        P1Health MHealth = target.GetComponent<P1Health>();

        if (MHealth != null)

        {

            KB1(target.GetComponent<Collider2D>());

            MHealth.Damage(damageAmount);

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
