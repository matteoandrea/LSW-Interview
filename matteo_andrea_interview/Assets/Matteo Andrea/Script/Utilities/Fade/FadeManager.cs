using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FadeManager", menuName = "Utilities/FadeManager", order = 0)]
public class FadeManager : ScriptableObject
{
    public event UnityAction<float> FadeInEvent = delegate { };
    public event UnityAction<float> FadeOutEvent = delegate { };

    public void TriggerFadeIn(int i) => FadeInEvent.Invoke(i);
    public void TriggerFadeOutn(int i) => FadeOutEvent.Invoke(i);
}

