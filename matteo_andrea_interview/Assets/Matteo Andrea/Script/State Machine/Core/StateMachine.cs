using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(StateMachineData))]
public class StateMachine : MonoBehaviour
{    
    [Header("Components")]
    public StateMachineTable stateMachineTable;

    [SerializeField] private State _startState;

    [Header("Debug")]
    public State currentState;
    public State previousState;

    private StateMachineData stateData;
    public StateMachineData StateData => stateData;
    

    private void Awake()
    {
        stateData = GetComponent<StateMachineData>();
        stateData.InicializeData();
        stateMachineTable.StateAwake(this);
    }

    private void Start()
    {
        SetCurrentState(_startState);
    }

    private void Update()
    {
        currentState?.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdateState(this);
    }


    public void SetCurrentState(State state)
    {
        SetPreviousState(currentState);
        currentState = state;
        currentState.OnEnterState(this);
    }

    private void SetPreviousState(State state)
    {
        previousState = state;
        previousState?.OnExitState(this);
    }
}
