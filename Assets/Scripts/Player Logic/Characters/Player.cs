using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
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
    public GameObject CharacterPrefab;

    public int playerNumControl = 0;

    public Image healthBar;
    public Image defenseBar;
    public Image ultimateBar;

    public Image healthBar_2;
    public Image defenseBar_2;
    public Image ultimateBar_2;

    protected const int MAX_HEALTH = 200;
    protected const int MAX_DEFENSE = 10;
    protected const int MAX_ULTIMATE = 10;

    protected int _health;
    protected int _defense;
    protected int _ultimate;

    protected int _health_2;
    protected int _defense_2;
    protected int _ultimate_2;

    public Animator animator;
    public GameObject attackArea = default;
    public const float ultimateRegenInterval = 1.0f;
    public bool activeUlt = false;
    public Transform firePoint;
    public GameObject projectilePrefab;
    public bool attacking = false;
    public bool shooting = false;
    public float targetTime = 0.0f;
    public float timeToAttack = 0.25f;
    public float timer = 0f;
    public GameObject throwNoise;
    public UltimateAbility ultimateAbility;
    public float ultimateTimer = 0.0f;
    public Movement controller;

    public bool isInputDisabled;
    public float runSpeed = 40f;
    public KnockBack knockBack;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    private float defenseTimer = 0.0f;
    private const float defenseRegenInterval = 3.0f;

    public GameOverScreen gameOverScreen;
    public GameObject punchNoise;
    public GameObject projectileNoise;

    public float speed = 20f;
    public int damage = 4;
    public Rigidbody2D rb;
    public float degreesPerSec = 360f;
    private const int maxUltimate = 20;

    //for banner
    public UltimateBannerManager ultimateBannerManager;

    protected virtual void Start()
    {
        _health = MAX_HEALTH;
        _defense = MAX_DEFENSE;
        _ultimate = 0;
        _health_2 = MAX_HEALTH;
        _defense_2 = MAX_DEFENSE;
        _ultimate_2 = 0;
        attackArea = transform.GetChild(1).gameObject;

        animator = animator ?? GetComponent<Animator>();
        rb = rb ?? GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
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

        UltimateTimerLogic();

        if (attacking)
        {
            HandleAttacking();
        }

        if (shooting)
        {
            HandleShooting();
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

    public void KnockBack(Collider2D collider)
    {
        knockBack.KBCounter = knockBack.KBTotalTime;
        knockBack.KnockFromRight = collider.transform.position.x <= transform.position.x;
    }

    public void DamageSound(GameValues.DamageTypes type)
    {
        switch (type)
        {
            case GameValues.DamageTypes.Melee:
                punchNoise.SetActive(false);
                punchNoise.SetActive(true);
                break;

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
            _health = UpdateHealth(amount, _defense, _health);
            Debug.Log($"Player 1 Health: {_health / (float)MAX_HEALTH:P0}");
            Debug.Log($"Player 1 Defense: {_defense / (float)MAX_DEFENSE:P0}");
            UpdateHealthUI();
        }
        else if (playerNumControl == 2)
        {
            _health_2 = UpdateHealth(amount, _defense_2, _health_2);
            Debug.Log($"Player 2 Health: {_health_2 / (float)MAX_HEALTH:P0}");
            Debug.Log($"Player 2 Defense: {_defense_2 / (float)MAX_DEFENSE:P0}");
            UpdateHealthUI();
        }
    }

    private int UpdateHealth(int amount, int defense, int health)
    {
        if (amount <= 3)
        {
            health -= amount;
        }
        else if (amount > 3 && defense > 0)
        {
            defense -= 2;
            int damageTaken = 10 - defense;
            int dT = amount + damageTaken;
            health -= dT;
        }
        else
        {
            int damageTaken = 10 - defense;
            int dT = amount + damageTaken;
            health -= dT;
        }

        return health;
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

        if (playerNumControl == 1 && _health <= 0 || playerNumControl == 2 && _health_2 <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (playerNumControl == 1)
        {
            _health = Mathf.Min(MAX_HEALTH, _health + amount);
        }
        else if (playerNumControl == 2)
        {
            _health_2 = Mathf.Min(MAX_HEALTH, _health_2 + amount);
        }

        UpdateHealthUI();
    }

    public void Die()
    {
        // gameOverScreen.Setup();
        gameObject.SetActive(false);
    }

    private void ULT()
    {
        if (ultimateAbility != null)
        {
            ultimateAbility.isUltimateActive = true;
            animator.SetBool("UltimateIsActive", true);
            animator.SetBool("UltimateStarted", true);
            ultimateBannerManager.ActivateUltBanner(ultimateAbility.ultName, ultimateAbility.ultActivatedVoiceCue);
            activeUlt = false;
        }
    }
    public void UltimateLogic()
    {
        if (playerNumControl == 1)
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
        if (playerNumControl == 2)
        {
            if (ultimateAbility != null && !ultimateAbility.isUltimateActive)
            {
                if (_ultimate_2 < maxUltimate)
                {
                    _ultimate_2 += 1;
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
    }
    public void UltimateTimerLogic()
    {
        ultimateTimer += Time.deltaTime;

        if (ultimateTimer >= ultimateRegenInterval)
        {
            ultimateTimer = 0.0f;
            _ultimate = Mathf.Min(MAX_ULTIMATE, _ultimate + 1);
            _ultimate_2 = Mathf.Min(MAX_ULTIMATE, _ultimate_2 + 1);

            if (_ultimate == MAX_ULTIMATE || _ultimate_2 == MAX_ULTIMATE)
            {
                activeUlt = true;
            }

            ultimateBar.fillAmount = _ultimate / (float)MAX_ULTIMATE;
            ultimateBar_2.fillAmount = _ultimate_2 / (float)MAX_ULTIMATE;
        }
    }

    public void Attack()
    {
        if (!attacking)
        {
            timer = 0f;
            attacking = true;
            attackArea.SetActive(attacking);
            punchNoise.SetActive(false);
            punchNoise.SetActive(true);
            animator.SetBool("Attack", true);
        }
    }

    public void HandleAttacking()
    {
        timer += Time.deltaTime;

        if (timer >= timeToAttack)
        {
            attacking = false;
            attackArea.SetActive(attacking);
            animator.SetBool("Attack", false);
        }
    }

    public void Shoot()
    {
        if (!shooting)
        {
            shooting = true;
            targetTime = Time.time + 1.0f;
            animator.SetBool("IsRangedAttack", true);
            projectileNoise.SetActive(false);
            projectileNoise.SetActive(true);
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }

    public void HandleShooting()
    {
        if (shooting && Time.time >= targetTime)
        {
            shooting = false;
        }
    }

    private void UpdateHealthUI()
    {
        healthBar.fillAmount = _health / (float)MAX_HEALTH;
        defenseBar.fillAmount = _defense / (float)MAX_DEFENSE;
        ultimateBar.fillAmount = _ultimate / (float)MAX_ULTIMATE;

        healthBar_2.fillAmount = _health_2 / (float)MAX_HEALTH;
        defenseBar_2.fillAmount = _defense_2 / (float)MAX_DEFENSE;
        ultimateBar_2.fillAmount = _ultimate_2 / (float)MAX_ULTIMATE;
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