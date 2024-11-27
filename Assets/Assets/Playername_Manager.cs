using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Playername_Manager : MonoBehaviour
{
    //public static Playername_Manager instance;
    public TMP_Dropdown dropDown;
    public TMP_InputField inputname;
    public string newMsg;
    public GameObject biodata;
    public GameObject StartStory;
    public Simple_ControllerFPS controller;
    public Camera_Movement playerCam;
    public TextMeshProUGUI storyText;
    public TextMeshProUGUI start_StoryText;
    public static Playername_Manager Instance;

    /*private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/
    private void Start()
    {
        biodata.SetActive(true);
        if (biodata.activeSelf)
        {
            controller.enabled = false;
            playerCam.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        StartStory.SetActive(false);
    }

    public void SetPlayerName()
    {
        GameData.PlayerName = inputname.text;
        UpdateStoryText();
    }

    public void OnOkClickButton()
    {
        biodata.SetActive(false);
        SetPlayerName();
        StartStory.SetActive(true);
    }

    public void HandleDropDown()
    {
        newMsg = start_StoryText.text;
        if (dropDown.value == 2)
        {
            newMsg = start_StoryText.text.Replace("mahasiswa/i", "Mahasiswa");
        }
        if (dropDown.value == 1)
        {
            newMsg = start_StoryText.text.Replace("mahasiswa/i", "Mahasiswi");
        }

        start_StoryText.text = newMsg;
    }

    private void UpdateStoryText()
    {
        storyText.text = storyText.text.Replace("nama pemain", GameData.PlayerName);
        start_StoryText.text = start_StoryText.text.Replace("nama pemain", GameData.PlayerName);
    }

    public void StartGame()
    {
        if (!biodata.activeSelf)
        {
            controller.enabled = true;
            playerCam.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }

}
