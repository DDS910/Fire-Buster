using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Fire1;

public class Fire_Spreading : MonoBehaviour
{
    public float spreadRate;
    public LayerMask Flammable;
    public ParticleSystem fireParticle;
    private ParticleSystem newParticle;
    public Fire1 fire;
    private bool destroyed = false;


    private void Start()
    {
        StartCoroutine(SpreadFire());
    }

    IEnumerator SpreadFire()
    {
        yield return new WaitForSeconds(spreadRate);

        if (fireParticle != null)
        {
            Collider[] colliders = Physics.OverlapBox(transform.position, Vector3.one * 2.5f, Quaternion.identity, Flammable);
            foreach (Collider collider in colliders)
            {
                if (!collider.GetComponent<FireSpread>())
                {
                    if (collider.gameObject.CompareTag("Flammable"))
                    {
                        newParticle = Instantiate(fireParticle, collider.transform.position, Quaternion.identity);
                        //StartCoroutine(FireIntensity(newParticle, fireParticle));
                    }
                }
            }
        }

        /*Collider[] nearbyColliders = Physics.OverlapBox(transform.position, Vector3.one * 2.5f, Quaternion.identity, Flammable);


        foreach (Collider collider in nearbyColliders)
        {
            if (!collider.GetComponent<FireSpread>())
            {
                if (collider.gameObject.CompareTag("Flammable"))
                {
                    newParticle = Instantiate(fireParticle, collider.transform.position, Quaternion.identity);
                    //StartCoroutine(FireIntensity(newParticle, fireParticle));
                }
            }
        }*/
    }

    /*IEnumerator FireIntensity(ParticleSystem newfireEffect, ParticleSystem mainFire)
    {
        yield return new WaitForSeconds(spreadRate);

        ParticleSystem.EmissionModule newFireModule = newfireEffect.emission;
        ParticleSystem.EmissionModule mainFireModule = mainFire.emission;

        newFireModule.rateOverTime = 1;

        float mainFireRate = mainFireModule.rateOverTime.constant;
        float increaseSpeed = 0.5f;

        while(newFireModule.rateOverTime.constant < mainFireRate)
        {
            newFireModule.rateOverTime = new ParticleSystem.MinMaxCurve(newFireModule.rateOverTime.constant + increaseSpeed);
            yield return null;
        }
    }*/
    
    /*private void Update()
    {
        if (newParticle != null)
        {
            Fire1 newFire = newParticle.gameObject.GetComponent<Fire1>();
            if (newFire.CurrentIntensity <= 0f)
            {
                DestroyImmediate(newParticle.gameObject);
                destroyed = true;
            }
        }

        if(fireParticle != null && destroyed)
        {
            StartCoroutine(SpreadFire());
            destroyed = false;
        }
    }*/

    private void AfterSpread(ParticleSystem fireEffect)
    {
        float minSize = 0.5f;
        float maxSize = 0.75f;
        float randomSize = Random.Range(minSize, maxSize);

        var sizeOverLifetime = fireEffect.sizeOverLifetime;
        sizeOverLifetime.size = new ParticleSystem.MinMaxCurve(randomSize);

        if(transform.eulerAngles.x == -90f)
        {
            fireEffect.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
        }
    }

}
