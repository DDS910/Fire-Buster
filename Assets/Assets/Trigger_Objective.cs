using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger_Objective : MonoBehaviour
{
    [SerializeField] private GameObject trigger;
    [SerializeField] private GameObject Canvas;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float duration;

    private void Start()
    {
        Canvas.SetActive(false);
        text.gameObject.SetActive(false);
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
        Canvas.SetActive(true);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        Canvas.SetActive(false);
        text.gameObject.SetActive(false);

        trigger.SetActive(false);

    }
}
