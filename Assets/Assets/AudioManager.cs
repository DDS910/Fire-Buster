using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource ambientsound;
    [SerializeField] private GameObject objective;
    [SerializeField] private AudioSource sound;
    [SerializeField] private float SoundVol;
    void Start()
    {
        ambientsound.volume = SoundVol;
    }

    // Update is called once per frame
    void Update()
    {
        if(sound.isPlaying)
        {
            ambientsound.volume = 0.5f;
        }

        if(objective.activeSelf)
        {
            ambientsound.volume = 0.5f;
        }

        if(!objective.activeSelf)
        {
            ambientsound.volume = SoundVol;
        }
    }
}
