using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInteractable
{
    Transform targetLocaction { get; }
    void Enter();
    void Interact();
    void Exit();
}