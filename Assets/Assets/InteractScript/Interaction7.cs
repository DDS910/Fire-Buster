using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction7 : MonoBehaviour
{
    public Transform HoldItem;
    public GameObject Item;
    public Camera Camera;
    public float range = 2f;
    public float open = 100f;

    private void Start()
    {
        Item.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Unequip();
        }
    }

    public void Unequip()
    {
        HoldItem.DetachChildren();
        Item.transform.eulerAngles = new Vector3(Item.transform.eulerAngles.x, Item.transform.eulerAngles.y, Item.transform.eulerAngles.z - 45);
        Item.GetComponent <Rigidbody>().isKinematic = false;
    }

    public void Equip()
    {
        Item.GetComponent<Rigidbody>().isKinematic = true;
        Item.transform.position = HoldItem.transform.position;
        Item.transform.rotation = HoldItem.transform.rotation;
        Item.transform.SetParent(HoldItem);
    }
}
