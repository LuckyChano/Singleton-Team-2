using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public event Action OnEnemyDeath;

    private float _health;
    private int _moneyReward;
    private bool _isDead = false;

    public bool IsDead => _isDead;

    public void Initialize(float health, int reward)
    {
        _health = health;
        _moneyReward = reward;
        _isDead = false;
    }

    public void TakeDamage(float damage)
    {
        if (_isDead) return;

        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (_isDead) return;
        _isDead = true;

        AudioManager.instance.Play("OrcDeath");
        OnEnemyDeath?.Invoke();
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        playerStats.AddMoney(_moneyReward);

        Debug.Log($"{gameObject.name} ha muerto. Recompensa: {_moneyReward} monedas.");

        gameObject.SetActive(false);
    }
}