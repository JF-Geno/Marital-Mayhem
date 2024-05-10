using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Projectile : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 3;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;         
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
