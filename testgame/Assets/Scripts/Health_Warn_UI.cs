using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Warn_UI : MonoBehaviour
{
    [SerializeField] private Transform HealthWarnUI;

    private Health health;
    private void Start()
    {
        health = Health.Instance;
        health.OnHealthToggle += Instance_OnHealthToggle;
        HealthWarnUI.gameObject.SetActive(false);
    }

    private void Instance_OnHealthToggle(object sender, System.EventArgs e)
    {
       if(health.NormalizedHealth < 0.5f)
        {
            HealthWarnUI.gameObject.SetActive(true);
        }
        else
        {
            HealthWarnUI.gameObject.SetActive(false);
        }
    }
}
