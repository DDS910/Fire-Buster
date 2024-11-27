using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering_Light : MonoBehaviour
{
    public Light[] lampu;
    public float minTime;
    public float maxTime;
    public float Timer;
    void Start()
    {
        Timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        flickerLight();
    }

    void flickerLight()
    {
        if  (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        if (Timer <= 0 ) 
        {
           foreach ( Light light in lampu )
            {
                light.enabled = !light.enabled;
            }
           Timer = Random.Range(minTime, maxTime);
        }
    }
}
