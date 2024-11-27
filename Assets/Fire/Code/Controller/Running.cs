using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour
{
    public float runspeed = 6.5f;
    private bool isMoving = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            isMoving = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isMoving = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) && isMoving == true)
        {
            transform.position += transform.forward * Time.deltaTime * runspeed;
        }
    }
}
