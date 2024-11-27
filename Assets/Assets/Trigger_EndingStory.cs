using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger_EndingStory : MonoBehaviour
{
    [SerializeField] private GameObject Canvas_EndingStory;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    [SerializeField] private float Duration; //Durasi untuk menunjukan canvas dan text
    [SerializeField] private float Delay; //Delay untuk menampilkan canvas dan text
    [SerializeField] private Simple_ControllerFPS Controller;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] SFX1;
    [SerializeField] private AudioClip[] SFX2;

    //private Playername_Manager playername_manager;

    private void Start()
    {
        Canvas_EndingStory.SetActive(false);
        Controller.enabled = false;
        text.enabled = false;
        text2.enabled = false;

        StartCoroutine(ShowAndHideCanvas(Duration, Delay));
    }

    private IEnumerator ShowAndHideCanvas(float duration, float delay)
    {
        //untuk menampilkan suara dan text1
        yield return new WaitForSeconds(delay);
        int randomRange = Random.Range(0, SFX1.Length);
        AudioClip randomSFX1 = SFX1[randomRange];
        audioSource.PlayOneShot(randomSFX1);
        text.enabled = true;
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        text.enabled = false;

        //untuk menampilkan canvas cerita game
        string playername = GameData.PlayerName;
        text3.text = text3.text.Replace("nama mahasiwa", playername);
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0f;
        Canvas_EndingStory.SetActive(true);
        yield return new WaitForSecondsRealtime(duration);
        Canvas_EndingStory.SetActive(false);
        Controller.enabled = true;
        Time.timeScale = 1f;

        //untuk memainkan suara berdasarkan suara yang diambil dari sfx1 dan memampilkan text2
        yield return new WaitForSeconds(delay);
        if(!Canvas_EndingStory.activeSelf && !text.enabled)
        {
            AudioClip randomSFX2 = SFX2[randomRange];
            audioSource.PlayOneShot(randomSFX2);
        }
        text2.enabled = true;
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        text2.enabled = false;

    }
}
