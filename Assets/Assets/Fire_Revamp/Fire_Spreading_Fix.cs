using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Spreading_Fix : MonoBehaviour
{
    public GameObject fireSource;
    private ParticleSystem fireParticle;
    [SerializeField] private float FireRadius;

    private void Start()
    {

    }

    private void StartBurning(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, FireRadius);
        foreach (Collider collider in colliders)
        {
            Fire2 cell = collider.GetComponent<Fire2>();
            
        }
    }

    public void StopFire()
    {
       
    }
}
