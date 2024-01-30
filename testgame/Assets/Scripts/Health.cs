using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float timer;
    private float health;
    public HealthBar healthBar;
    public float minusHealth = 1f;
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(health);
        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            timer = 0f;
            health -= minusHealth;
        }
    }
}
