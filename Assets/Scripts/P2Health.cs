using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2Health : MonoBehaviour
{
    private const int MAX_HEALTH = 100;

    private int _health;

    public Image healthBar;

    public Image defenseBar;

    public Image ultimateBar;


    private void Start()

    {

        _health = MAX_HEALTH;

        UpdateUI();

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

        Destroy(gameObject);

    }


    private void UpdateUI()

    {

        healthBar.fillAmount = _health / (float)MAX_HEALTH;

        // Update defense and ultimate bars if needed

        // defenseBar.fillAmount =...;

        // ultimateBar.fillAmount =...;

    }
}