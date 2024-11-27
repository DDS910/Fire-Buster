using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaksi : MonoBehaviour
{
    // Start is called before the first frame update
    private bool Interak = false;
    private bool Angkat = false;
    public Transform playerTransform;
    void Start()
    {
        playerTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Interak && Input.GetKeyDown(KeyCode.E))
        {
            if (Angkat)
            {
                Jatoh();
            }
            else
            {
                Mengangkat();
            }
        }

        if (Angkat)
        {
            transform.position = playerTransform.position + playerTransform.forward * 2f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable") && other.CompareTag("Player"))
        {
            Interak = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable") && other.CompareTag("Player"))
        {
            Interak = false;
        }
    }

    void Mengangkat()
    {
        Angkat = true;
    }

    void Jatoh()
    {
        Angkat = false;
    }
}
