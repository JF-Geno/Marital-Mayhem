using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public P1PlayerAttack p1PlayerAttack;
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

    public P2PlayerAttack p2PlayerAttack;

    protected virtual void Start()
    {
        _health = MAX_HEALTH;
        _defense = MAX_DEFENSE;
        _ultimate = 0;
        _health_2 = MAX_HEALTH;
        _defense_2 = MAX_DEFENSE;
        _ultimate_2 = 0;
        attackArea = transform.GetChild(1).gameObject;
        p1PlayerAttack = GameObject.FindObjectOfType<P1PlayerAttack>();
        p2PlayerAttack = GameObject.FindObjectOfType<P2PlayerAttack>();
    }

    protected virtual void Update()
    {
        if (playerNumControl == 0)
        {
            HandleInputForPlayer0();
        }
        else if (playerNumControl == 1)
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

        ultimateBar.fillAmount = _ultimate / (float)MAX_ULTIMATE;
    }

    void HandleInputForPlayer0()
    {
        // Add any logic you want for playerNumControl 0
        if (Input.GetKeyDown(KeyCode.H))
        {
            // Implement the logic for key H
        }
    }

    void HandleInputForPlayer1()
    {
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
    }

    void HandleInputForPlayer2()
    {
        if (!isInputDisabled)
        {
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
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<P1Health>() != null)
        {
            Debug.Log("Woman got hit");
            KnockBack(collider);
            P1Health health = collider.GetComponent<P1Health>();
            health.Damage(damage, GameValues.DamageTypes.Melee);
            p2PlayerAttack.UltimateLogic();
        }
        
         P2Health p2Health = collider.GetComponent<P2Health>();
        if (p2Health != null)
        {
            p2Health.Damage(damage, GameValues.DamageTypes.Ranged);
            p1PlayerAttack.UltimateLogic();
        }
        Debug.Log(collider.name);
        Destroy(gameObject);
    }


    public void KnockBack(Collider2D collider)
    {
        knockBack.KBCounter = knockBack.KBTotalTime;
        if (collider.transform.position.x <= transform.position.x)
        {
            knockBack.KnockFromRight = true;
        }
        if (collider.transform.position.x > transform.position.x)
        {
            knockBack.KnockFromRight = false;
        }
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
        if(playerNumControl == 1)
        {
                if (amount <= 3)
            {
                _health -= amount;
                Debug.Log($"H: {amount}");
            }
            else if (amount > 3 && _defense > 0)
            {
                _defense -= 2;

                int damageTaken = 10 - _defense;
                int dT = amount + damageTaken;
                Debug.Log($"H: {dT} {damageTaken}");
                _health -= dT;
            }
            else
            {
                int damageTaken = 10 - _defense;
                int dT = amount + damageTaken;
                Debug.Log($"H: {dT} {damageTaken}");
                _health -= dT;
            }

            Debug.Log($"Health: {_health / (float)MAX_HEALTH:P0}");
            Debug.Log($"Defense: {_defense / (float)10:P0}");
        }
        if (playerNumControl == 2)
        {
                if (amount <= 3)
            {
                _health_2 -= amount;
                Debug.Log($"H: {amount}");
            }
            else if (amount > 3 && _defense_2 > 0)
            {
                _defense_2 -= 2;

                int damageTaken = 10 - _defense_2;
                int dT = amount + damageTaken;
                Debug.Log($"H: {dT} {damageTaken}");
                _health_2 -= dT;
            }
            else
            {
                int damageTaken = 10 - _defense_2;
                int dT = amount + damageTaken;
                Debug.Log($"H: {dT} {damageTaken}");
                _health_2 -= dT;
            }

            Debug.Log($"Health: {_health_2 / (float)MAX_HEALTH:P0}");
            Debug.Log($"Defense: {_defense_2 / (float)10:P0}");
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
        if(playerNumControl==1)
        {
            if (_health <= 0)
            {
                Die();
            }
            else
            {
                UpdateHealthUI();
            }   
        }
        if(playerNumControl==2)
        {
            if (_health_2 <= 0)
            {
                Die();
            }
            else
            {
                UpdateHealthUI();
            }   
        }
        
    }

    public void Heal(int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("Cannot have negative healing amount");
            return;
        }

        bool wouldBeOverMaxHealth = _health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            _health = MAX_HEALTH;
        }
        else
        {
            _health += amount;
        }

        Debug.Log($"Health: {_health / (float)MAX_HEALTH:P0}");
        UpdateHealthUI();
    }

    public void AddDefense(int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("Cannot have negative defense amount");
            return;
        }
        if(playerNumControl==1)
        {
            bool wouldBeOverMaxDefense = _defense + amount > MAX_DEFENSE;

            if (wouldBeOverMaxDefense)
            {
                _defense = MAX_DEFENSE;
            }
            else
            {
                _defense += amount;
            }
            Debug.Log($"Defense: {_defense / (float)MAX_DEFENSE:P0}");
        }
        if (playerNumControl==2)
        {
          bool wouldBeOverMaxDefense = _defense_2 + amount > MAX_DEFENSE;

            if (wouldBeOverMaxDefense)
            {
                _defense_2 = MAX_DEFENSE;
            }
            else
            {
                _defense_2 += amount;
            } 
            Debug.Log($"Defense: {_defense_2 / (float)MAX_DEFENSE:P0}"); 
        }
        
        UpdateDefenseUI();
    }

    public void AddUltimate(int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("Cannot have negative ultimate amount");
            return;
        }

        if(playerNumControl == 1)
        {
                bool wouldBeOverMaxUltimate = _ultimate + amount > MAX_ULTIMATE;

            if (wouldBeOverMaxUltimate)
            {
                _ultimate = MAX_ULTIMATE;
            }
            else
            {
                _ultimate += amount;
            }

            Debug.Log($"Ultimate: {_ultimate / (float)MAX_ULTIMATE:P0}"); 
        }
        
        if(playerNumControl == 1)
        {
                bool wouldBeOverMaxUltimate = _ultimate_2 + amount > MAX_ULTIMATE;

            if (wouldBeOverMaxUltimate)
            {
                _ultimate_2 = MAX_ULTIMATE;
            }
            else
            {
                _ultimate_2 += amount;
            }

            Debug.Log($"Ultimate: {_ultimate_2 / (float)MAX_ULTIMATE:P0}"); 
        }
      
        UpdateUltimateUI();
    }

    private void UpdateHealthUI()
    {
        if (playerNumControl == 1)
        {
            healthBar.fillAmount = _health / (float)MAX_HEALTH;
        }
        if (playerNumControl == 2)
        {
            healthBar_2.fillAmount = _health_2 / (float)MAX_HEALTH;
        }
        
    }

    private void UpdateDefenseUI()
    {
        if(playerNumControl == 1)
        {
          defenseBar.fillAmount = _defense / (float)MAX_DEFENSE;  
        }
        if(playerNumControl == 2)
        {
          defenseBar_2.fillAmount = _defense_2 / (float)MAX_DEFENSE;  
        }
        
    }

    private void UpdateUltimateUI()
    {
        if(playerNumControl ==1)
        {
           ultimateBar.fillAmount = _ultimate / (float)MAX_ULTIMATE; 
        }
        if(playerNumControl == 2)
        {
           ultimateBar_2.fillAmount = _ultimate_2 / (float)MAX_ULTIMATE; 
        }
        
    }

    public void Die()
    {
        Debug.Log($"{playerName} is dead");
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
    }

    void OnDrawGizmosSelected()
    {
        if (firePoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(firePoint.position, 1.0f);
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
            animator.SetTrigger("Attack");
        }
    }

    public void HandleAttacking()
    {
        timer += Time.deltaTime;

        if (timer >= timeToAttack)
        {
            attacking = false;
            attackArea.SetActive(attacking);
        }
    }

    public void Shoot()
    {
        if (!shooting)
        {
            shooting = true;
            targetTime = Time.time + 1.0f;

            animator.SetTrigger("Shoot");
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

    public void UltimateTimerLogic()
    {
        if (activeUlt && ultimateTimer < ultimateRegenInterval)
        {
            ultimateTimer += Time.deltaTime;
            return;
        }

        if (activeUlt)
        {
            AddUltimate(1);
            ultimateTimer = 0.0f;
        }
    }

    public void ULT()
    {
        //ultimateAbility.Execute();
        if(playerNumControl == 1)
        {
            _ultimate = 0;
        }
        if(playerNumControl == 2)
        {
            _ultimate_2 = 0;
        }
        activeUlt = false;
        UpdateUltimateUI();
    }
}
