using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Interaksi5 : MonoBehaviour
{
    public GameObject Item;
    public Transform ParentItem;

    void Start()
    {
        Item.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            DropItem();
        }
    }

    void DropItem()
    {
        ParentItem.DetachChildren();
        Item.transform.eulerAngles = new Vector3(Item.transform.position.x, Item.transform.position.z, Item.transform.position.y);
        Item.GetComponent<Rigidbody>().isKinematic = false;
        Item.GetComponent<MeshCollider>().enabled = true;
    }

    void PickItem()
    {
        Item.GetComponent <Rigidbody>().isKinematic = true;

        Item.transform.position = ParentItem.transform.position;
        Item.transform.rotation = ParentItem.transform.rotation;

        Item.GetComponent<MeshCollider>().enabled = false;

        Item.transform.SetParent(ParentItem);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                PickItem();
            }
        }
    }
}
