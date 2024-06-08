using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 4;
    public Rigidbody2D rb;
    public float degreesPerSec = 360f;
    public GameObject gameObject;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        float rotAmount = degreesPerSec * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Bill_Man>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<Bill_Man>().Damage(damage, GameValues.DamageTypes.Ranged);
             Debug.Log(collider.name);
            Destroy(gameObject);
            //Bill_Man.UltimateLogic();
        }
        else if (collider.GetComponent<Sarah_Woman>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<Sarah_Woman>().Damage(damage, GameValues.DamageTypes.Ranged);
             Debug.Log(collider.name);
            Destroy(gameObject);
            // Sarah_Woman.UltimateLogic();
        }
        else if (collider.GetComponent<David_Brother>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<David_Brother>().Damage(damage, GameValues.DamageTypes.Ranged);
             Debug.Log(collider.name);
            Destroy(gameObject);
            // David_Brother.UltimateLogic();
        }
        else if (collider.GetComponent<Jessica_Babysitter>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<Jessica_Babysitter>().Damage(damage, GameValues.DamageTypes.Ranged);
             Debug.Log(collider.name);
            Destroy(gameObject);
            //Jessica_Babysitter.UltimateLogic();
        }
        else if (collider.GetComponent<Kathy_CatLady>() != null)
        {
           // KnockBack(collider);
            collider.GetComponent<Kathy_CatLady>().Damage(damage, GameValues.DamageTypes.Ranged);
             Debug.Log(collider.name);
            Destroy(gameObject);
            // Kathy_CatLady.UltimateLogic();
        }
        else if (collider.GetComponent<Saul_Lawyer>() != null)
        {
            //KnockBack(collider);
            collider.GetComponent<Saul_Lawyer>().Damage(damage, GameValues.DamageTypes.Ranged);
             Debug.Log(collider.name);
            Destroy(gameObject);
            // Saul_Lawyer.UltimateLogic();
        }
      
        
    }
}