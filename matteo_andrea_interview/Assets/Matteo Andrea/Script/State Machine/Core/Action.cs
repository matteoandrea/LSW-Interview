using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{    
    public virtual void ActAwake(StateMachine stateMachine) { }
    public virtual void ActEnter(StateMachine stateMachine) { return; }
    public virtual void ActUpdate(StateMachine stateMachine) { return; }
    public virtual void ActFixedUpdate(StateMachine stateMachine) { return; }
    public virtual void ActExit(StateMachine stateMachine) { return; }

}
