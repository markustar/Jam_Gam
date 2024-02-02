using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEmemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public LitUpCandle LitUp;
    private float timer;

    private Vector3 randomPosition;

    private float min = 20f;
    private float max = 30f;

    private void Start()
    {
        timer = Random.Range(min, max);
    }
    void Update()
    {
        if (LitUp.CandleIsLitUp == true) return;
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            randomPosition = new Vector3(UnityEngine.Random.Range(transform.position.x-1, transform.position.x+1), transform.position.y+2, UnityEngine.Random.Range(transform.position.z-1, transform.position.z+1));
            
   
            timer = Random.Range(min, max);
            GameManager.Instance.IncrementEnemies();
            Instantiate(enemyPrefab, randomPosition, transform.rotation);
            
        }
        
    }
}
