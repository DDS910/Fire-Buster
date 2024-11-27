using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pintu4 : MonoBehaviour
{
    public Transform playercam;
    public float interactionDis;
    public string Door_Open;
    public string Door_Close;
    public string elevator_Up;
    public string elevator_Down;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(playercam.transform.position, playercam.transform.forward * interactionDis, Color.green);


        if (Physics.Raycast(ray, out hit, interactionDis))
        {
            if (hit.collider.gameObject.tag == "Button")
            {
                GameObject doorParent = hit.collider.transform.root.gameObject;
                Animator doorAnim = doorParent.GetComponent<Animator>();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(Door_Close))
                    {
                        doorAnim.ResetTrigger("Tutup");
                        doorAnim.SetTrigger("Buka");
                    }
                }

            }
            if (hit.collider.gameObject.tag == "ElevatorButton")
            {
                GameObject doorParent = hit.collider.transform.root.gameObject;
                Animator doorAnim = doorParent.GetComponent<Animator>();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(doorAnim.GetCurrentAnimatorStateInfo(0).IsName(elevator_Up))
                    {
                        doorAnim.ResetTrigger("Turun");
                        doorAnim.SetTrigger("Naik");
                    }
                }
            }
        }
    }



}
