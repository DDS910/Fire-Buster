using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FireSpread : MonoBehaviour
{
    // Start is called before the first frame update
    public float spreadRate = 0.1f;
    void Start()
    {
        Debug.Log("FireSpread script started");
    }

    // Update is called once per frame
    void Update()
    {
        SpreadFire();
    }
    void SpreadFire()
    {
        Debug.Log("Spreading fire...");
        //        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f); // Adjust the radius as needed

        //        foreach (Collider collider in colliders)
        //        {
        //           if (collider.CompareTag("Flammable"))
        //            {
        //                // Ignite the flammable object
        //                FireSpread fireSpread = collider.GetComponent<FireSpread>();
        //                if (fireSpread != null)
        //                {
        //                    fireSpread.Ignite();
        //               }
        //          }
        //        }
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f);

        foreach (Collider collider in colliders)
        {
            Debug.Log("Collider detected: " + collider.gameObject.name);

            if (collider.CompareTag("Flammable"))
            {
                Debug.Log("Flammable object detected: " + collider.gameObject.name);

                // Ignite the flammable object
                Ignite(collider.gameObject);
            }
        }

        Debug.Log("End of SpreadFire method");
    }

    void Ignite(GameObject target)
    {
        Debug.Log("Object ignited on " + target.name);

        ParticleSystem particleSystem = target.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
            Debug.Log("Particle System played on " + target.name);
        }
    }
}
