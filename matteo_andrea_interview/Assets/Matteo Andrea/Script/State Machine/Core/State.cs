using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/ State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitions;


    #region State Function

    public void OnAwakeState(StateMachine stateMachine)
    {
        DoAwakeAction(stateMachine);
    }

    public void OnEnterState(StateMachine stateMachine)
    {
        DoActionsEnter(stateMachine);
        DoDecideEnter(stateMachine);
    }
    public void UpdateState(StateMachine stateMachine)
    {
        DoActionsUpdate(stateMachine);
        CheckTransition(stateMachine);
    }
    public void FixedUpdateState(StateMachine stateMachine)
    {
        DoActionsFixedUpdate(stateMachine);

    }
    public void OnExitState(StateMachine stateMachine)
    {
        DoActionsExit(stateMachine);
        DoDecideExit(stateMachine);
    }
    #endregion


    #region Actions
    private void DoActionsEnter(StateMachine stateMachine)
    {
        if (actions == null)
            return;


        foreach (var item in actions)
        {
            item.ActEnter(stateMachine);
        }
    }
    private void DoActionsUpdate(StateMachine stateMachine)
    {
        if (actions == null)
            return;


        foreach (var item in actions)
        {
            item.ActUpdate(stateMachine);
        }
    }
    private void DoActionsFixedUpdate(StateMachine stateMachine)
    {
        if (actions == null)
            return;

        foreach (var item in actions)
        {
            item.ActFixedUpdate(stateMachine);
        }
    }
    private void DoActionsExit(StateMachine stateMachine)
    {
        if (actions == null)
            return;


        foreach (var item in actions)
        {
            item.ActExit(stateMachine);
        }
    }

    private void DoAwakeAction(StateMachine stateMachine)
    {
        foreach (var action in actions)
        {
            action.ActAwake(stateMachine);
        }
    }

    #endregion


    #region Transitions & Decisions

    private void DoDecideEnter(StateMachine stateMachine)
    {
        foreach (var transition in transitions)
        {
            for (int i = 0; i < transition.conditionState.Length; i++)
            {
                var condition = transition.conditionState[i].condition;
                condition.DecideEnter(stateMachine);

            }
        }
    }

    private void DoDecideExit(StateMachine stateMachine)
    {
        foreach (var transition in transitions)
        {
            for (int i = 0; i < transition.conditionState.Length; i++)
            {
                var condition = transition.conditionState[i].condition;
                condition.DecideExit(stateMachine);

            }
        }
    }

    private void CheckTransition(StateMachine stateMachine)
    {
        bool succeded = false;

        foreach (var transition in transitions)
        {
            for (int i = 0; i < transition.conditionState.Length; i++)
            {
                var condition = transition.conditionState[i];
                succeded = condition.IsStateValid(stateMachine);

                if (condition.operation == ConditionState.Operation.And && succeded)
                {
                    continue;
                }
                else if (condition.operation == ConditionState.Operation.Or)
                {
                    if (succeded)
                        CheckOr(transition.conditionState, ref i);
                }
            }

            if (succeded)
            {
                stateMachine.SetCurrentState(transition.ToState);
                return;
            }
        }

    }

    private void CheckOr(ConditionState[] conditions, ref int _index)
    {
        _index++;
        if (_index >= conditions.Length)
            return;

        var state = conditions[_index];

        if (state.operation == ConditionState.Operation.Or)
        {
            CheckOr(conditions, ref _index);
        }
    }

    #endregion
}
