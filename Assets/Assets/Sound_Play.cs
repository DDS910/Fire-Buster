using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Play : MonoBehaviour
{
    [SerializeField] private AudioSource TolongSFX;
    [SerializeField] private AudioClip SFX;
    [SerializeField] private GameObject trigger; 
    [SerializeField] private float intervalSound; //Interval suara
    

    private bool isPlayed = false;

    private void Start()
    {
        TolongSFX.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(!trigger.activeSelf && !isPlayed)
        {
            StartCoroutine(playSound(intervalSound));
        }
    }

    private IEnumerator playSound(float interval)
    {
        isPlayed = true;
        TolongSFX.gameObject.SetActive(true);
        TolongSFX.PlayOneShot(SFX);
        yield return new WaitForSecondsRealtime(interval);
        isPlayed = false;

    }
}
