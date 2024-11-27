using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Instruction_FireExtinguish : MonoBehaviour
{
    [SerializeField] private GameObject Trigger;
    [SerializeField] private GameObject canvas_trigger;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float duration;

    private void Start()
    {
        canvas_trigger.SetActive(false);
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
        canvas_trigger.SetActive(true);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        text.gameObject.SetActive(false);
        Trigger.SetActive(false);
    }
}
