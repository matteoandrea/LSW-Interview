using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerClothManager", menuName = "Player/PlayerClothManager", order = 0)]
public class PlayerClothManager : ScriptableObject
{
    public event UnityAction<Sprite> ChangeClothEvent = delegate { };

    public void ChangeCloth(Sprite cloth) => ChangeClothEvent.Invoke(cloth);
}

