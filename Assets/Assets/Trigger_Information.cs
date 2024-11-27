using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Information : MonoBehaviour
{
    public GameObject Trigger_CanvasInformation;
    public GameObject informationCanvas;
    public Simple_ControllerFPS playerController;
    public Camera_Movement playerCam;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            informationCanvas.SetActive(true);
            playerCam.enabled = false;
            playerController.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void OnXbuttonClicked()
    {
        informationCanvas.SetActive(false);
        playerCam.enabled = true;
        playerController.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Trigger_CanvasInformation.SetActive(false);
    }
}
