﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_UI : MonoBehaviour
{
    public AudioSource WinSound;
    public AudioSource LoseSound;
    [SerializeField] private TextMeshProUGUI titleTxt;
    [SerializeField] private TextMeshProUGUI messageTxt;
    [SerializeField] private Button menuBtn;
    [SerializeField] private Button quitBtn;

    private void Awake()
    {
        menuBtn.onClick.AddListener(() => SceneManager.LoadScene(0)); //Go to Main menu
        quitBtn.onClick.AddListener(() => Application.Quit());
    }

    private void Start()
    {
        var gameManager = GameManager.Instance;
        //gameManager.IsLoss //Differentiate if game over is lost or won
        titleTxt.text = gameManager.GameOver_TitleTxt;
        messageTxt.text = gameManager.GameOver_MessageTxt;

        if(titleTxt.text == "Victory!")
        {
            AudioManager.PlayAudio("Victory Theme");
        }
        else
        {
            AudioManager.PlayAudio("Losing Theme");
        }
    }


}
