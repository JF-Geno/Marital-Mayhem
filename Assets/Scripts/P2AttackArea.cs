using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2AttackArea : MonoBehaviour
{
    private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<P1Health>() != null)
        {
           // Debug.Log("YES");
            P1Health health = collider.GetComponent<P1Health>();
            health.Damage(damage);
        }
    }
}