using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrant : MonoBehaviour
{
    private ParticleSystem air;
    private bool mousetahan = false;
    public Collider FireExtinguisher;
    void Start()
    {
        air = transform.GetChild(0).GetComponent<ParticleSystem>();
        air.Stop();
        FireExtinguisher = transform.GetChild(1).GetComponent<Collider>();
        FireExtinguisher.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousetahan = true;
            FireExtinguisher.enabled = true;
        }       
        else if (Input.GetMouseButtonUp(0))
        {
            mousetahan = false; 
            FireExtinguisher.enabled = false;
        }

        if (!mousetahan && air.isPlaying)
        {
            air.Stop();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mousetahan && !air.isPlaying)
            {
                air.Play();
            }
        }
    }


}
