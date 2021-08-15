using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transition
{   
    public State ToState;
    public ConditionState[] conditionState;    
}
