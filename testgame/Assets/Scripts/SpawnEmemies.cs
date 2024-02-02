using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEmemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public LitUpCandle LitUp;
    private float timer;
    private float min = 10f;
    private float max = 20f;

    private Vector3 randomPosition;

    private void Start()
    {
        timer = Random.Range(min, max);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            randomPosition = new Vector3(Random.Range(transform.position.x-1, transform.position.x+1), transform.position.y+2, Random.Range(transform.position.z-1, transform.position.z+1));
            
            if (LitUp.CandleIsLitUp == false)
            {
                timer = Random.Range(min, max);
                Instantiate(enemyPrefab, randomPosition, transform.rotation);
            }
        }
        
    }
}
