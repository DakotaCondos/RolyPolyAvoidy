using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTriggerEffect : MonoBehaviour, ITriggerEffect
{
    [SerializeField] GameObject slideObject;

    public void TriggerEffect()
    {
        Slide s = slideObject.GetComponent<Slide>();
        if (s != null) s.isSlideEnabled = true;
    }
}
