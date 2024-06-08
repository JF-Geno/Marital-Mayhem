using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateAbility : MonoBehaviour
{
    public GameObject abilityPrefab;

    public float fireRate;

    public int damageAmount;

    public bool isUltimateActive;

    public Transform firePoint;

    protected float nextFireTime;

    public KnockBack knockBack;

    //for banner and naming stuffs
    public string ultName;

    public GameObject ultActivatedVoiceCue;

    public GameObject ultReadyVoiceCue;

    public virtual void ActivateAbility() { }

    public void DealDamage(GameObject target)
    {
        P2Health WHealth = target.GetComponent<P2Health>();

        if (WHealth != null)

        {

            WHealth.Damage(damageAmount, GameValues.DamageTypes.Ultimate);
        }

        P1Health MHealth = target.GetComponent<P1Health>();

        if (MHealth != null)

        {
           
            MHealth.Damage(damageAmount, GameValues.DamageTypes.Ultimate);
        }
    }
  
}