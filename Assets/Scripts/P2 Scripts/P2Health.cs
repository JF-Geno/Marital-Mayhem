using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2Health : MonoBehaviour
{
    private const int MAX_HEALTH = 111;

    private int _health;

    private int _defense;

    private float defenseTimer = 0.0f;
    private const float defenseRegenInterval = 3.0f;

    public static bool isInputDisabled = false;

    public float lowStun = 1f;
    public float highStun = 2f;

    public Image healthBar;

    public Image defenseBar;

    public Image ultimateBar;

    public GameOverScreen gameOverScreen;

    public GameObject punchNoise;
    public GameObject projectileNoise;

    private void Start()

    {
        _health = MAX_HEALTH;

        _defense = 10;

        UpdateUI();
    }
    public void healthController(int amount)
    {
        if (amount <= 3)
        {
            punchNoise.SetActive(false);
            punchNoise.SetActive(true);
            _health -= amount;
            Debug.Log($"H: {amount} ");
        }
        else if (amount > 3 && _defense > 0)
        {
            projectileNoise.SetActive(false);
            projectileNoise.SetActive(true);
            _defense -= 2;

            int damageTaken = 10 - _defense;
            int dT = amount + damageTaken;
            Debug.Log($"H: {dT} {damageTaken}");
            _health -= dT;
        }
        else
        {
            projectileNoise.SetActive(false);
            projectileNoise.SetActive(true);
            int damageTaken = 10 - _defense;
            int dT = amount + damageTaken;
            Debug.Log($"H: {dT} {damageTaken}");
            _health -= dT;
        }

        Debug.Log($"Health: {_health / (float)MAX_HEALTH:P0}");
        Debug.Log($"Defense: {_defense / (float)10:P0}");
    }

    private void Update()

    {
        if (Input.GetKeyDown(KeyCode.H))

        {
            Heal(10);
        }

        if (_defense < 10)
        {
            defenseTimer += Time.deltaTime;
            if (defenseTimer >= defenseRegenInterval)
            {
                defenseTimer = 0.0f;
                _defense += 2;
                if (_defense > 10)
                {
                    _defense = 10;
                }
                UpdateUI();
            }
        }
    }

    public void Damage(int amount)

    {
        if (amount <= 0)

        {
            Debug.LogWarning("Cannot have negative damage amount");

            return;
        }

        healthController(amount);

        if (_health <= 0)

        {
            Die();
        }
        else

        {
            UpdateUI();
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

        UpdateUI();
    }

    public void Die()

    {
        Debug.Log("I am Dead!");
        gameOverScreen.Setup(GameValues.player1Name);
        Destroy(gameObject);
    }

    private void UpdateUI()

    {
        healthBar.fillAmount = _health / (float)MAX_HEALTH;
        defenseBar.fillAmount = _defense / (float)10;

        // ultimateBar.fillAmount =...;
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
}