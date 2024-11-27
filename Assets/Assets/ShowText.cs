using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private GameObject canvas_text;
    [SerializeField] private float Duration;
    [SerializeField] private GameObject afterMissionAppear;
    private bool showtext = false;

    private void Start()
    {
        text.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(!afterMissionAppear.activeSelf && !showtext)
        {
            StartCoroutine(showText(Duration));
        }
    }

    private IEnumerator showText(float duration)
    {
        showtext = true;

        canvas_text.SetActive(true);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        text.gameObject.SetActive(false);
        text2.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        text2.gameObject.SetActive(false);
        canvas_text.SetActive(false);
        

    }
}
