using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pintu : MonoBehaviour
{
    public Transform playercam;
    public float interactionDis;
    public string doorOpen, doorClose;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(playercam.transform.position, playercam.transform.forward * interactionDis, Color.blue);

        if (Physics.Raycast(ray, out hit, interactionDis))
        {
            if (hit.collider.gameObject.tag == "Door")
            {
                GameObject doorParent = hit.collider.transform.root.gameObject;
                Animator doorAnim = doorParent.GetComponent<Animator>();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpen))
                    {
                        doorAnim.ResetTrigger("Buka");
                        doorAnim.SetTrigger("Tutup");
                    }
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorClose))
                    {
                        doorAnim.ResetTrigger("Tutup");
                        doorAnim.SetTrigger("Buka");
                    }
                }

            }
        }
    }
}
