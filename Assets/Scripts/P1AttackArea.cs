using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1AttackArea : MonoBehaviour
{
    private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<P2Health>() != null)
        {
            Debug.Log("YES");
            P2Health health = collider.GetComponent<P2Health>();
            health.Damage(damage);
        }
    }
}