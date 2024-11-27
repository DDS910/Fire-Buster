using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaksi2 : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, HoldItem, Cam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        if(!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;

        }
        else if(equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }
    private void Update()
    {
        Vector3 distancetoPlayer = player.position - transform.position;
        if (!equipped && distancetoPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            pickup();
        }

        if(equipped && Input.GetKeyDown(KeyCode.G))
        {
            drop();
        }
    }
    private void pickup()
    {
        equipped = true;
        slotFull = true;

        transform.SetParent(HoldItem);
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;

    }

    private void drop() 
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(Cam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(Cam.up * dropUpwardForce, ForceMode.Impulse);

        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);


    }
}
