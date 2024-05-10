using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Projectile : MonoBehaviour
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
        P1Health p1Health = hitInfo.GetComponent<P1Health>();
        if (p1Health != null)
        {
            p1Health.Damage(damage);
        }
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
