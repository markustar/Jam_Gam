using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    private Shooting shooting;
    private Health PlayerHealth;

    private void Start()
    {
        PlayerHealth = Health.Instance;
        shooting = Shooting.Instance;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.PlayAudio("Candle Healing");
            PlayerHealth.minusHealth = -1f;
            shooting.AbleToShoot = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.StopAudio("Candle Healing");
            PlayerHealth.minusHealth = 1f;
            shooting.AbleToShoot = true;
        }
    }

}
