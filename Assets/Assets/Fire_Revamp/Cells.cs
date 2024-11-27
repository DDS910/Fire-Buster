using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Cells : MonoBehaviour
{
    public bool isBurning = false;
    public float SpreadRateChance = 0.2f;
    public Penyebaran_Api Script_Api;
    public bool isSpreading = false;

    public ParticleSystem firePrefab; // Prefab for the fire effect
    private ParticleSystem fireEffectInstance; // Instance of the fire effect


    private void Start()
    {

    }

    /*public void Ignite()
    {
        if (Script_Api.isBurning && !isSpreading)
        {
            fireEffectInstance = Instantiate(firePrefab, transform.position, Quaternion.identity);
            fireEffectInstance.transform.parent = transform;
            isSpreading = true;
        }

    }*/
}
