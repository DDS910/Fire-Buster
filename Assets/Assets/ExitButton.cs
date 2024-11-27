using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] GameObject canvas_exit;
    private void Start()
    {
        canvas_exit.SetActive(false);
    }

    public void OnExitButton()
    {
        canvas_exit.SetActive(true);
    }

    public void OnExitCancel()
    {
        canvas_exit?.SetActive(false);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }

}
