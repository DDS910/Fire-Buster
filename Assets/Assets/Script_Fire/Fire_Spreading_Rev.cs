using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Spreading_Rev : MonoBehaviour
{
    public float spreadRate;
    public ParticleSystem fireParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Flammable"))
        {
            if(other.GetComponentInChildren<Fire1>() == null)
            {
                Instantiate(fireParticle, other.transform.position, Quaternion.identity);
            }
        }
    }


}
