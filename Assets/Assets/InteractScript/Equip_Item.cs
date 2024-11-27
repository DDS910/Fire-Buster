using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_Item : MonoBehaviour
{
    public Transform equipItem;
    public float distance = 4f;
    GameObject currenItem;
    GameObject item;

    bool canGrab;

    private void Update()
    {
        CheckItem();

        if(canGrab)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(currenItem != null)
                {
                    DropItem();
                }

                pickUpItem();
            }
        }

        if(currenItem != null)
        {
            DropItem();
        }
    }

    private void CheckItem() 
    {
        RaycastHit hit;

        if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            canGrab = false;
        }
        else
        {
            if (hit.transform.tag == "CanInteract")
            {
                Debug.Log("Bisa diambil");
                canGrab = true;
                item = hit.transform.gameObject;
            }
        }
    }

    private void pickUpItem()
    {
        currenItem = item;
        currenItem.transform.position = equipItem.position;
        currenItem.transform.rotation = equipItem.rotation;
        currenItem.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        currenItem.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void DropItem()
    {
        currenItem.transform.parent = null;
        currenItem.GetComponent<Rigidbody>().isKinematic = false;
        currenItem = null;
    }
}
