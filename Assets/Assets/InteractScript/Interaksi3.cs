using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaksi3 : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform ObjectGrabPointTransform;
    [SerializeField] private LayerMask pickupLayermask;

    private Obj_Grabbable objectGrabbable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null)
            {
                //ga bawa barang
                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycasthit, pickUpDistance))
                {
                    if (raycasthit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(ObjectGrabPointTransform);
                    }
                }
            }
            else
            {
                //bawa barang
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
