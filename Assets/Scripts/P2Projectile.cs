using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Projectile : MonoBehaviour
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

    void OnTriggerEnter2D(Collider2D hitInfo)
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
