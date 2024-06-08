using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControl : MonoBehaviour
{
  
    public Image healthBar;
    public Image defenseBar;
    public Image ultimateBar;

    public Image healthBar_2;
    public Image defenseBar_2;
    public Image ultimateBar_2;

    public const int MAX_HEALTH = 200;
    public const int MAX_DEFENSE = 10;
    public const int MAX_ULTIMATE = 10;

    public int _health;
    public int _defense;
    public int _ultimate;

    public int _health_2;
    public int _defense_2;
    public int _ultimate_2;

    protected virtual void Start()
    {
        _health = MAX_HEALTH;
        _defense = MAX_DEFENSE;
        _ultimate = 0;

        _health_2 = MAX_HEALTH;
        _defense_2 = MAX_DEFENSE;
        _ultimate_2 = 0;
    }

    public void Update()
    {
        healthBar.fillAmount = _health / (float)MAX_HEALTH;
        defenseBar.fillAmount = _defense / (float)MAX_DEFENSE;
        ultimateBar.fillAmount = _ultimate / (float)MAX_ULTIMATE;

        healthBar_2.fillAmount = _health_2 / (float)MAX_HEALTH;
        defenseBar_2.fillAmount = _defense_2 / (float)MAX_DEFENSE;
        ultimateBar_2.fillAmount = _ultimate_2 / (float)MAX_ULTIMATE;
    }

    public void UpdatePlayer1HUD(int health, int defense, int ultimate)
    {
        _health = health;
        _defense = defense;
        _ultimate = ultimate;
    }

    public void UpdatePlayer2HUD(int health, int defense, int ultimate)
    {
        _health_2 = health;
        _defense_2 = defense;
        _ultimate_2 = ultimate;
    }
}


