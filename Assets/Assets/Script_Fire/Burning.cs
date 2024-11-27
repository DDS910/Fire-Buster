using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Burning : MonoBehaviour
{
    public float health;
    private float maxHealth;
    public float damageOverTime;
    public GameObject player;
    public bool isBurning;

    public Slider healthSlider;

    private void Start()
    {
        maxHealth = health;
        isBurning = false;
    }

    private void Update()
    {
        if (isBurning)
        {
            health -= damageOverTime * Time.deltaTime;
            healthSlider.value = health;
        }
        else if (health <= 0 ) 
        { 
            Destroy( player );
        }

        if (health <= -1)
        {
            health = 0;
        }
    }

    void takeDamage(float damage)
    {
        health -= damage;
        healthSlider.value = health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            isBurning = true;
            takeDamage(damageOverTime * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            isBurning = false;
        }
    }
}
