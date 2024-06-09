using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;
    public GameObject punchNoise;

    public KnockBack KnockBack;
    private void OnTriggerEnter2D(Collider2D collider)
    {
      var player = collider.GetComponent<Player>();
        if (player != null)
        {
            KnockBackFunction(collider);
            player.Damage(damage, GameValues.DamageTypes.Melee);
            player.UltimateLogic();
            punchNoise.SetActive(false);
            punchNoise.SetActive(true);
        }
    }

  
    private void KnockBackFunction(Collider2D collider)
    {
        KnockBack knockBack = collider.GetComponent<KnockBack>();
        if (knockBack != null)
        {
            bool knockFromRight = collider.transform.position.x <= transform.position.x;
            knockBack.ApplyKnockBack(knockFromRight);
        }
    }
}