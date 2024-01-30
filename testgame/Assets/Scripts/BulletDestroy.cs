using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private float timer;
    private void OnTriggerEnter(Collider other) {
        if(!other.gameObject.CompareTag("Player") && other.GetComponent<Collider>().isTrigger == false)
        {
            Destroy(gameObject); // Destroy the projectile when it collides with something
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
