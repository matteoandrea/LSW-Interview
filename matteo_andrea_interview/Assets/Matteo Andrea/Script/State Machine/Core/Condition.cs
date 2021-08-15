using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : ScriptableObject
{   
    public virtual void DecideEnter(StateMachine stateMachine) { }
    public abstract bool Decide(StateMachine stateMachine);
    public virtual void DecideExit(StateMachine stateMachine) { }
}
