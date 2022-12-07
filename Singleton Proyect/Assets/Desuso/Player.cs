using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerLifeSistem
{
    //Variables Estaticas

    //Variables Publicas por Referencia
    //public Animator screenFx;
    //public GameObject deathScreen;

    //public Animator screenFx;

    //Variables Privadas por Referencia
    private Inputs _playerInputs;

    //Variables Publicas
    public float playerLife = 100;

    //Variables Privadas

    //Delegados

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        _playerInputs = new Inputs(this);

        StartLife(playerLife);
        //StartUI();
    }

    void Update()
    {
        if (IsAlive)
            _playerInputs.ArtificialUpdate();
    }

    void FixedUpdate()
    {
        if (IsAlive)
            _playerInputs.ArtificialFixedUpdate();
    }

    //-------------------------------------------------------------------------------------------------------------------------------------

    public void Scream()
    {
        //EventManager.Trigger(EventManager.NameEvent.Fear);
    }

    public override void TakeDamage(float value)
    {
        _currentHealth -= value;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;

            Die();
        }

        //screenFx.SetTrigger("hit");

        //AudioManager.instance.Play("PlayerHurt");

        //UpdateUI();
    }

    public override void Heal(float value)
    {
        _currentHealth += value;

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        //Agregar FeedBack

        //UpdateUI();
    }

    public override void Die()
    {
        _isAlive = false;

        Cursor.lockState = CursorLockMode.None;

        //screenFx.SetTrigger("die");

        var timer = 0f;
        timer += Time.deltaTime * 2;

        if (timer > 0.5f)
        {
            Time.timeScale = 0;
        }
    }
}
