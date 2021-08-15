using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _location;
    public Transform targetLocaction
    {
        get { return _location; }
    }
    [SerializeField] private UnityEvent OnInteractEvent;

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Interact()
    {
        OnInteractEvent.Invoke();
    }
}
