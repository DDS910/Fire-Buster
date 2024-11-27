using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interaksi1 : MonoBehaviour
{
    [Header("Pickup Setting")]
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRB;

    [Header("Physics Parameter")]
    [SerializeField] private float pickuprange = 5.0f;
    [SerializeField] private float pickUpForce = 150.0f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(heldObj == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickuprange))
                {
                    pickUpobject(hit.transform.gameObject);
                }
            }
            else
            {
                dropObject();
            }
        }
        if(heldObj != null)
        {
            //moveObject
        }
    }

    void pickUpobject(GameObject pickObj)
    {
        if(pickObj.GetComponent<Rigidbody>()) 
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    private void dropObject()
    {

        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObj.transform.parent = null;
        heldObjRB = null;
            
       
    }

    private void moveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 movedDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(movedDirection * pickUpForce);
        }
    }
}
