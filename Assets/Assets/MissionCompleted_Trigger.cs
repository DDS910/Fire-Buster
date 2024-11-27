using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionCompleted_Trigger : MonoBehaviour
{
    [SerializeField] GameObject MissionCompletedCanvas;
    [SerializeField] GameObject Trigger;
    [SerializeField] private Button ButtonContinue;
    [SerializeField] private float Duration_for_visible;
    [SerializeField] private Pintu3 Interaksi;
    [SerializeField] private AudioSource TolongSFX;
    [SerializeField] private ParticleSystem[] Fire;
    [SerializeField] private GameObject APAR;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject FinishTriggerGame;
    [SerializeField] private GameObject trigger; //untuk nampilin trigger text.

    //private Playername_Manager playername;

    private void Start()
    {
        MissionCompletedCanvas.SetActive(false);
        ButtonContinue.gameObject.SetActive(false);
        foreach(ParticleSystem fires in Fire)
        {
            fires.gameObject.SetActive(false);
        }
        FinishTriggerGame.SetActive(false);
        trigger.SetActive(false);

        //playername = FindObjectOfType<Playername_Manager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string playername = GameData.PlayerName;
            text.text = text.text.Replace("nama mahasiswa", playername);
            MissionCompletedCanvas.SetActive(true);
            if (MissionCompletedCanvas.activeSelf)
            {
                TolongSFX.Stop();
            }
            /*if (playername != null)
            {
                string PlayerName = playername.playerName;
                text.text = text.text.Replace("nama mahasiswa", PlayerName);
            }*/
            foreach (ParticleSystem fires in Fire)
            {
                fires.gameObject.SetActive(true);
            }
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;

            StartCoroutine(ButtonVisible(Duration_for_visible));

            Interaksi.enabled = true;
            Destroy(APAR);
        }
    }

    public void OnContinueButton()
    {
        MissionCompletedCanvas.SetActive(false);
        Trigger.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;

        FinishTriggerGame.SetActive(true);
        trigger.SetActive(true);
    }

    private IEnumerator ButtonVisible(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        ButtonContinue.gameObject.SetActive(true);
    }


}
