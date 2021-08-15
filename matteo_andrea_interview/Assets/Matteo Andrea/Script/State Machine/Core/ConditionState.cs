using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConditionState
{
    public enum BoolState
    {        
        False,
        True
    }

    public enum Operation
    {
        And,
        Or
    }

    public Condition condition;
    public BoolState boolState;
    public Operation operation;

    
    public bool IsStateValid(StateMachine stateMachine)
    {
        var co = condition.Decide(stateMachine);

        bool _Bstate = boolState == BoolState.True;

        return co == _Bstate;
    }   
}
