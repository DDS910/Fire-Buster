using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm_Light : MonoBehaviour
{
    // Start is called before the first frame update
    public Light[] lampuAlarm;
    public float interval = 0.5f;
    public float timer;
    public bool isLampon = false;
    void Start()
    {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            foreach (Light lights in lampuAlarm)
            {
                if (isLampon)
                {
                    lights.enabled = false;
                }
                else
                {
                    lights.enabled = true;
                }
            }

            isLampon = !isLampon;
            timer = interval;
        }
    }
}
