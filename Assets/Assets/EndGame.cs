using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class EndGame : MonoBehaviour
{
    [SerializeField] private string SceneName;
    [SerializeField] private GameObject CanvasEndGame;
    [SerializeField] private GameObject ImageBarcode;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    [SerializeField] private Button buttonEnd;
    [SerializeField] private float Duration;
    [SerializeField] private float Delay;
    [SerializeField] private float DurationText2;
    [SerializeField] private Simple_ControllerFPS playerController;
    [SerializeField] private Camera_Movement playercam;

    //private Playername_Manager playername_manager;

    private void Start()
    {
        CanvasEndGame.SetActive(false);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        ImageBarcode.SetActive(false);
        buttonEnd.gameObject.SetActive(false);

        //playername_manager = FindObjectOfType<Playername_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string playername = GameData.PlayerName;
            text1.text = text1.text.Replace("nama mahasiswa", playername);
            text2.text = text2.text.Replace("nama mahasiswa", playername);
            StartCoroutine(showTextAndButton(Duration, Delay, DurationText2));
            playerController.enabled = false;
            playercam.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            

            /*if(playername_manager != null)
            {
                string playername = playername_manager.playerName;
                text1.text = text1.text.Replace("nama mahasiswa", playername);
            }*/
        }
    }
    private IEnumerator showTextAndButton(float duration, float delay, float duration2)
    {
        CanvasEndGame.SetActive(true);
        text1.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        text1.gameObject.SetActive(false);
        yield return new WaitForSeconds(delay);
        text2.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration2);
        text2.gameObject.SetActive(false);
        yield return new WaitForSeconds(delay);
        text3.gameObject.SetActive(true);
        ImageBarcode.SetActive(true);
        yield return new WaitForSeconds(duration);
        buttonEnd.gameObject.SetActive(true);

    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene(SceneName);
    }
}   
