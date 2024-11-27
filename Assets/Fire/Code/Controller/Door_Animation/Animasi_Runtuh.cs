using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animasi_Runtuh : MonoBehaviour
{
    public Animator animationClip;
    public string triggerParameter = "PlayerTrigger";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (animationClip != null)
            {
                animationClip.SetTrigger(triggerParameter);
            }
        }
    }
}
