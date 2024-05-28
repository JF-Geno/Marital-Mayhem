using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    protected const int MAX_HEALTH = 100;
    protected const int MAX_DEFENSE = 10;
    protected const int MAX_ULTIMATE = 10;

    protected int _health;
    protected int _defense;
    protected int _ultimate;

    protected bool isInputDisabled = false;

    public Image healthBar;
    public Image defenseBar;
    public Image ultimateBar;
    public GameOverScreen gameOverScreen;

    protected float ultimateTimer = 0.0f;
    protected const float ultimateRegenInterval = 1.0f;

    public int playerController;

    public Movement controller;
    public Animator animator;
    public GameObject punchNoise;
    public GameObject projectileNoise;
    public Transform firePoint;
    public GameObject projectilePrefab;
    public GameObject throwNoise;
    public UltimateAbility ultimateAbility;
    public KnockBack knockBack;
    public P1PlayerAttack p1PlayerAttack;

    public float runSpeed = 40f;
    public float lowStun = 1f;
    public float highStun = 2f;
    public float targetTime = 0.0f;
    public float degreesPerSec = 360f;
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;
    private bool attacking = false;
    private bool shooting = false;
    private bool activeUlt = false;
    private float defenseTimer = 0.0f;
    private const float defenseRegenInterval = 3.0f;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private Rigidbody2D m_Rigidbody2D;
    private GameObject attackArea;

    protected virtual void Start()
    {
        _health = MAX_HEALTH;
        _defense = MAX_DEFENSE;
        _ultimate = 0;
        UpdateHealthUI();

        attackArea = transform.GetChild(1).gameObject;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        p1PlayerAttack = FindObjectOfType<P1PlayerAttack>();
    }

    protected void UpdateHealthUI()
    {
        if (healthBar != null)
            healthBar.fillAmount = _health / (float)MAX_HEALTH;

        if (defenseBar != null)
            defenseBar.fillAmount = _defense / (float)MAX_DEFENSE;

        if (ultimateBar != null)
            ultimateBar.fillAmount = _ultimate / (float)MAX_ULTIMATE;
    }

    public void Damage(int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("Cannot have negative damage amount");
            return;
        }

        _health -= amount;

        if (_health <= 0)
            Die();
        else
            UpdateHealthUI();
    }

    public void Heal(int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("Cannot have negative healing amount");
            return;
        }

        _health = Mathf.Min(_health + amount, MAX_HEALTH);
        UpdateHealthUI();
    }

    protected virtual void Die()
    {
        Debug.Log("Character is Dead!");
        // Implement death logic here
    }

    private void Update()
    {
        Rotate();
        HandleInput();
        UltimateTimerLogic();
    }

    private void Rotate()
    {
        float rotAmount = degreesPerSec * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
    }

    private void HandleInput()
    {
        if (isInputDisabled) return;

        horizontalMove = Input.GetAxisRaw($"Horizontal P{playerController}") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown($"Jump P{playerController}"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown($"Crouch P{playerController}"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp($"Crouch P{playerController}"))
        {
            crouch = false;
        }

        if (playerController == 1)
        {
            HandlePlayer1Input();
        }
        else if (playerController == 2)
        {
            HandlePlayer2Input();
        }
    }

    private void HandlePlayer1Input()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }

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
            ULT();
        }
    }

    private void HandlePlayer2Input()
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
            ULT();
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleKnockback();
    }

    private void HandleMovement()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void HandleKnockback()
    {
        if (KBCounter > 0)
        {
            m_Rigidbody2D.velocity = knockBack.KnockFromRight ? new Vector2(-KBForce, KBForce / 3) : new Vector2(KBForce, KBForce / 3);
            KBCounter -= Time.deltaTime;
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
        if (!shooting)
        {
            animator.SetBool("IsRangedAttack", true);
            targetTime = 1;
            shooting = true;
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            throwNoise.SetActive(false);
            throwNoise.SetActive(true);
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

                UpdateHealthUI();
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<P2Health>() != null)
        {
            KB1(collider);
            P2Health health = collider.GetComponent<P2Health>();
            health.Damage(10); // Assuming 10 is the damage amount, replace with actual value
            p1PlayerAttack.UltimateLogic();
        }
    }

    public void KB1(Collider2D collider)
    {
        knockBack.KBCounter = knockBack.KBTotalTime;
        knockBack.KnockFromRight = collider.transform.position.x <= transform.position.x;
    }

    private void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
}
