using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mission_Trigger : MonoBehaviour
{
    public GameObject StoryCanvas;
    [SerializeField] public GameObject Trigger;
    [SerializeField] private Button Continue;
    [SerializeField] private float DurationForVisible;
    [SerializeField] private Pintu3 Interaksi;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float DelayDestroy;
    [SerializeField] private GameObject showInstruction;
    [SerializeField] private GameObject showFireExtinguish;

    //private Playername_Manager playername_manager;

    private void Start()
    {
        StoryCanvas.SetActive(false);
        Continue.gameObject.SetActive(false);
        Interaksi.enabled = false;
        showInstruction.SetActive(false);
        showFireExtinguish.SetActive(false);

        //playername_manager = FindObjectOfType<Playername_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string playername = GameData.PlayerName;
            text.text = text.text.Replace("nama mahasiswa", playername);
            StoryCanvas.SetActive(true);
            /*if(playername_manager != null)
            {
                string playerName = playername_manager.playerName;
                text.text = text.text.Replace("nama mahasiswa", playerName);
            }*/
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;

            StartCoroutine(ButtonVisible(DurationForVisible));
        }
    }

    public void ContinueButton()
    {
        StoryCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;

        Trigger.SetActive(false);
        showInstruction.SetActive(true);
        showFireExtinguish.SetActive(true);

    }

    private IEnumerator ButtonVisible(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        Continue.gameObject.SetActive(true);
        
    }
}
