using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public Shooting shooting;
    public Health PlayerHealth;

    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.minusHealth = -0.5f;
            shooting.AbleToShoot = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.minusHealth = 0.5f;
            shooting.AbleToShoot = true;
        }
    }

}
