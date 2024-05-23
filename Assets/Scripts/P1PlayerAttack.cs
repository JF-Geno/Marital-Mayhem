using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1PlayerAttack : MonoBehaviour
{
    public Animator animator;

    private GameObject attackArea = default;

    public Transform firePoint;
    public GameObject projectilePrefab;

  
    private bool attacking = false;
    private bool shooting = false;

    public float targetTime = 0.0f;
    private float timeToAttack = 0.25f;
    private float timer = 0f;

    public GameObject throwNoise;

    public UltimateAbility ultimateAbility;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsRangedAttack", false);

        if (Input.GetKeyDown(KeyCode.C) && !P1Health.isInputDisabled)
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.X) && !P1Health.isInputDisabled)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Z) && !P1Health.isInputDisabled)
        {
            Debug.Log("StartUltimate");

            ultimateAbility.isUltimateActive = true;
           
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                animator.SetBool("Attack", false);
            }
        }
        if (shooting)
        {
            targetTime -= Time.deltaTime;
            if(targetTime <= 0.0f)
            {
                shooting = false;
                targetTime = 0.0f;
            }
        }
        
    }

    private void Attack()
    {
        animator.SetBool("Attack", true);
        attacking = true;
        attackArea.SetActive(attacking);
    }
    private void Shoot()
    {
        if(!shooting)
        {
            animator.SetBool("IsRangedAttack", true);
            targetTime = 1;
            shooting = true;
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            throwNoise.SetActive(false);
            throwNoise.SetActive(true);
        }
    }

    
}