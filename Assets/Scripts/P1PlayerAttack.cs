using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    public Transform firePoint;
    public GameObject projectilePrefab;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //ult
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
    private void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}