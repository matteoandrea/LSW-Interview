using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInteract
{
    [SerializeField] private InputReader _input;
    [SerializeField] private PlayerControl _playerControl;
    public IInteractable LookInteract;
    public IInteractable currentInteract;
    private Camera _cam;

    public void Awake()
    {
        _cam = Camera.main;
    }

    public void Update(Vector2 mousePos)
    {
        FindinteractTarget(mousePos);
    }

    private void ChangeSeleted(IInteractable interactable) => LookInteract = interactable;

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

                if (interactable == LookInteract) return;

                else if (LookInteract != null)
                {
                    LookInteract?.Exit();

                    ChangeSeleted(interactable);

                    LookInteract?.Enter();

                    return;
                }
                else
                {
                    ChangeSeleted(interactable);

                    LookInteract?.Enter();

                    return;
                }
            }
            else
            {
                if (LookInteract == null) return;

                LookInteract?.Exit();

                ChangeSeleted(null);

                return;
            }
        }
        else
        {
            if (LookInteract == null) return;

            LookInteract?.Exit();
            ChangeSeleted(null);

            return;
        }
    }
}
