using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen_Bar : MonoBehaviour
{
    public float Oxygen;
    private float maxOxygen;
    public GameObject Defeat;
    public Defeat_Canvas defeatSound;

    public Slider oxygenBar;
    public float dValue_Oxygen;
    public GameObject player;

    void Start()
    {
        maxOxygen = Oxygen;
        Defeat.SetActive(false);
        defeatSound = FindObjectOfType<Defeat_Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        oxygenBar.value = Oxygen;
        DecreaseOxygen();
    }

    private void DecreaseOxygen()
    {
        if(Oxygen != 0)
        {
            Oxygen -= dValue_Oxygen * Time.deltaTime;
        }
        
        if(Oxygen <= -1)
        {
            Oxygen = 0;
        }

        if(Oxygen == 0)
        {
            Defeat.SetActive(true);
            defeatSound.handledeathSound();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player.SetActive(false);
        }
    }
}
