using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaksi4 : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private float PickupRange = 3f;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private float throwingForce;
    [SerializeField] private Transform HoldItem;
    [SerializeField] private Material highlightMaterial;

    private Rigidbody CurrentObjectRB;
    private Collider CurrentObjectCollider;

    public bool isHolding;

    private void Start()
    {
        isHolding = false;
    }
    private void Update()
    {   
        Debug.DrawRay(PlayerCamera.transform.position, PlayerCamera.transform.forward * PickupRange, Color.red);
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            Ray pickupRay = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);

            if (Physics.Raycast(pickupRay, out RaycastHit hitInfo, PickupRange, pickupLayer))
            {
                if (CurrentObjectRB)
                {
                    CurrentObjectRB.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    CurrentObjectRB = hitInfo.rigidbody;
                    CurrentObjectCollider = hitInfo.collider;

                    CurrentObjectRB.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                }
                else 
                {
                    CurrentObjectRB = hitInfo.rigidbody;
                    CurrentObjectCollider = hitInfo.collider;

                    CurrentObjectRB.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                }

                Debug.Log("Is true");
                isHolding = true;
                return;
            }

            if (CurrentObjectRB)
            {
                CurrentObjectRB.isKinematic = false;
                CurrentObjectCollider.enabled = true;

                CurrentObjectRB = null;
                CurrentObjectCollider = null;

                
                isHolding = false;
                Debug.Log("Is false");

            }
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            if (CurrentObjectRB) 
            {
                CurrentObjectRB.isKinematic = false;
                CurrentObjectCollider.enabled = true;

                CurrentObjectRB.AddForce(PlayerCamera.transform.forward * throwingForce, ForceMode.Impulse);

                CurrentObjectRB = null;
                CurrentObjectCollider = null;
                isHolding = false;
                Debug.Log("Is false");
            }
        }

        if (CurrentObjectRB)
        {
            CurrentObjectRB.position = HoldItem.position;
            CurrentObjectRB.rotation = HoldItem.rotation;
        }
    }
}
