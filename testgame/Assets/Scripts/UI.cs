using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject EscapePanel;
    public Slider SensitivityValue;

    [SerializeField] private Text ShowSensitivity;
    [SerializeField] private Shooting StopShooting;
    [SerializeField] private CameraRotation cameraRotation;
    private float sliderValue;
    private bool PanelIsOpen = false;
    
    void Update()
    {
        sliderValue = Mathf.Round(SensitivityValue.value * 100f) / 100f;
        ShowSensitivity.text = sliderValue.ToString();

        cameraRotation.sensitivity = sliderValue;
        if(Input.GetKeyDown(KeyCode.Escape) && PanelIsOpen == true) //Resume
        {
            Cursor.lockState = CursorLockMode.Locked;
            PanelIsOpen = false;
            Cursor.visible = false;
            StopShooting.enabled = true;
            cameraRotation.enabled = true;
            EscapePanel.SetActive(false);
            SettingPanel.SetActive(false);
            Time.timeScale = 1f;
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && PanelIsOpen == false) //Pause
        {
            Cursor.lockState = CursorLockMode.None;
            PanelIsOpen = true;
            EscapePanel.SetActive(true);
            StopShooting.enabled = false;
            cameraRotation.enabled = false;
            Time.timeScale = 0f;
        }
    }

    public void OpenSettingPanel()
    {
        EscapePanel.SetActive(false);
        SettingPanel.SetActive(true);
    }


}
