using UnityEngine;
using UnityEngine.Events;

public class PresenceEvent : MonoBehaviour
{
    [TagSelector]
    public string collisionTag = "";

    public UnityEvent EnterCollisionEvent;

    public UnityEvent ExitCollisionEvent;

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag(collisionTag))
            EnterCollisionEvent.Invoke();
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag(collisionTag))
            ExitCollisionEvent.Invoke();
    }
}
