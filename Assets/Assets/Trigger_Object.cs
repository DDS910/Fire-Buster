using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger_Object : MonoBehaviour
{
    [SerializeField] private GameObject triggerObj;
    [SerializeField] private GameObject triggerObj2;
    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float duration;

    private void Start()
    {
        canvas.SetActive(false);
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
        canvas.SetActive(true);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        text.gameObject.SetActive(false);
        canvas.SetActive(false);
        triggerObj.SetActive(false);
        triggerObj2.SetActive(false);

    }
}
