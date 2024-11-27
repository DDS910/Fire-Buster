using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Canvas_Story : MonoBehaviour
{
    public GameObject startStory; //
    public Playername_Manager playername; //
    public Button buttonStart;
    public float Duration;
    [SerializeField] private Playername_Manager storyMsg;


    private void Start()
    {
        buttonStart.gameObject.SetActive(false);
        StartCoroutine(ShowButton(Duration));
    }

    public void onStartButtonClick() 
    {
        playername.StartGame();
        startStory.SetActive(false);
    }

    private IEnumerator ShowButton(float duration)
    {

        yield return new WaitForSecondsRealtime(duration);
        buttonStart.gameObject.SetActive(true);
    }

}
