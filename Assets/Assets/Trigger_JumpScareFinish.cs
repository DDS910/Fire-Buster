using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_JumpScareFinish : MonoBehaviour
{
    [SerializeField] private GameObject Canvas_JumpScare;
    [SerializeField] private Simple_ControllerFPS Controller;
    [SerializeField] private Camera_Movement PlayerCam;
    [SerializeField] private AudioSource sound;
    private bool isPlayed = false;
 
    private void Start()
    {
        Canvas_JumpScare.SetActive(false);   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!isPlayed)
            {
                Canvas_JumpScare.SetActive(true);
                sound.Play();
                Controller.enabled = false;
                PlayerCam.enabled = false;
                StartCoroutine(SoundJumpScarea());

                isPlayed = true;
            }
        }
    }

    IEnumerator SoundJumpScarea()
    {
        while (sound.isPlaying)
        {
            yield return null;
        }
        Canvas_JumpScare.SetActive(false);
        Controller.enabled = true;
        PlayerCam.enabled = true;
    }
}
