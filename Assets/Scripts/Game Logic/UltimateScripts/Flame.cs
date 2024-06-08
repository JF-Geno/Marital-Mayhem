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
        if (collider.GetComponent<Bill_Man>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<Bill_Man>().Damage(damage, GameValues.DamageTypes.Ultimate);
             Debug.Log(collider.name);
            Destroy(gameObject);
            //Bill_Man.UltimateLogic();
        }
        else if (collider.GetComponent<Sarah_Woman>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<Sarah_Woman>().Damage(damage, GameValues.DamageTypes.Ultimate);
             Debug.Log(collider.name);
            Destroy(gameObject);
            // Sarah_Woman.UltimateLogic();
        }
        else if (collider.GetComponent<David_Brother>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<David_Brother>().Damage(damage, GameValues.DamageTypes.Ultimate);
             Debug.Log(collider.name);
            Destroy(gameObject);
            // David_Brother.UltimateLogic();
        }
        else if (collider.GetComponent<Jessica_Babysitter>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<Jessica_Babysitter>().Damage(damage, GameValues.DamageTypes.Ultimate);
             Debug.Log(collider.name);
            Destroy(gameObject);
            //Jessica_Babysitter.UltimateLogic();
        }
        else if (collider.GetComponent<Kathy_CatLady>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<Kathy_CatLady>().Damage(damage, GameValues.DamageTypes.Ultimate);
             Debug.Log(collider.name);
            Destroy(gameObject);
            // Kathy_CatLady.UltimateLogic();
        }
        else if (collider.GetComponent<Saul_Lawyer>() != null)
        {
            //KnockBack(collider);
            collider.GetComponent<Saul_Lawyer>().Damage(damage, GameValues.DamageTypes.Ultimate);
             Debug.Log(collider.name);
            Destroy(gameObject);
            // Saul_Lawyer.UltimateLogic();
        }
    }

    
}