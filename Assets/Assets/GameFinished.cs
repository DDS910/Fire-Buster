using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameFinished : MonoBehaviour
{
    [SerializeField] private GameObject StoryFinished;
    [SerializeField] private Button Continue;
    [SerializeField] private GameObject Trigger;
    [SerializeField] private string NextScene;
    [SerializeField] private float TextDurationShow;
    [SerializeField] private float ButtonDurationShow;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private AudioSource AlarmSound;
    [SerializeField] private GameObject triggerFinishgame;

    //private Playername_Manager textName;

    private void Start()
    {
        StoryFinished.SetActive(false);
        Continue.gameObject.SetActive(false);
        text1.enabled = false;
        text2.enabled = false;
        

        //textName = FindObjectOfType<Playername_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StoryFinished.SetActive(true);
            if (StoryFinished.activeSelf)
            {
                AlarmSound.Stop();
            }
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;

            StartCoroutine(ShowTextAndButton(TextDurationShow,ButtonDurationShow));
        }
    }

    public void OnContinueButton()
    {
        StoryFinished.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        SceneManager.LoadScene(NextScene);

    }

    private IEnumerator ShowTextAndButton(float Textduration, float Buttonduration)
    {
        /*if(textName != null)
        {
            string PlayerName = textName.playerName;
            text1.text = text1.text.Replace("nama mahasiswa", PlayerName);
        }*/
        string playername = GameData.PlayerName;
        text1.text = text1.text.Replace("nama mahasiswa", playername);
        text1.enabled = true;
        yield return new WaitForSecondsRealtime(Textduration);
        text1.enabled = false;

        text2.enabled= true;
        yield return new WaitForSecondsRealtime(Buttonduration);
        Continue.gameObject.SetActive(true);
    }


}
