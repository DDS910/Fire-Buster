using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakaran : MonoBehaviour
{
    // Start is called before the first frame update
    private Color originalcolor;
    private ParticleSystem cubeterbakar;
    private bool kebakar = false;
    
    void Start()
    {
        originalcolor = GetComponent<Renderer>().material.color;
        cubeterbakar = GetComponent<ParticleSystem>();
        cubeterbakar.Stop();
    }

    // Update is called once per frame
  

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bersentuh");
        if (other.CompareTag("Flammable"))
        {
            Debug.Log("Api terdeteksi");
            startBurning();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Flammable"))
        {
            StopBurning();
        }
    }

    private void startBurning()
    {
        Debug.Log("Fungsi terpanggil");
        GetComponent<Renderer>().material.color = Color.red;
        if(!cubeterbakar.isPlaying) {
            cubeterbakar.Play();
            kebakar = true;
            StartCoroutine(Bakarobject());
            Invoke("StopBurning", 5f);
        }

    }

    private void StopBurning()
    {
        Invoke("pascakebakaran", 2f);
    }

    private void pascakebakaran()
    {
        GetComponent<Renderer>().material.color = originalcolor;
        cubeterbakar.Stop();
        kebakar = false;
    }

    IEnumerator Bakarobject()
    {
        yield return new WaitForSeconds(2f);

        if (kebakar)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Flammable") && collider.gameObject != gameObject)
                {
                    Bakaran bakar = collider.GetComponent<Bakaran>();
                    if (bakar != null)
                    {
                        bakar.startBurning();
                    }
                }
            }
        }
    }

}
