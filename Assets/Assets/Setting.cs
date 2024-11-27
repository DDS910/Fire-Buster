using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;


public class Setting : MonoBehaviour
{
    public TMP_Dropdown graphic_Setting;
    public Slider masterVol, musicVol;
    public AudioMixer mainAudioMixer;
    public GameObject SettingGame;
    public float defMasterVolume;
    public float defMusicVolume;

    //Player Preference Keys
    //private string graphicsQuality = "GraphicQuality";
    //private string MasterVolumeKey = "MasterVolume";
    //private string MusicVolumeKey = "MusicVolume";

    private void Start()
    {
        //LoadSettings();
    }

    public void ShowSetting()
    {
        SettingGame.SetActive(true);
    }

    public void ChangeGraphicQuality()
    {
        QualitySettings.SetQualityLevel(graphic_Setting.value);
        //saveSetting();
    }

    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("MasterVol", masterVol.value);
        //saveSetting();
    }

    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("MusicVol", musicVol.value);
        //saveSetting();
    }

    /*private void LoadSettings()
    {
        if(PlayerPrefs.HasKey(graphicsQuality))
        {
            int graphicQuality = PlayerPrefs.GetInt(graphicsQuality);
            graphic_Setting.value = graphicQuality;
            QualitySettings.SetQualityLevel(graphicQuality);
        }

        if (PlayerPrefs.HasKey(MasterVolumeKey))
        {
            float masterVolume = PlayerPrefs.GetFloat(MasterVolumeKey);
            masterVol.value = masterVolume;
            mainAudioMixer.SetFloat ("MasterVol", masterVolume);
        }
        else
        {
            mainAudioMixer.SetFloat("MasterVol", defMasterVolume);
            masterVol.value = defMasterVolume;
        }

        if (PlayerPrefs.HasKey(MusicVolumeKey))
        {
            float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey);
            musicVol.value = musicVolume;
            mainAudioMixer.SetFloat("MusicVol", musicVolume);
        }
        else
        {
            mainAudioMixer.SetFloat("MusicVol", defMusicVolume);
            musicVol.value = defMusicVolume;
        }
    }*/

    public void saveSetting()
    {
        //PlayerPrefs.SetInt(graphicsQuality, graphic_Setting.value);
        //PlayerPrefs.SetFloat(MasterVolumeKey, masterVol.value);
        //PlayerPrefs.SetFloat(MusicVolumeKey, musicVol.value);

        //PlayerPrefs.Save();
        SettingGame.SetActive(false);
    }

    
    public void CancelSetting()
    {
        //LoadSettings();
        SettingGame.SetActive(false);
    }

    
}
