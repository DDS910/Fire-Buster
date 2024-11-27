using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obj_Grabbable : MonoBehaviour
{
    private Rigidbody ObjectRB;
    private Transform objectGrabpointTransform;

    private void Awake()
    {
        ObjectRB = GetComponent<Rigidbody>();
    }

    public void Grab(Transform ObjectGrabPointTransform)
    {
        this.objectGrabpointTransform = ObjectGrabPointTransform;
        ObjectRB.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabpointTransform = null;
        ObjectRB.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (objectGrabpointTransform != null)
        {
            float lerpspeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabpointTransform.position, Time.deltaTime * lerpspeed);
            ObjectRB.MovePosition(newPosition);
        }
    }
}
