using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;

    [Header("Darah")]
    public float health;
    private float maxHealth;
    public Slider healthSlider;

    [Header("Kondisi")]
    public bool isBurning;

    [Header("Damage")]
    public float dValue;

    [Header("Particle System")]
    public ParticleSystem fireParticle;

    [Header("Distance to Burn")]
    public float distanceBurn;

    public AudioSource damageSound;
    public GameObject Defeat;
    public Defeat_Canvas defeatSound;

    private void Start()
    {
        maxHealth = health;
        isBurning = false;
        Defeat.SetActive(false);

        defeatSound = FindObjectOfType<Defeat_Canvas>();
        damageSound = GetComponentInChildren<AudioSource>();
        
    }

    private void Update()
    {
       /* float distancetoFire = Vector3.Distance(player.transform.position, fireParticle.transform.position);
        if (distancetoFire < distanceBurn)
        {
            isBurning = true;
        }
        else
        {
            isBurning = false;
        }*/
        
        if (isBurning)
        {
            takeDamage();
            if(health <= 0)
            {
                player.SetActive(false);
                Defeat.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                defeatSound.handledeathSound();
            }
        }
        /*else if (health <= 0)
        {
            Destroy(player);
        }*/

        healthSlider.value = health;
    }
    private void takeDamage()
    {
        if (health != 0)
        {
            health -= dValue * Time.deltaTime;
        }

        if (health <= -1)
        {
            health = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("Player") && other.CompareTag ("Fire"))
        {
            isBurning = true;
            damageSound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("Player") && other.CompareTag("Fire"))
        {
            isBurning = false;
            damageSound.Stop();
        }
    }



}
