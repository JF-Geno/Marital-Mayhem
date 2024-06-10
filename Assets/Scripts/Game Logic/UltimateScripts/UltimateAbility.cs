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
    public Sprite ultName;

    public GameObject ultActivatedVoiceCue;

    public GameObject ultReadyVoiceCue;

    public virtual void ActivateAbility() { }

    public void DealDamage(GameObject target)
    {
        Bill_Man Bill = target.GetComponent<Bill_Man>();
        if (Bill != null)
        {
            Bill.Damage(damageAmount, GameValues.DamageTypes.Ultimate);
        }

         Sarah_Woman Sarah = target.GetComponent<Sarah_Woman>();
        if (Sarah != null)
        {
            Sarah.Damage(damageAmount, GameValues.DamageTypes.Ultimate);
        }

         David_Brother David = target.GetComponent<David_Brother>();
        if (David != null)
        {
            David.Damage(damageAmount, GameValues.DamageTypes.Ultimate);
        }

         Jessica_Babysitter Jessica = target.GetComponent<Jessica_Babysitter>();
        if (Jessica != null)
        {
            Jessica.Damage(damageAmount, GameValues.DamageTypes.Ultimate);
        }

         Kathy_CatLady Kathy = target.GetComponent<Kathy_CatLady>();
        if (Kathy != null)
        {
            Kathy.Damage(damageAmount, GameValues.DamageTypes.Ultimate);
        }
        
         Saul_Lawyer Saul = target.GetComponent<Saul_Lawyer>();
        if (Saul != null)
        {
            Saul.Damage(damageAmount, GameValues.DamageTypes.Ultimate);
        }

       
    }
 
    
  
}