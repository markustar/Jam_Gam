using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counters_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemiesTxt;
    [SerializeField] private TextMeshProUGUI candlesTxt;

    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.OnToggleEnemies += OnEnemiesToggled;
        gameManager.OnToggleCandle += GameManager_OnLitCandles;
        candlesTxt.text = "0";
        enemiesTxt.text = "0";
        
    }



     private void GameManager_OnLitCandles(object sender, System.EventArgs e)
    {
        candlesTxt.text = gameManager.CandlesUnlit.ToString();
    }

    private void OnEnemiesToggled(object sender, System.EventArgs e)
    {
        enemiesTxt.text = gameManager.EnemiesAlive.ToString();
    }
}
