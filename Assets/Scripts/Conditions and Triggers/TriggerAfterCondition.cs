using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAfterCondition : MonoBehaviour
{
    [SerializeField] GameObject[] TriggerConditionObjects;
    [SerializeField] GameObject triggeredObject;
    private bool canActivate = false;
    private bool isActivated = false;

    private void Update()
    {
        CheckTriggers();
        Activate();
    }

    private void CheckTriggers()
    {
        if (isActivated) return;
        if (canActivate) return;

        bool initalCheck = true;

        foreach (GameObject g in TriggerConditionObjects)
        {
            TriggerCondition t = g.GetComponent<TriggerCondition>();
            if (t == null)
            {
                print("TriggerConditionNotFound");
                continue;
            }
            if (!t.TriggerConditionMet)
                initalCheck = false;
        }

        if (initalCheck)
            canActivate = true;
    }
    private void Activate()
    {
        if (!canActivate) return;
        if (isActivated) return;
        ITriggerEffect[] effects = triggeredObject.GetComponentsInChildren<ITriggerEffect>();
        foreach (ITriggerEffect effect in effects)
        {
            if (effect != null)
                effect.TriggerEffect();
        }
    }
}
