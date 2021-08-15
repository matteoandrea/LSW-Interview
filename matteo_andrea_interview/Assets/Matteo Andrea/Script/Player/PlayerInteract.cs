using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInteract
{
    [SerializeField] private InputReader _input;
    [SerializeField] private PlayerControl _playerControl;
    [SerializeField] public IInteractable currentInteract;
    private Camera _cam;

    public void Awake()
    {
        _cam = Camera.main;
    }

    public void Update(Vector2 mousePos)
    {
        FindinteractTarget(mousePos);
    }

    private void ChangeSeleted(IInteractable interactable) => currentInteract = interactable;

    public RaycastHit2D GetHit(Vector2 mousePos)
    {
        var ray = _cam.ScreenPointToRay(mousePos);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        return hit;
    }

    private void FindinteractTarget(Vector2 mousePos)
    {
        if (!_playerControl.canInteract) return;

        var hit = GetHit(mousePos);

        if (hit)
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {

                if (interactable == currentInteract) return;

                else if (currentInteract != null)
                {
                    currentInteract?.Exit();

                    ChangeSeleted(interactable);

                    currentInteract?.Enter();

                    return;
                }
                else
                {
                    ChangeSeleted(interactable);

                    currentInteract?.Enter();

                    return;
                }
            }
            else
            {
                if (currentInteract == null) return;

                currentInteract?.Exit();

                ChangeSeleted(null);

                return;
            }
        }
        else
        {
            if (currentInteract == null) return;

            currentInteract?.Exit();
            ChangeSeleted(null);

            return;
        }
    }
}
