using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire1 : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] public float CurrentIntensity = 1.0f;

    private float[] StartIntensity = new float[0];
    float timeLastExtinguished = 0;
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = .1f;

    [SerializeField] private ParticleSystem[] FireParticleSystem = new ParticleSystem[0];

    public bool isLit = true;
    private void Start()
    {
        StartIntensity = new float[FireParticleSystem.Length];

        for (int i = 0; i < FireParticleSystem.Length; i++)
        {
            StartIntensity[i] = FireParticleSystem[i].emission.rateOverTime.constant;
        }
    }


    private void Update()
    {
        if (isLit && CurrentIntensity < 1.0f && Time.time - timeLastExtinguished >= regenDelay)
        {
            CurrentIntensity += regenRate * Time.deltaTime;
            changeintensity();
        }
    }

    public bool TryExtinguish(float amount)
    {
        timeLastExtinguished = Time.time;

        CurrentIntensity -= amount;

        changeintensity();

        if (CurrentIntensity <= 0.0f)
        {
            isLit = false;
            return true;

        }

        return false; //the fire is still lit
    }


    private void changeintensity()
    {
        for (int i = 0; i < FireParticleSystem.Length; i++)
        {
            var emission = FireParticleSystem[i].emission;
            emission.rateOverTime = CurrentIntensity * StartIntensity[i];
        }
    }
}
