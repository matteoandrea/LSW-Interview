using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "State Machine/ Action/ Player/ Move", fileName = "Player Move ACT")]
public class PlayerMoveAct : Action
{
    [SerializeField] private PlayerStateKeys _keys;
    [SerializeField] private PlayerControl _control;

    [SerializeField] private float pathEndThreshold;

    private NavMeshAgent _agent;
    private PlayerAnimations _animations;

    public override void ActAwake(StateMachine stateMachine)
    {
        var stateData = stateMachine.StateData;
        stateData.GetData<NavMeshAgent>(_keys.navAgent, out _agent);
        stateData.GetData<PlayerAnimations>(_keys.animations, out _animations);
    }

    public override void ActEnter(StateMachine stateMachine)
    {
        _animations.SetBool(_animations.isMoving, true);
    }

    public override void ActUpdate(StateMachine stateMachine)
    {
        ControlAnimation();

        if (_agent.remainingDistance <= _agent.stoppingDistance + pathEndThreshold)
            _control.isMoving = false;
    }

    private void ControlAnimation()
    {
        if (_agent.velocity.y > .5f)
            _animations.SetInt(_animations.direction, 1);

        else if (_agent.velocity.y < -.5f)
            _animations.SetInt(_animations.direction,0);

        else if (_agent.velocity.x > .2f)
            _animations.SetInt(_animations.direction, 2);

        else if (_agent.velocity.x < -.2f)
            _animations.SetInt(_animations.direction, 3);
    }
}
