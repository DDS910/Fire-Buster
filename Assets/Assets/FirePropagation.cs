using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePropagation : MonoBehaviour
{
    public GameObject wall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire")) 
        { 
            Vector3 collision = other.ClosestPoint(transform.position);
            GameObject wallFireParticles = Instantiate(wall, collision, Quaternion.identity);
        }
    }
}
