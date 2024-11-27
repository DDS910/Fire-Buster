using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakarable : MonoBehaviour
{
    private bool isBurning = false;
    public ParticleSystem fireParticleSystem;

    private void Start()
    {
        // Pastikan Particle System dimatikan saat mulai.
        StopFire();
    }

    public void StartBurning()
    {
        isBurning = true;

        // Nyalakan Particle System atau mulai animasi terbakar.
        PlayFire();

        Debug.Log("Objek sedang terbakar!");
    }

    public void StopBurning()
    {
        isBurning = false;

        // Matikan Particle System atau hentikan animasi terbakar.
        StopFire();

        Debug.Log("Object tidak lagi terbakar");
    }

    private void PlayFire()
    {
        if (fireParticleSystem != null && !fireParticleSystem.isPlaying)
        {
            fireParticleSystem.Play();
        }
    }

    private void StopFire()
    {
        if (fireParticleSystem != null && fireParticleSystem.isPlaying)
        {
            fireParticleSystem.Stop();
        }
    }
}
