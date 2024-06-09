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
        if (collider.gameObject.GetComponent<Bill_Man>() != null)
        {
            // KnockBack(collider);
            collider.gameObject.GetComponent<Bill_Man>().Damage(damage, GameValues.DamageTypes.Ranged);
            collider.gameObject.GetComponent<Bill_Man>().UltimateLogic();
        }
        else if (collider.gameObject.GetComponent<Sarah_Woman>() != null)
        {
            // KnockBack(collider);
            collider.gameObject.GetComponent<Sarah_Woman>().Damage(damage, GameValues.DamageTypes.Ranged);
            collider.gameObject.GetComponent<Sarah_Woman>().UltimateLogic();
        }
        else if (collider.gameObject.GetComponent<David_Brother>() != null)
        {
            // KnockBack(collider);
            collider.gameObject.GetComponent<David_Brother>().Damage(damage, GameValues.DamageTypes.Ranged);
            collider.gameObject.GetComponent<David_Brother>().UltimateLogic();
        }
        else if (collider.gameObject.GetComponent<Jessica_Babysitter>() != null)
        {
            // KnockBack(collider);
            collider.gameObject.GetComponent<Jessica_Babysitter>().Damage(damage, GameValues.DamageTypes.Ranged);
            collider.gameObject.GetComponent<Jessica_Babysitter>().UltimateLogic();
        }
        else if (collider.gameObject.GetComponent<Kathy_CatLady>() != null)
        {
            // KnockBack(collider);
            collider.gameObject.GetComponent<Kathy_CatLady>().Damage(damage, GameValues.DamageTypes.Ranged);
            collider.gameObject.GetComponent<Kathy_CatLady>().UltimateLogic();
        }
        else if (collider.gameObject.GetComponent<Saul_Lawyer>() != null)
        {
            //KnockBack(collider);
            collider.gameObject.GetComponent<Saul_Lawyer>().Damage(damage, GameValues.DamageTypes.Ranged);
            collider.gameObject.GetComponent<Saul_Lawyer>().UltimateLogic();
        }
        UnityEngine.Debug.Log(collider);

    }
}
//public class Projectile : MonoBehaviour
//{
//    public float speed = 1f;
//    public int damage = 1;
//    public Rigidbody2D rb;
//    public float degreesPerSec = 360f;

//    void Start()
//    {
//        rb.velocity = transform.right * speed;
//    }

//    void Update()
//    {
//        float rotAmount = degreesPerSec * Time.deltaTime;
//        float curRot = transform.localRotation.eulerAngles.z;
//        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
//    }

//    void OnCollisionEnter2D(Collision2D collision2D)
//    {
//        //P2Health p2Health = hitInfo.GetComponent<P2Health>();
//        //if (p2Health != null)
//        //{
//        //    p2Health.Damage(damage);
//        //}
//        UnityEngine.Debug.Log(collision2D);
//        Destroy(gameObject);
//    }
//}