using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Text : MonoBehaviour
{
    public GameObject CanvasWarning;
    public GameObject Wall;

    void Start()
    {
        CanvasWarning.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CanvasWarning.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CanvasWarning.gameObject.SetActive(false);
        }
    }
}
