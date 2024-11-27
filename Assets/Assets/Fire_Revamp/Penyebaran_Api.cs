using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Rendering;

public class Penyebaran_Api : MonoBehaviour
{
    [Header ("Fire")]
    [SerializeField] private GameObject[] firePrefab = new GameObject[0];
    private float[] StartIntensity = new float[0];
    private ParticleSystem[] fireEffect = new ParticleSystem[0];


    [Header ("Extinguisher")]
    [SerializeField, Range(0f, 1f)] public float CurrentIntensity = 1.0f;
    [SerializeField] private float RegenDelay = 2.5f;
    [SerializeField] private float RegenRate = 0.1f;
    float timeLastExtinguished = 0f;

    //[Header ("Random")]
    //public bool isBurning;
    private bool isLit = true;


    private void Start()
    {

        fireEffect = new ParticleSystem[firePrefab.Length];
        StartIntensity = new float[fireEffect.Length];

        for (int i = 0; i < firePrefab.Length; i++)
        {
            fireEffect[i] = firePrefab[i].GetComponent<ParticleSystem>();
        }

        for (int j = 0; j < fireEffect.Length; j++)
        {
            StartIntensity[j] = fireEffect[j].emission.rateOverTime.constant;
        }

        
    }

    private void Update()
    {
        if (isLit && CurrentIntensity < 1.0f && Time.time - timeLastExtinguished >= RegenDelay)
        {
            CurrentIntensity += RegenRate * Time.deltaTime;
            changeIntensity();
        }
    }



    private void changeIntensity()
    {
        for (int i = 0; i < fireEffect.Length; i++) 
        {
            var emission = fireEffect[i].emission;
            emission.rateOverTime = CurrentIntensity * StartIntensity[i];
        }
    }

    public bool TryExtinguish(float amount)
    {
        timeLastExtinguished = Time.time;
        CurrentIntensity -= amount;
        changeIntensity();
        if (CurrentIntensity <= 0.0f)
        {
            isLit = false;
            for (int i = 0; i < firePrefab.Length; i++)
            {
                Destroy(firePrefab[i]);
            }
            return true;
        }
        return false; //the fire is still lit
    }
}
