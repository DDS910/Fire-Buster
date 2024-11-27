using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact_2 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool angkat = false;
    private GameObject AngkatObject;
    public float JarakInteraksi = 3.5f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && JarakPlayer())
        {
            AngkatObject = cariObject();

            if(AngkatObject != null)
            {
                angkat = true;

                AngkatObject.GetComponent<Collider>().enabled = false;
            }

            if (angkat)
            {
                UpdatePosisi();
            }
        }
    }

    void UpdatePosisi()
    {
        AngkatObject.transform.position = transform.position + transform.forward * JarakInteraksi;
    }

    bool JarakPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float jarak = Vector3.Distance(transform.position, player.transform.position);

            return jarak <= JarakInteraksi;
        }

        return false;
    }

    GameObject cariObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, JarakInteraksi))
        {
            return hit.collider.gameObject;
        }
        return null;
    }
}
