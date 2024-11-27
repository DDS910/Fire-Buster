using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Light_Alarm : MonoBehaviour
{
    public Light directionalLight;
    public float toggleInterval = 2f; // Adjust this value to set the interval between light toggles
    private bool isLightOn = false;

    void Start()
    {
        StartCoroutine(ToggleLightCoroutine());
    }

    IEnumerator ToggleLightCoroutine()
    {
        while (true)
        {
            ToggleLight();
            yield return new WaitForSeconds(toggleInterval);
        }
    }

    private void ToggleLight()
    {
        if (isLightOn)
        {
            directionalLight.intensity = 2f;
        }
        else
        {
            directionalLight.intensity = 8f;
        }
        isLightOn = !isLightOn;
    }
}
