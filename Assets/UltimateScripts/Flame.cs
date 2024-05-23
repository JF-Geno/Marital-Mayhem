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
        Debug.Log("ggggggggg");
        damage = damageAmount;
        Debug.Log(damage);
    }

       void OnTriggerEnter2D (Collider2D hitInfo)
    {
        
        P2Health p2Health = hitInfo.GetComponent<P2Health>();
        if(p2Health != null)
        {
            p2Health.Damage(damage);
        }
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
