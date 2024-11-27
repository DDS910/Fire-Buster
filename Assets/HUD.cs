using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class HUD : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealth;
 
    public float maxHealth = 100f;
    public float health;
   
    private float lerpspeed = 0.005f;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthSlider.value != health) 
        { 
            healthSlider.value = health;
        }

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            takeDamage(10);
        }

        if(healthSlider.value != easeHealth.value)
        {
            easeHealth.value = Mathf.Lerp(easeHealth.value, health, lerpspeed);
        }

    }

    void takeDamage(float damage)
    {
        health -= damage;
    }
}
