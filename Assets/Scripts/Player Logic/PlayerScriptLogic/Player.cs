using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Player stats
    public int playerId;
    public string playerName;
    public Sprite PlayerNameImage;
    public Image CharacterAbilityM;
    public Image CharacterAbilityR;
    public Image CharacterAbilityU;
    public int nameIScale;
    public int nameIPositionX = 0;
    public int nameIPositionY = 0;
    public Sprite headShot;
    public Player CharacterPrefab;
    public int playerNumControl = 0;

    // Movement
    public Movement controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Health
    public bool isInputDisabled = false;
    private float defenseTimer = 0.0f;

    // Attack
    public float ultimateTimer = 0.0f;
    private GameObject attackArea = default;
    private const int maxUltimate = 20;
    private const int ultimateDecrease = 4;
    public bool activeUlt = false;
    public Transform firePoint;
    public GameObject projectilePrefab;
    public bool attacking = false;
    public bool shooting = false;
    public float targetTime = 0.0f;
    public float timeToAttack = 0.25f;
    public float timer = 0f;
    public UltimateAbility ultimateAbility;
    private const float defenseRegenInterval = 3.0f;
    public const float ultimateRegenInterval = 1.0f;

    // Sound Board
    public GameObject throwNoise;
    public GameObject projectileNoise;

    // Banner
    public UltimateBannerManager ultimateBannerManager;

    // HUD
    public HUDControl HUD;

    protected virtual void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        attackArea = transform.GetChild(1).gameObject;
        animator = animator ?? GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        UltimateTimerLogic();
        animator.SetBool("IsRangedAttack", false);
        animator.SetBool("UltimateStarted", false);
        if (playerNumControl == 1)
        {
            HandleInputForPlayer1();
        }
        else if (playerNumControl == 2)
        {
            HandleInputForPlayer2();
        }
        if (attacking)
        {
            HandleAttacking();
        }
        if (shooting)
        {
            HandleShooting();
        }
        if (playerNumControl == 1)
        {
            try
            {
                if (HUD._defense < HUDControl.MAX_DEFENSE)
                {
                    defenseTimer += Time.deltaTime;
                    if (defenseTimer >= defenseRegenInterval)
                    {
                        defenseTimer = 0.0f;
                        HUD._defense += 2;
                        if (HUD._defense > HUDControl.MAX_DEFENSE)
                        {
                            HUD._defense = HUDControl.MAX_DEFENSE;
                        }
                        HUD.UpdatePlayer1HUD(HUD._health, HUD._defense, HUD._ultimate);
                    }
                }
            }
            catch
            {
            }
        }
        else if (playerNumControl == 2)
        {
            try
            {
                if (HUD._defense_2 < HUDControl.MAX_DEFENSE)
                {
                    defenseTimer += Time.deltaTime;
                    if (defenseTimer >= defenseRegenInterval)
                    {
                        defenseTimer = 0.0f;
                        HUD._defense_2 += 2;
                        if (HUD._defense_2 > HUDControl.MAX_DEFENSE)
                        {
                            HUD._defense_2 = HUDControl.MAX_DEFENSE;
                        }
                        HUD.UpdatePlayer2HUD(HUD._health_2, HUD._defense_2, HUD._ultimate_2);
                    }
                }
            }
            catch
            {
            }
        }
    }

    void HandleInputForPlayer1()
    {
        if (isInputDisabled) return;

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

        if (Input.GetKeyDown(KeyCode.C))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Z) && activeUlt)
        {
            ULT();
        }
    }

    void HandleInputForPlayer2()
    {
        if (isInputDisabled) return;

        horizontalMove = Input.GetAxisRaw("Horizontal P2") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump P2"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch P2"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch P2"))
        {
            crouch = false;
        }

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Comma) && activeUlt)
        {
            ULT();
        }
    }

    public void DamageSound(GameValues.DamageTypes type)
    {
        switch (type)
        {
            case GameValues.DamageTypes.Ranged:
                projectileNoise.SetActive(false);
                projectileNoise.SetActive(true);
                break;
        }
    }

    public void healthController(int amount)
    {
        if (playerNumControl == 1)
        {
            if (amount <= 3)
            {
                HUD.UpdatePlayer1HUD(HUD._health - amount, HUD._defense, HUD._ultimate);
                //Debug.Log($"H: {amount}");
            }
            else if (amount > 3 && HUD._defense > 0)
            {
                HUD.UpdatePlayer1HUD(HUD._health - amount, HUD._defense - 2, HUD._ultimate);
                int damageTaken = 10 - HUD._defense;
                int dT = amount + damageTaken;
                //Debug.Log($"H: {dT} {damageTaken}");
            }
            else
            {
                int damageTaken = 10 - HUD._defense;
                int dT = amount + damageTaken;
                Debug.Log($"H: {dT} {damageTaken}");
                HUD.UpdatePlayer1HUD(HUD._health - dT, HUD._defense, HUD._ultimate);
            }
        }
        else if (playerNumControl == 2)
        {
            if (amount <= 3)
            {
                HUD.UpdatePlayer2HUD(HUD._health_2 - amount, HUD._defense_2, HUD._ultimate_2);
                Debug.Log($"H: {amount}");
            }
            else if (amount > 3 && HUD._defense_2 > 0)
            {
                HUD.UpdatePlayer2HUD(HUD._health_2 - amount, HUD._defense_2 - 2, HUD._ultimate_2);
                int damageTaken = 10 - HUD._defense_2;
                int dT = amount + damageTaken;
                Debug.Log($"H: {dT} {damageTaken}");
            }
            else
            {
                int damageTaken = 10 - HUD._defense_2;
                int dT = amount + damageTaken;
                Debug.Log($"H: {dT} {damageTaken}");
                HUD.UpdatePlayer2HUD(HUD._health_2 - dT, HUD._defense_2, HUD._ultimate_2);
            }
        }
    }

    public void Damage(int amount, GameValues.DamageTypes damageType)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("Cannot have negative damage amount");
            return;
        }

        healthController(amount);

        DamageSound(damageType);

        if (playerNumControl == 1 && HUD._health <= 0 || playerNumControl == 2 && HUD._health_2 <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (playerNumControl == 2)
        {
            GameValues.PlayerWin = "P1";
            GameValues.player1Wins++;
            SceneManager.LoadScene(4);
        }
        else if (playerNumControl == 1)
        {
            GameValues.PlayerWin = "P2";
            GameValues.player2Wins++;
            SceneManager.LoadScene(4);
        }
    }

    public void Stun(float stunTime)
    {
        isInputDisabled = true;
        StartCoroutine(EnableInputAfterSeconds(stunTime));
    }

    IEnumerator EnableInputAfterSeconds(float duration)
    {
        yield return new WaitForSeconds(duration);
        isInputDisabled = false;
    }

    private void ULT()
    {
        if (ultimateAbility != null)
        {
            ultimateAbility.isUltimateActive = true;
            animator.SetBool("UltimateIsActive", true);
            animator.SetBool("UltimateStarted", true);
            Debug.Log(ultimateBannerManager == null);
            ultimateBannerManager.ActivateUltBanner(ultimateAbility.ultName, ultimateAbility.ultActivatedVoiceCue);
        }
    }

    public void UltimateLogic()
    {
        if (playerNumControl == 1)
        {
            if (ultimateAbility != null && !ultimateAbility.isUltimateActive)
            {
                if (HUD._ultimate < HUDControl.MAX_ULTIMATE)
                {
                    HUD.UpdatePlayer1HUD(HUD._health, HUD._defense, HUD._ultimate + 2);
                    Debug.Log("Ultimate charge increased");
                }

                if (HUD._ultimate == HUDControl.MAX_ULTIMATE && !activeUlt)
                {
                    activeUlt = true;
                    ultimateBannerManager.UltReady(ultimateAbility.ultReadyVoiceCue);
                }
            }
        }
        else if (playerNumControl == 2)
        {
            if (ultimateAbility != null && !ultimateAbility.isUltimateActive)
            {
                if (HUD._ultimate_2 < HUDControl.MAX_ULTIMATE)
                {
                    HUD.UpdatePlayer2HUD(HUD._health_2, HUD._defense_2, HUD._ultimate_2 + 2);
                    Debug.Log("Ultimate charge increased");
                }

                if (HUD._ultimate_2 == HUDControl.MAX_ULTIMATE && !activeUlt)
                {
                    activeUlt = true;
                    ultimateBannerManager.UltReady(ultimateAbility.ultReadyVoiceCue);
                }
            }
        }
    }

    public void UltimateTimerLogic()
    {
        if (playerNumControl == 1)
        {
            if (ultimateAbility != null && ultimateAbility.isUltimateActive)
            {
                ultimateTimer += Time.deltaTime;

                if (ultimateTimer >= ultimateRegenInterval)
                {
                    ultimateTimer = 0.0f;
                    HUD._ultimate -= 2;
                    if (HUD._ultimate <= 0)
                    {
                        HUD._ultimate = 0;
                        activeUlt = false;
                        ultimateAbility.isUltimateActive = false;
                        animator.SetBool("UltimateIsActive", false);
                    }
                }
            }
        }
        else if (playerNumControl == 2)
        {
            if (ultimateAbility != null && ultimateAbility.isUltimateActive)
            {
                ultimateTimer += Time.deltaTime;

                if (ultimateTimer >= ultimateRegenInterval)
                {
                    ultimateTimer = 0.0f;
                    HUD._ultimate_2 -= 2;
                    if (HUD._ultimate_2 <= 0)
                    {
                        HUD._ultimate_2 = 0;
                        activeUlt = false;
                        ultimateAbility.isUltimateActive = false;
                        animator.SetBool("UltimateIsActive", false);
                    }
                }
            }
        }
    }

    public void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        animator.SetBool("Attack", true);
    }

    public void HandleAttacking()
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

    public void Shoot()
    {
        if (!shooting)
        {
            throwNoise.SetActive(false);
            throwNoise.SetActive(true);
            animator.SetBool("IsRangedAttack", true);
            targetTime = 1;
            shooting = true;
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }
    public void HandleShooting()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            shooting = false;
            targetTime = 0.0f;
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
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}