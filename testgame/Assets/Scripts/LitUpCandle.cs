using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitUpCandle : MonoBehaviour
{
    private bool PlayerIn = false;
    public GameObject HealZone;
    public Light LitUp;
    public ThingsChanger candleIsUp;
    public bool CandleIsLitUp = false;

    private void Update() {
        if(PlayerIn == true && Input.GetKeyDown(KeyCode.E) && candleIsUp.candleIsActive == true)
        {
            LitUp.range = 7f;
            CandleIsLitUp = true;
            HealZone.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerIn = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerIn = false;
        }
    }
}
