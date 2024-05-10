using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2Health : MonoBehaviour
{
    private const int MAX_HEALTH = 100;

    private int _health;

    private int _defense;
    public Image healthBar;

    public Image defenseBar;

    public Image ultimateBar;

    public GameOverScreen gameOverScreen;

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
            _health -= amount;
            Debug.Log($"H: {amount} ");
        }else if(amount > 3 && _defense > 0)
        {
            _defense-=2;

            int damageTaken = 10 -_defense;
            int dT = amount + damageTaken;
            Debug.Log($"H: {dT} {damageTaken}");
            _health -= dT;
        }
        else
        {
            int damageTaken = 10 -_defense;
            int dT = amount + damageTaken;
            Debug.Log($"H: {dT} {damageTaken}");
            _health -= dT;
        }
        
        Debug.Log($"Health: {_health/ (float)MAX_HEALTH:P0}");
        Debug.Log($"Defense: {_defense/(float)10:P0}");
    }

    private void Update()

    {
        if (Input.GetKeyDown(KeyCode.H))

        {
            Heal(10);
        }
    }

    public void Damage(int amount)

    {
        if (amount <= 0)

        {
            Debug.LogWarning("Cannot have negative damage amount");

            return;
        }

        _health -= amount;

        Debug.Log($"Health: {_health / (float)MAX_HEALTH:P0}");

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
        defenseBar.fillAmount = _defense/(float)10;

        // ultimateBar.fillAmount =...;
    }
}