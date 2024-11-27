using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaksi6 : MonoBehaviour
{
    [SerializeField] private float pickuprange;
    [SerializeField] private LayerMask pickupLayer;

    private GameObject currentObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentObject == null)
            {
                PickItem();
            }
        }
        else
        {
            DropItem();
        }
    }

    public void PickItem()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickuprange, pickupLayer))
        {
            currentObject = hit.collider.gameObject;
            currentObject.GetComponent<Rigidbody>().isKinematic = true;
            currentObject.GetComponent<MeshCollider>().enabled = false;
            currentObject.transform.SetParent(transform);
            currentObject.transform.localPosition = Vector3.zero;
            currentObject.transform.localRotation = Quaternion.identity;
        }
    }

    public void DropItem()
    {
        if (currentObject != null)
        {
            currentObject.GetComponent<Rigidbody>().isKinematic = false;
            currentObject.GetComponent<MeshCollider>().enabled = true;
            currentObject.transform.SetParent(null);

            currentObject = null;
        }
    }
}
