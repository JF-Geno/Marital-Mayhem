using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerAbility : UltimateAbility
{
   public float flameDuration = 5f;
    private float flameTimer;

    private void Update()
    {
        if (isUltimateActive)
        {
            if (Time.time >= nextFireTime)
            {
                ActivateAbility();
                nextFireTime = Time.time + 1f / fireRate;
            }

            flameTimer -= Time.deltaTime;
            if (flameTimer <= 0f)
            {
                isUltimateActive = false;
            }
        }
    }

    public override void ActivateAbility()
    {
        flameTimer = flameDuration;
        GameObject flame = Instantiate(abilityPrefab, firePoint.position, firePoint.rotation);
        Flame flameScript = flame.GetComponent<Flame>();
        if (flameScript != null)
        {
            flameScript.SetDamage(damageAmount);
        }
    }
}
