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
        var player = target.GetComponent<Player>();
        if (player != null)
        {
            player.Damage(damageAmount, GameValues.DamageTypes.Ultimate);
        }

    }

}