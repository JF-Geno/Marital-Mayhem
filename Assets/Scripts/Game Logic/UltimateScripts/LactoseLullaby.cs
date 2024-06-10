using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LactoseLullaby : UltimateAbility
{
    public int numberOfObjects = 10;
    public Vector3 spawnArea;
    public float spawnHeight = 10f;

    

    private void Update()
    {
        
        if (isUltimateActive && Time.time >= nextFireTime)
        {
            ActivateAbility();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    public override void ActivateAbility()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            
            Vector3 spawnPosition = new Vector3(
                Random.Range(firePoint.position.x - spawnArea.x / 2, firePoint.position.x + spawnArea.x / 2),
                firePoint.position.y + spawnHeight,
                Random.Range(firePoint.position.z - spawnArea.z / 2, firePoint.position.z + spawnArea.z / 2)
            );

            
            GameObject Bottle = Instantiate(abilityPrefab, spawnPosition, Quaternion.identity);


            Bottle rainBottleScript = Bottle.GetComponent<Bottle >();
            if (rainBottleScript != null)
            {
                rainBottleScript.SetDamage(damageAmount);
            }
        }

        //isUltimateActive = false;
    }

}