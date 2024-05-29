using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Projectile : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 4;
    public Rigidbody2D rb;
    public float degreesPerSec = 360f;

    public P1PlayerAttack p1PlayerAttack;

    void Start()
    {
        rb.velocity = transform.right * speed;
        p1PlayerAttack = GameObject.FindObjectOfType<P1PlayerAttack>();
    }

    void Update()
    {
        float rotAmount = degreesPerSec * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        P2Health p2Health = hitInfo.GetComponent<P2Health>();
        if (p2Health != null)
        {
            p2Health.Damage(damage);
            p1PlayerAttack.UltimateLogic();
        }
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}