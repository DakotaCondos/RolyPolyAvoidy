using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCondition : MonoBehaviour
{
    private bool triggerConditionMet = false;

    public bool TriggerConditionMet { get => triggerConditionMet; set => triggerConditionMet = value; }
}
