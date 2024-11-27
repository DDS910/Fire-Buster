using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingInGame : MonoBehaviour
{
    public Slider sfxVol, musicVol;
    public GameObject canvas_Setting;
    public AudioMixer mainAudio;
    private bool isPaused = false;
    public Simple_ControllerFPS controller;
    public Camera_Movement playerCam;

    private void Start()
    {
        canvas_Setting.SetActive(false);
    }
    public void MusicVolume()
    {
        mainAudio.SetFloat("MusicGameVol", musicVol.value);
    }

    public void SFXVolume()
    {
        mainAudio.SetFloat("SFX_ingame", sfxVol.value);
    }

    public void cancelSetting()
    {
        isPaused = false;
        canvas_Setting.SetActive(false);
        ResumeGame();
        
    }

    public void saveSetting()
    {
        isPaused = false;
        canvas_Setting.SetActive(false);
        ResumeGame();
       
    }

    public void exitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void showSetting()
    {
        isPaused = true;
        canvas_Setting.SetActive(true);
        PauseGame();
        
    }

    public void PauseGame()
    {
        controller.enabled = false;
        playerCam.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        controller.enabled = true;
        playerCam.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}
