using System;

using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class PresenceEventDelay : MonoBehaviour
{
    [TagSelector]
    public string collisionTag = "";

    [Space(10)]
    [Header("Enter")]
    public float enterDelay;
    private UniTask _enterTask;
    public UnityEvent EnterCollisionEvent;

    [Space(10)]
    [Header("Exit")]

    public float exitDelay;
    private UniTask _exitTask;
    public UnityEvent ExitCollisionEvent;

    private async UniTaskVoid TriggerEnterEventAsync()
    {
        _enterTask = UniTask.Delay(TimeSpan.FromSeconds(enterDelay), ignoreTimeScale: false);

        await _enterTask;       

        EnterCollisionEvent.Invoke();
    }

    private async UniTaskVoid TriggerExitEventAsync()
    {
        _exitTask = UniTask.Delay(TimeSpan.FromSeconds(exitDelay), ignoreTimeScale: false);

        await _exitTask;

        ExitCollisionEvent.Invoke();
    }



    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag(collisionTag))
        {
            UniTaskVoid uniTaskVoid = TriggerEnterEventAsync();
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag(collisionTag))
        {
            UniTaskVoid uniTaskVoid = TriggerExitEventAsync();
        }
    }
}
