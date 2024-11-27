using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class AudioListenerManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject DefeatCanvas;
    [SerializeField] private AudioSource AlarmSound;

    private AudioListener playerAudio;
    private AudioListener defeatCanvas;

    private void Start()
    {
        playerAudio = GetComponentInChildren<AudioListener>();
        defeatCanvas = GetComponent<AudioListener>();
        
        defeatCanvas.enabled = false;
    }

    private void Update()
    {
        if (!player.activeSelf && defeatCanvas != null)
        {
            defeatCanvas.enabled = true;
            AlarmSound.Stop();
        }
    }
}
