using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorrderScript : MonoBehaviour
{
    public GameManager gameManager;


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            gameManager.SetTitleTxt("Game Over");
            gameManager.SetMessageTxt("The darkness consumed you, Try again?");
            gameManager.GoToGameOver();
        }
    }
}
