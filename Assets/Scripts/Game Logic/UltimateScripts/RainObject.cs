using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RainObject : MonoBehaviour
{
    private int damage;
    public float thresholdY = -10.0f;

    public void SetDamage(int damageAmount)
    {
        damage = damageAmount;
    }

    public void Update()
    {
        if (transform.position.y<thresholdY)
        {
            Destroy(gameObject);

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.GetComponent<Bill_Man>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<Bill_Man>().Damage(damage, GameValues.DamageTypes.Ultimate);
            //Bill_Man.UltimateLogic();
        }
        else if (collider.GetComponent<Sarah_Woman>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<Sarah_Woman>().Damage(damage, GameValues.DamageTypes.Ultimate);
            // Sarah_Woman.UltimateLogic();
        }
        else if (collider.GetComponent<David_Brother>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<David_Brother>().Damage(damage, GameValues.DamageTypes.Ultimate);
            // David_Brother.UltimateLogic();
        }
        else if (collider.GetComponent<Jessica_Babysitter>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<Jessica_Babysitter>().Damage(damage, GameValues.DamageTypes.Ultimate);
            //Jessica_Babysitter.UltimateLogic();
        }
        else if (collider.GetComponent<Kathy_CatLady>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<Kathy_CatLady>().Damage(damage, GameValues.DamageTypes.Ultimate);
            // Kathy_CatLady.UltimateLogic();
        }
        else if (collider.GetComponent<Saul_Lawyer>() != null)
        {
            //KnockBack(collider);
            collider.GetComponent<Saul_Lawyer>().Damage(damage, GameValues.DamageTypes.Ultimate);
            // Saul_Lawyer.UltimateLogic();
        }  

    }
}
