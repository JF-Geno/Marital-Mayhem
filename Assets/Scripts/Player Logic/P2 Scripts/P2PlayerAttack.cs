using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2PlayerAttack : MonoBehaviour
{
    public Animator animator;

    private GameObject attackArea = default;

    private int _ultimate;
    public Image ultimateBar;
    private float ultimateTimer = 0.0f;
    private const float ultimateRegenInterval = 1.0f;
    private const int maxUltimate = 20;
    private const int ultimateDecrease = 4;

    private bool activeUlt = false;

    public Transform firePoint;
    public GameObject projectilePrefab;

    private bool attacking = false;
    private bool shooting = false;

    public float targetTime = 0.0f;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    public UltimateAbility ultimateAbility;
    public GameObject throwNoise;

    //for banner
    public UltimateBannerManager ultimateBannerManager;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(1).gameObject;

        _ultimate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsRangedAttack", false);
        animator.SetBool("UltimateStarted", false);

        if (Input.GetKeyDown(KeyCode.Slash) && !P2Health.isInputDisabled)
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Period) && !P2Health.isInputDisabled)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Comma) && !P2Health.isInputDisabled)
        {
            if (activeUlt == true)
            {
                ULT();
            }
            else
            {
                Debug.Log("Not yet");
            }
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
            }
        }

        ultimateBar.fillAmount = _ultimate / (float)maxUltimate;
        UltimateTimerLogic();
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        animator.SetBool("Attack", true);
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
            animator.SetBool("IsRangedAttack", true);
        }
    }

    public void UltimateLogic()
    {
        if (ultimateAbility != null && !ultimateAbility.isUltimateActive)
        {
            if (_ultimate < maxUltimate)
            {
                _ultimate += 1;
                Debug.Log("Ultimate charge increased");
            }

            if (_ultimate == maxUltimate && !activeUlt)
            {
                activeUlt = true;
                //for banner
                ultimateBannerManager.UltReady(ultimateAbility.ultReadyVoiceCue);
            }
        }
    }

    private void UltimateTimerLogic()
    {
        if (ultimateAbility != null && ultimateAbility.isUltimateActive)
        {
            ultimateTimer += Time.deltaTime;

            if (ultimateTimer >= ultimateRegenInterval)
            {
                ultimateTimer = 0.0f;
                _ultimate -= ultimateDecrease;

                if (_ultimate <= 0)
                {
                    _ultimate = 0;
                    activeUlt = false;
                    ultimateAbility.isUltimateActive = false;
                    animator.SetBool("UltimateIsActive", false);
                    //for banner
                    ultimateBannerManager.DeactivateUltBanner();
                }
            }
        }
    }

    private void ULT()
    {
        if (ultimateAbility != null)
        {
            ultimateAbility.isUltimateActive = true;
            animator.SetBool("UltimateIsActive", true);
            animator.SetBool("UltimateStarted", true);
            //for banner
            ultimateBannerManager.ActivateUltBanner(ultimateAbility.ultName, ultimateAbility.ultActivatedVoiceCue);
        }
    }
}