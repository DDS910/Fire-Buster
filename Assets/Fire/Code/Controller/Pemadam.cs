using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pemadam : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem fire;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ParticleSystem>() == fire)
        {
            fire.Stop();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
