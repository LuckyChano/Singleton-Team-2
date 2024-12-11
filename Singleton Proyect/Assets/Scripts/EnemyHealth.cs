using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float _health;
    private int _moneyReward;

    public void Initialize(float health, int reward)
    {
        _health = health;
        _moneyReward = reward;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        playerStats.AddMoney(_moneyReward);
        gameObject.SetActive(false);
    }
}