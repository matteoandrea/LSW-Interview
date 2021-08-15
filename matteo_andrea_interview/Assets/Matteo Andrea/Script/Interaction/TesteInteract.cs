using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TesteInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _location;
    public Transform targetLocaction
    {
        get {return _location; }
    }
    [SerializeField] private UnityEvent OnInteractEvent;

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void Interact()
    {
        OnInteractEvent.Invoke();
    }


}
