using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float timer;
    private float health;
    public HealthBar healthBar;
    public float minusHealth = 0.5f;
    public Light playerLight;
    // Start is called before the first frame update
    void Start()
    {
        health = 50f;
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
        }
    }
}
