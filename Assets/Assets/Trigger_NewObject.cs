using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Trigger_NewObject : MonoBehaviour
{
    [SerializeField] private GameObject trigger;
    [SerializeField] private GameObject Canvas_text;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float duration;


    private void Start()
    {
        text.gameObject.SetActive(false);
        Canvas_text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(showText(duration));
        }
    }

    private IEnumerator showText(float duration)
    {

        Canvas_text.SetActive(true);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        text.gameObject.SetActive(false);
        trigger.SetActive(false);
    }

    
}
