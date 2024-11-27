using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kebakaran : MonoBehaviour
{
    public ParticleSystem fireParticlesApi;
    public ParticleSystem fireParticlesCube;

    void StartBurning()
    {
        fireParticlesApi.Play();
        fireParticlesCube.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flammable"))
        {
            StartBurning();
        }
    }
}
