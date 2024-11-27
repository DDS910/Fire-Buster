using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float drop = 2f;

    public void Commence (float amount)
    {
        drop -= amount;
        if (drop < 0f)
        {
            Go();
        }
    }

    public void Go ()
    {
        Destroy(gameObject);
    }
}
