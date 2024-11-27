using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact_4 : MonoBehaviour
{
    public GameObject Barang;
    public Transform BarangParent;
    void Start()
    {
        Barang.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
       Debug.DrawRay(BarangParent.position, BarangParent.forward, Color.yellow);
        if (Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }
    }

    void Drop()
    {
        BarangParent.DetachChildren();
        Barang.transform.eulerAngles = new Vector3(Barang.transform.position.x, Barang.transform.position.y, Barang.transform.position.z);
        Barang.GetComponent<Rigidbody>().isKinematic = false;
        Barang.GetComponent<MeshCollider>().enabled = true;
        
    }

    void Pickup()
    {
        Barang.GetComponent <Rigidbody>().isKinematic = true;

        Barang.transform.position = BarangParent.transform.position;
        Barang.transform .rotation = BarangParent .transform.rotation;

        Barang.GetComponent<MeshCollider>().enabled= false;

        Barang.transform.SetParent(BarangParent);


    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                Pickup();
            }
        }

        
    }
}
