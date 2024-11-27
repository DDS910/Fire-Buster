using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Simple_ControllerFPS;


public class Stamina_Bar : MonoBehaviour
{
    public float stamina;
    private float maxStamina;

    public Slider staminaBar;
    public float dValueRunning;
    public float dValueJumping;
    public float dValueStaminaRegen;
    private float OriginalWalkSpeed;
    public Simple_ControllerFPS controller;
    public Simple_ControllerFPS simple_Controller;
    void Start()
    {
        maxStamina = stamina;
        simple_Controller = FindObjectOfType<Simple_ControllerFPS>();
        OriginalWalkSpeed = simple_Controller.walkspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.State == Simple_ControllerFPS.MovementStates.running && controller.State != Simple_ControllerFPS.MovementStates.jumping && controller.State != Simple_ControllerFPS.MovementStates.crouching)
        {
            DecreaseEnergyRunning();
        }
        else if(controller.State == Simple_ControllerFPS.MovementStates.jumping && controller.State != Simple_ControllerFPS.MovementStates.running && controller.State != Simple_ControllerFPS.MovementStates.crouching)
        {
            DecreaseEnergyJumping();
        }
        else if (Input.GetKey(KeyCode.Space))
            DecreaseEnergyJ();
        else if (stamina != maxStamina)
        {
            IncreaseEnergy();
        }

        staminaBar.value = stamina;
    }

    private void DecreaseEnergyRunning()
    {
        if (stamina != 0)
        {
            stamina -= dValueRunning * Time.deltaTime;
        }

        if (stamina <= -1)
            stamina = 0;

        if (stamina == 0) 
        {
            simple_Controller.SetWalkSpeed(1.5f);
        }
    }

    private void IncreaseEnergy()
    {
        stamina += dValueStaminaRegen * Time.deltaTime;
        if(stamina >= maxStamina )
        {
            stamina = maxStamina;
        }

        if (stamina >= 30)
        {
            simple_Controller.SetWalkSpeed(OriginalWalkSpeed);
        }
    }

    private void DecreaseEnergyJumping()
    {
        if (stamina != 0)
        {
            stamina -= dValueJumping * Time.deltaTime;
        }

        if (stamina <= -1)
            stamina = 0;

        if (stamina == 0)
        {
            simple_Controller.SetWalkSpeed(1.5f);
        }
    }

    private void DecreaseEnergyJ()
    {
        if (stamina != 0) 
        {
            stamina -= dValueStaminaRegen * Time.deltaTime * 5;
        }
        if (stamina <= -1)
            stamina = 0;
    }
}
