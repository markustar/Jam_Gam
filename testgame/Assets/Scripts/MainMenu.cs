using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button QuitButton;

    private void Start()
    {
        PlayButton.onClick.AddListener(() => {
            SceneManager.LoadScene(1);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        });
        QuitButton.onClick.AddListener(() => Application.Quit());
    }
}
