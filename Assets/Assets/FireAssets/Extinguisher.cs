using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float amountExtinguishPerSecond = 1.0f;
    [SerializeField] private ParticleSystem extinguisher;
    [SerializeField] private Interaksi4 interaksi;
    [SerializeField] private AudioSource ExtinguisherSFX;
    [SerializeField] private Canvas canvas_Item;
    [SerializeField] private Slider canvas_ItemBar;
    [SerializeField] private float dValue; //value untuk pengurangan isi dari fire extinguisher

    [SerializeField] public float FE_Value; //value untuk berapa isi dari extinguisher

    private float Max_FE; //value untuk maximal dari isi Fire extinguisher
    private bool isPlay;
    //private bool isHoldingItem;

    private void Start()
    {
        extinguisher.Stop();
        isPlay = false;
        //isHoldingItem = false;
        ExtinguisherSFX.Stop();
        canvas_Item.enabled = false;

    }
    private void Update()
    {
        if (interaksi.isHolding)
        {
            canvas_Item.enabled = true;
            if (Input.GetMouseButton(0) && !isPlay)
            {
                extinguisher.Play();
                isPlay = true;
                ExtinguisherSFX.Play();
            }
            else if (Input.GetMouseButtonUp(0) && isPlay)
            {
                extinguisher.Stop();
                isPlay = false;
                ExtinguisherSFX.Stop();
            }

            if (isPlay)
            {
                if (extinguisher.isPlaying && Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100f)
                    && hit.collider.TryGetComponent(out Penyebaran_Api fire))
                {
                    fire.TryExtinguish(amountExtinguishPerSecond * Time.deltaTime);
                }
                DecreaseValue();
            }
        }
        else
        {
            canvas_Item.enabled = false;
        }

        canvas_ItemBar.value = FE_Value;
    }

    private void DecreaseValue()
    {
        if (isPlay && FE_Value != 0)
        {
            FE_Value -= dValue * Time.deltaTime;
        }

        if (FE_Value <= -1)
        {
            FE_Value = 0;
        }

        if (FE_Value == 0)
        {
            isPlay = false;
            extinguisher.Stop();
            ExtinguisherSFX.Stop();
        }
    }
}
