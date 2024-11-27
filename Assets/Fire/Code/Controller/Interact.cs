using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer objectRenderer;
    private Color warna;
    public float JarakInteraksi = 1.5f;
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        warna = objectRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && JarakPlayer())
        {
            objectRenderer.material.color = Color.red;
        }
        else
        {
            objectRenderer.material.color = warna;
        }
    }

    bool JarakPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            float jarak = Vector3.Distance(transform.position, player.transform.position);

            return jarak <= JarakInteraksi;
        }

        return false;
    }
}
