using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2PlayerAttack : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash) && !P2Health.isInputDisabled)
        {
            animator.SetBool("Attack", true);
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Period)  && !P2Health.isInputDisabled)
        {
            animator.SetBool("IsRangedAttack", true);
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Comma)  && !P2Health.isInputDisabled)
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
                animator.SetBool("Attack", false);
            }
        }
        if (shooting)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0.0f)
            {
                shooting = false;
                targetTime = 0.0f;
                animator.SetBool("IsRangedAttack", false);
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
       
        if (!shooting)
        {
            targetTime = 1;
            shooting = true;
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            throwNoise.SetActive(false);
            throwNoise.SetActive(true);
        }
    }
}