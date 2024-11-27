using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComplete : MonoBehaviour
{
    public Loading_Trigger loadingTrigger;

    public void TriggerLoadComplete()
    {
        if(loadingTrigger != null)
        {
            loadingTrigger.OnAnimationCompleted();
        }
    }
}
