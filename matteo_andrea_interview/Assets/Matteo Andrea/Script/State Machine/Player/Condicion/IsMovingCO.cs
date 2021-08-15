using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/ Condition/ Player/ Is Moving", fileName = "Is Moving")]
public class IsMovingCO : Condition
{    
    [SerializeField] private PlayerControl control;         

    public override bool Decide(StateMachine stateMachine)
    {
        return control.isMoving;
    }
}