using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/ Action/ Player/ Idle", fileName = "Player Idle ACT")]
public class PlayerIdleAct : Action
{
    [SerializeField] private PlayerStateKeys _keys;

    private PlayerAnimations _animations;

    public override void ActAwake(StateMachine stateMachine)
    {
        var stateData = stateMachine.StateData;
        stateData.GetData<PlayerAnimations>(_keys.animations, out _animations);
    }

    public override void ActEnter(StateMachine stateMachine)
    {
        _animations.SetBool(_animations.isMoving, false);
    }
}
