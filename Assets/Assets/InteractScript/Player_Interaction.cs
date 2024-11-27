using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    [SerializeField] 
    private LayerMask pickableLayer;

    [SerializeField] 
    private Transform PlayerCamera;

    [SerializeField]
    [Min(1)] 
    private float hitRange;

    private RaycastHit hit;

    private void Update()
    {
        Debug.DrawRay(PlayerCamera.position, PlayerCamera.forward * hitRange, Color.red);
        if(hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>().enabled = false;
        }
        if (Physics.Raycast(PlayerCamera.position, PlayerCamera.forward, out hit, hitRange, pickableLayer)) 
        {
            hit.collider.GetComponent<Highlight>()?.ToogleHightlight(true);
        }
    }

}
