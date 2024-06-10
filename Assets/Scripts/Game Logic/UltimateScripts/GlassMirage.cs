using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassMirage : UltimateAbility
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
        GameObject Glass = Instantiate(abilityPrefab, firePoint.position, firePoint.rotation);
        Glass GlassScript = Glass.GetComponent<Glass>();
        if (GlassScript != null)
        {
            GlassScript.SetDamage(damageAmount);
        }
    }
}
