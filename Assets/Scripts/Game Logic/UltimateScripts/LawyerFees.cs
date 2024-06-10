using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawyerFees : UltimateAbility
{
   public float Duration = 1f;
    private float Timer;

    
    
    private void Update()
    {
        if (isUltimateActive)
        {
            if (Time.time >= nextFireTime)
            {
                ActivateAbility();
                nextFireTime = Time.time + 1f / fireRate;
            }

            Timer -= Time.deltaTime;
            if (Timer <= 0f)
            {
                isUltimateActive = false;
            }
        }
    }

    public override void ActivateAbility()
    {
        Timer = Duration;
        GameObject Paper = Instantiate(abilityPrefab, firePoint.position, firePoint.rotation);
        Paper PaperScript = Paper.GetComponent<Paper>();
        if (PaperScript != null)
        {
            PaperScript.SetDamage(damageAmount);
        }
    }
}
