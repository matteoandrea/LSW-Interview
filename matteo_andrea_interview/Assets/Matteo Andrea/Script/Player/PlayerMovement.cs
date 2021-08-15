using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class PlayerMovement
{
    [SerializeField] private PlayerControl _playerControl;
    [SerializeField] private NavMeshAgent _agent;

    public void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public void Move(Vector2 goTo)
    {
        if (!_playerControl.canMove) return;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(goTo, out hit, 1.0f, NavMesh.AllAreas))
        {
            _playerControl.moveTarget = hit.position;
            _agent.SetDestination(_playerControl.moveTarget);

            _playerControl.isMoving = true;
        }
    }
}
