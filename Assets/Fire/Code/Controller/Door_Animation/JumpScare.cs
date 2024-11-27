using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject JumpscareIMG;
    public AudioSource JumpscareAudio;
    public Health_Bar darah;

    private bool isPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        JumpscareIMG.SetActive(false);
        JumpscareAudio.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isPlayed)
            {
                JumpscareIMG.SetActive(true);
                JumpscareAudio.Play();
                StartCoroutine(DisableJumpscare());

                isPlayed = true;
            }

            darah.isBurning = false;
        }
    }

    IEnumerator DisableJumpscare()
    {
        while (JumpscareAudio.isPlaying)
        {
            yield return null;
        }
        JumpscareIMG?.SetActive(false);
    }


}
