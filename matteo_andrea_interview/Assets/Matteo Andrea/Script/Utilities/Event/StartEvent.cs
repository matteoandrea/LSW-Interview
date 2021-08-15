using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartEvent : MonoBehaviour
{
    public UnityEvent startEvent;

    private void Start()
    {
        startEvent.Invoke();
    }
}
