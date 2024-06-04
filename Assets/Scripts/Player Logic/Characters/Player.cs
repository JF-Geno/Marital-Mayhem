using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int playerId;
    public string playerName;
    public Image PlayerNameImage;
    public Image CharacterAbilityM;
    public Image CharacterAbilityR;
    public Image CharacterAbilityU;
    public int nameIScale;
    public int nameIPositionX = 0;
    public int nameIPositionY = 0;
    public Image headShot;
    public GameObject CharacterPrefab;

    public int playerNumControl = 0;
     
    public Image healthBar;
    public Image defenseBar;
    public Image ultimateBar;

    public Image healthBar_2;
    public Image defenseBar_2;
    public Image ultimateBar_2;

    protected const int MAX_HEALTH = 100;
    protected const int MAX_DEFENSE = 10;
    protected const int MAX_ULTIMATE = 10;

    protected int _health;
    protected int _defense;
    protected int _ultimate;

    public Animator animator;
    private GameObject attackArea = default;
    private const float ultimateRegenInterval = 1.0f;
    private const int maxUltimate = 10;
    private bool activeUlt = false;
    public Transform firePoint;
    public GameObject projectilePrefab;
    private bool attacking = false;
    private bool shooting = false;
    public float targetTime = 0.0f;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    public GameObject throwNoise;
    public UltimateAbility ultimateAbility;
    private float ultimateTimer = 0.0f;
    public Movement controller;
    
    public bool isInputDisabled;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    protected virtual void Start()
    {
        attackArea = transform.GetChild(1).gameObject;
        _health = MAX_HEALTH;
        _defense = MAX_DEFENSE;
        _ultimate = 0;
        

    }

    void Update()
    {
        if (playerNumControl == 0)
        {
            // Add any logic you want for playerNumControl 0
             if (Input.GetKeyDown(KeyCode.H))

        {
            
        }

     

        }
        else if (playerNumControl == 1)
        {
            

            if (Input.GetKeyDown(KeyCode.C) && !isInputDisabled)
            {
                Attack();
            }
            if (Input.GetKeyDown(KeyCode.X) && !isInputDisabled)
            {
                Shoot();
            }
            if (Input.GetKeyDown(KeyCode.Z) && !isInputDisabled && activeUlt)
            {
                 if (activeUlt == true)
            {
                ULT(); 
            }
            else{
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

        
        if (!isInputDisabled)
        {

            horizontalMove = Input.GetAxisRaw("Horizontal P1") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump P1"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("Crouch P1"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch P1"))
            {
                crouch = false;
            }
        }


        }
        else if (playerNumControl == 2)
        {
            if (Input.GetKeyDown(KeyCode.Slash) && !isInputDisabled)
            {
                Attack();
            }
            if (Input.GetKeyDown(KeyCode.Period) && !isInputDisabled)
            {
                Shoot();
            }
            if (Input.GetKeyDown(KeyCode.Comma) && !isInputDisabled && activeUlt)
            {
                    if (activeUlt == true)
            {
                ULT(); 
            }
            else{
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
                if(targetTime <= 0.0f)
                {
                    shooting = false;
                    targetTime = 0.0f;
                }
            }
            ultimateBar.fillAmount = _ultimate / (float)maxUltimate;
            UltimateTimerLogic();

            if (!isInputDisabled)
        {

            horizontalMove = Input.GetAxisRaw("Horizontal P2") * runSpeed;

            animator.SetFloat("Speed",  Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump P2"))
            {
                jump = true;
                animator.SetBool("IsJumping",  true);
            }
            if (Input.GetButtonDown("Crouch P2"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch P2"))
            {
                crouch = false;
            }
        }
        }
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

            if (_ultimate == maxUltimate)
            {
                activeUlt = true;
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
                _ultimate -= 2;

                if (_ultimate <= 0)
                {
                    _ultimate = 0;
                    activeUlt = false;
                    ultimateAbility.isUltimateActive = false;
                }
            }
        }
    }

    private void ULT()
    {
        if (ultimateAbility != null)
        {
            ultimateAbility.isUltimateActive = true;
        }
    }

    public void OnLanding()
        {
            animator.SetBool("IsJumping", false);
        }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate()
        {
            // Move our character
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
        
}
