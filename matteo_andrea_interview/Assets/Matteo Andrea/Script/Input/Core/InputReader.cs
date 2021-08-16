using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input/InputReader", order = 0)]
public class InputReader : ScriptableObject, InputControl.IGameplayActions
{
    private InputControl inputActions;

    public event UnityAction<Vector2> MoveEvent = delegate { };
    public event UnityAction ClickEvent = delegate { };
    public event UnityAction PauseEvent = delegate { };


    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new InputControl();

            inputActions.Gameplay.SetCallbacks(this);
            inputActions.Enable();
        }
    }



    public void OnClick(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                ClickEvent.Invoke();
                break;
        }

    }

    public void OnMove(InputAction.CallbackContext context) => MoveEvent.Invoke(context.ReadValue<Vector2>());

    public void OnPause(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                PauseEvent.Invoke();
                break;
        }
    }
}

