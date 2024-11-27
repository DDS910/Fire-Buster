using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight_Item : MonoBehaviour
{
    [SerializeField] private List<Renderer> renderers;
    [SerializeField] private Color color = Color.white;

    private List<Material> materials;

    private void Update()
    {
        ToogleHighlight(true);
    }
    private void Awake()
    {
        materials = new List<Material>();
        foreach (var renderer in renderers)
        {
            materials.AddRange(new List<Material>(renderer.materials));
        }
    }

    public void ToogleHighlight(bool val)
    {
        if(val)
        {
            foreach (var material in materials)
            {
                material.EnableKeyword("_EMISSION");

                material.SetColor("_EMISSION", color);
            }
        }
        else
        {
            foreach (var material in materials)
            {
                material.DisableKeyword("_EMISSION");

            }
        }
    }


}
