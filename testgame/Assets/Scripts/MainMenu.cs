using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameManager;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Button PlayButton;
    [SerializeField] private Button QuitButton;

    public enum TempDifficulty
    {
        None, Test, Beginner, Intermediate, Hard, Insane
    }
    public static TempDifficulty tempDifficulty = TempDifficulty.None;


    [Header("Difficulty Buttons")]
    [SerializeField] private Button BeginnerButton;
    [SerializeField] private Button IntermediateButton;
    [SerializeField] private Button HardButton;
    [SerializeField] private Button InsaneButton;
    [SerializeField] private Button StartGameButton;

    [Header("HUDs")]
    [SerializeField] private GameObject _playGameHud;
    [SerializeField] private GameObject _difficultySelectorHud;

    [Header("Difficulty Description")]
    [SerializeField] private Text _difficultyDescription;

    private void Start()
    {
        PlayButton.onClick.AddListener(() => {
            _playGameHud.SetActive(false);
            _difficultySelectorHud.SetActive(true);
           
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        });
        QuitButton.onClick.AddListener(() => Application.Quit());

        BeginnerButton.onClick.AddListener(() =>
        {
            tempDifficulty = TempDifficulty.Beginner;
            _difficultyDescription.text = "This is easy mode";
        });

        IntermediateButton.onClick.AddListener(() =>
        {
            tempDifficulty = TempDifficulty.Intermediate;
            _difficultyDescription.text = "This is normal mode";
        });

        HardButton.onClick.AddListener(() =>
        {
            tempDifficulty = TempDifficulty.Hard;
            _difficultyDescription.text = "This is hard mode";
        });

        InsaneButton.onClick.AddListener(() =>
        {
            tempDifficulty = TempDifficulty.Insane;
            _difficultyDescription.text = "This is extremly hard!";
        });

        StartGameButton.onClick.AddListener(() =>
        {
            if (tempDifficulty == TempDifficulty.None)
            {
                Debug.Log("Pick a difficulty!");
            }
            else
            {
                SceneManager.LoadScene(1);
            }

        });

        
    }
}
