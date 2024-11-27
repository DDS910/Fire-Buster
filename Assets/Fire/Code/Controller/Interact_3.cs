using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cubeOnPlayer;
    void Start()
    {
        cubeOnPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);

                cubeOnPlayer.SetActive(true);
            }
        }
    }
}
