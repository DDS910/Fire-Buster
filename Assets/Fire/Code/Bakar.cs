using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakar : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem fireParticleSystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) {
            BurnObject();
        }
    }

    private void BurnObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Bakarable bakarable = hit.collider.GetComponent<Bakarable>();

            if (bakarable != null)
            {
                bakarable.StartBurning();
            }
        }
    }


}
