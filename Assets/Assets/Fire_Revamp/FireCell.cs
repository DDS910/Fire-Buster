using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCell : MonoBehaviour
{
    public bool isBurning = false;
    public bool isSpreading = false;
    public float burnRadius;
    public float burnDelay;
    public GameObject fireParticle;

    private Renderer cellRen;
    private Transform fireSource;
    private float distancetoFireSource;

    private void Start()
    {
        cellRen = GetComponent<Renderer>();
        cellRen.enabled = false;

        fireSource = GameObject.FindGameObjectWithTag("Fire").transform;
    }

    private void Update()
    {
        distancetoFireSource = Vector3.Distance(transform.position, fireSource.position);

        if (!isBurning && distancetoFireSource <= burnRadius)
        {
            StartBurning();
        }
    }
    public void checkedBurn()
    {
        //if (isBurning || isSpreading) return;

        /*float distanceToFire = Vector3.Distance(fireParticle.transform.position, transform.position);
        if(distanceToFire <= burnRadius )
        {
            StartBurning();
        }*/

        if(isSpreading || isBurning)
        {
            SpreadFire();
        }
    }

    public void StartBurning()
    {

            isSpreading = true;
            isBurning = true;

            cellRen.enabled = true;
            cellRen.material.color = Color.red;

            Instantiate(fireParticle, transform.position, Quaternion.identity);

            Invoke("SpreadFire", burnDelay);
       
    }

    public void SpreadFire()
    {
        GridManager.Instance.SpreadFireToNeighbors(this);
        isSpreading = false;
    }
}