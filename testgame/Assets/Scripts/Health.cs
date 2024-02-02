using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }

    private float timer;
    private float health;
    private float healthMax = 50f;
    public HealthBar healthBar;
    public float minusHealth = 0.5f;
    public Light playerLight;
    public float NormalizedHealth { get { return health / healthMax; } }
    private float healthDecay = 2f;
    public bool IsNearCandle = false;

    public event EventHandler OnHealthToggle;
    public event EventHandler<OnDeadEventArgs> OnDead;
    public class OnDeadEventArgs : EventArgs
    {
        public string title;
        public string message;
    }

    private void Awake()
    {
        Instance = this;
        timer = healthDecay;
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
        health = healthMax;
        healthBar.SetHealth(NormalizedHealth);
        OnHealthToggle?.Invoke(this, EventArgs.Empty);
    }

    // Update is called once per frame
    void Update()
    {


        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            if (!IsNearCandle)
            {
                //Decay
                
                timer = healthDecay;
                if (playerLight.range > healthMax)
                    playerLight.range = healthMax;
                health -= 1f;
                if(health < 0f)
                    health = 0f;
               
                
            }
            else
            {
                //Heal
                health += 1f;
                if(health > healthMax)
                    health = healthMax;
                timer =1f;
            }
    
            healthBar.SetHealth(NormalizedHealth);
            OnHealthToggle?.Invoke(this, EventArgs.Empty);
            CheckDeath("Game Over!", "Your Flashlight ran out\nThe darkness consumed you, Try again?");
        }

            
       

    }



    public void ChangeHealth(int amount)
    {
        minusHealth += amount;
        OnHealthToggle?.Invoke(this, EventArgs.Empty);
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
