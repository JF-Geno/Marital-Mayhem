using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
  public float speed = 20f;
    public int damage = 4;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 0.25f;

    private float nextFireTime = 0f;
    private bool isUltimateActive = true;

    // Update is called once per frame
    // void Update()
    // {
    //     // Check for activation key (Z) and toggle ultimate activation
    //     if (Input.GetKeyDown(KeyCode.Z))
    //     {
    //         //isUltimateActive = !isUltimateActive;
    //     }

    //     // If the ultimate is active, keep shooting
    //     if (isUltimateActive)
    //     {
    //         //StartUltimate();
    //     }
    // }

    // public void StartUltimate()
    // {
    //     // Shooting mechanism
    //     if (Time.time >= nextFireTime)
    //     {
    //         ShootUltimate();
    //         nextFireTime = Time.time + fireRate;
    //     }
    // }

    // public void ActivateUltimate(bool activate)
    // {
    //     isUltimateActive = activate;
    // }

    // void ShootUltimate()
    // {
    //     GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    //     Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
    //     if (rb != null)
    //     {
    //         rb.velocity = firePoint.right * speed;
    //     }
    // }

}
