using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private float timer;
    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyStateManager>()?.TakeDamage();
            Destroy(gameObject);
        }
        else if(!other.gameObject.CompareTag("Player") && other.GetComponent<Collider>().isTrigger == false)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5)
        {
            Destroy(gameObject);
        }

    }


}
