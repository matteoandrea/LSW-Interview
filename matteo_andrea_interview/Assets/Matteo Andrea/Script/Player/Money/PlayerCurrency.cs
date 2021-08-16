using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerCurrency", menuName = "Player/PlayerCurrency", order = 0)]
public class PlayerCurrency : ScriptableObject
{
    [SerializeField] private float startMoney;
    [SerializeField] private float _money;

    public event UnityAction<float> UpdateCurrencyEvent = delegate { };

    public float Money
    {
        get => _money;

        set
        {
            _money += value;
            if (_money < 0) _money = 0;

            UpdateCurrencyEvent.Invoke(_money);
        }
    }

    private void OnEnable()
    {
        _money = startMoney;
    }
}

