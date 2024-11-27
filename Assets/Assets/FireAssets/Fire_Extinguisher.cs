using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Extinguisher : MonoBehaviour
{
    public ParticleSystem water;
    public ParticleSystem fire;

    private void Start()
    {
        water = GetComponent<ParticleSystem>();
        water.Stop();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Fire"))
        {
            fire.Stop();
        }
    }

    private void Update()
    {
        CallWater();
    }


    public void CallWater()
    {
        if(Input.GetMouseButton(0))
        {
            water.Play();
        }
        else
        {
            water.Stop();
        }
    }
}
