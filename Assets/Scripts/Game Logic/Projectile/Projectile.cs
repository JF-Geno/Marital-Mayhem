using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 4;
    public Rigidbody2D rb;
    public float degreesPerSec = 360f;

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

    private void OnCollisionEnter2D(Collision2D collider)
    {
          Destroy(gameObject);
        var player = collider.gameObject.GetComponent<Player>();
        if (player != null)
        {
            KnockBackFunction(collider);
            player.Damage(damage, GameValues.DamageTypes.Ranged);
            player.UltimateLogic();
        }

    }

       private void KnockBackFunction(Collision2D collider)
    {
        KnockBack knockBack = collider.gameObject.GetComponent<KnockBack>(); 
        if (knockBack != null)
        {
            bool knockFromRight = collider.transform.position.x <= transform.position.x;
            knockBack.ApplyKnockBack(knockFromRight);
        }
    }
}
