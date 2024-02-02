using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }
    private float timer;
    private float health;
    public HealthBar healthBar;
    public float minusHealth = 0.5f;
    public Light playerLight;

    public event EventHandler<OnDeadEventArgs> OnDead;
    public class OnDeadEventArgs : EventArgs
    {
        public string title;
        public string message;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        //subcribes to the event on enable
        EnemyStateManager.onAttack += TakeDamage;
    }

    private void OnDisable()
    {
        //unsubscribes to the event on disable
        EnemyStateManager.onAttack -= TakeDamage;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 50f)
        {
            health = 50f;
        }
        if(playerLight.range > 50f)
        {
            playerLight.range = 50f;
        }
        healthBar.SetHealth(health);
        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            timer = 0f;
            playerLight.range -= minusHealth;
            health -= minusHealth;
            CheckDeath("Game Over!", "Your Flashlight ran out\nThe darkness consumed you, Try again?");
        }
    }

    public void TakeDamage()
    {
        health -= 2;

        //Play getting hit sound
        AudioManager.PlayAudio("Player Hit");

        CheckDeath("Game Over!", "Killed by Enemy, Try again?");
    }

    private void CheckDeath(string titleTxt, string messageTxt)
    {
        if (health <= 0f)
        {
            OnDead?.Invoke(this, new OnDeadEventArgs
            {
                title = titleTxt,
                message = messageTxt
            }) ;
        }
    }
}
