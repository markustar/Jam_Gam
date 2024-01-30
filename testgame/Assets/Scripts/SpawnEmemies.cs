using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEmemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public LitUpCandle LitUp;
    private float timer;

    private Vector3 randomPosition;



    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10)
        {
            randomPosition = new Vector3(UnityEngine.Random.Range(transform.position.x-1, transform.position.x+1), transform.position.y+2, UnityEngine.Random.Range(transform.position.z-1, transform.position.z+1));
            
            if (LitUp.CandleIsLitUp == false)
            {
                timer = 0f;
                Instantiate(enemyPrefab, randomPosition, transform.rotation);
            }
        }
        
    }
}
