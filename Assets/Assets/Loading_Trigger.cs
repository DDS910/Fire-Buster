using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_Trigger : MonoBehaviour
{
    public GameObject loading;
    public Animator crawlText;
    public Vector3 CanvasRotation;
    public Simple_ControllerFPS controller;
    public Camera_Movement playerCam;
    public string nextScene;
    void Start()
    {
        loading.SetActive(false);
        crawlText.SetBool("isTrigger", false);
        loading.transform.eulerAngles = CanvasRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            loading.SetActive(true);
            crawlText.SetBool("isTrigger", true);
            loading.transform.eulerAngles = CanvasRotation;
            PauseGame();
        }
    }

    private void PauseGame()
    {
        controller.enabled = false;
        playerCam.enabled = false;
    }

    public void OnAnimationCompleted()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextScene);
    }

}
